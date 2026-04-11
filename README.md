# .NET SDK for Xurrent REST

A .NET Framework and .NET client library for accessing the [Xurrent REST API](https://developer.xurrent.com/v1/), [Bulk API](https://developer.xurrent.com/v1/bulk/) and [Events API](https://developer.xurrent.com/v1/requests/events/).

## Table of Contents

- [NuGet](#nuget)
- [Quick Example](#quick-example)
- [Introduction](#introduction)
- [Client](#client)
- [Authentication](#authentication)
- [Clients and endpoints](#clients-and-endpoints)
- [Pagination and streaming](#pagination-and-streaming)
- [Querying](#querying)
  - [Selecting fields](#selecting-fields)
  - [Filtering](#filtering)
  - [Predefined filters](#predefined-filters)
  - [Ordering](#ordering)
- [Mutations](#mutations)
  - [Create, Update and Delete](#create-update-and-delete)
  - [Relations between root resources](#relations-between-resources)
  - [Mutations for owned relational data](#mutations-for-owned-relational-data)
- [Attachments](#attachments)
- [Events API](#events-api)
- [Bulk API](#bulk-api)
- [Extension Methods](#extension-methods)
- [Exception Handling](#exception-handling)
- [Special timestamps](#special-timestamps)
- [Client behavior and limits](#client-behavior-and-limits)

## NuGet

Stable binaries are published to [NuGet.org](https://www.nuget.org/packages/Works4me.Xurrent.Rest) and contain everything needed to use the .NET SDK for Xurrent REST in your application.

**Package Manager Console**

```powershell
Install-Package Works4me.Xurrent.Rest
```

**.NET CLI**

```
dotnet add package Works4me.Xurrent.Rest
```

**Visual Studio**  
Use the NuGet Package Manager in Visual Studio to search for and install `Works4me.Xurrent.Rest`.

## Quick Example

```csharp
using Works4me.Xurrent.Rest;

ILogger<XurrentClient> logger = loggerFactory.CreateLogger<XurrentClient>();

AuthenticationToken token = new AuthenticationToken("ClientId", "ClientSecret");
XurrentClient client = new(token, "account-id", EnvironmentType.Demo, EnvironmentRegion.EU, logger);

PersonQuery personQuery = new PersonQuery()
    .PredefinedFilter(Person.PredefinedFilter.Directory)
    .Select(Person.Field.Id, Person.Field.Name, Person.Field.PrimaryEmail, Person.Field.Organization);
                
await foreach (Person person in client.People.StreamAsync(personQuery))
{
    string orgName = person.Organization?.Name ?? "no organization";
    Console.WriteLine($"{person.Name} works at {orgName}.");
}
```

Want more? See the full [Examples](#examples) section below.

## Introduction

This SDK simplifies integration with the Xurrent REST API by abstracting HTTP request construction, JSON serialization and deserialization, and connection data retrieval. It exposes a set of fluent, strongly-typed classes so you can build REST operations with minimal boilerplate.

Under the covers, it manages rate-limit compliance, token renewal, and optimized handling of large result sets, allowing you to focus on application logic and business requirements.

The entity classes and fields in this SDK mirror the documentation available on the [Xurrent Developer Pages](https://developer.xurrent.com/v1/) and may include preview features or fields not yet available in production.

## Client

The `XurrentClient` class provides access to all REST functionality through its exposed clients and properties.

You can customize client behavior through the following key properties:
- `AccountId`: Update the Xurrent Account ID after initializing the client, enabling account switching using the same client instance.
- `DefaultItemsPerRequest`: Set the number of items per connection request. The default and maximum value is 100.
- `MaximumRequestsPerQuery`: Control the maximum number of recursive requests the client can make when paginating top-level queries. The default value is 1000, the maximum value is 10000.

## Authentication

The SDK supports both Personal Access Token and OAuth 2.0 Client Credential Grant authentication methods.
When using OAuth 2.0 Client Credential Grant, token renewal is handled automatically two minutes before expiration.

### Personal Access Token

Authentication is configured using an `AuthenticationToken`, which requires a personal access token obtained from your Xurrent profile.

```csharp
AuthenticationToken token = new AuthenticationToken("PersonalAccessToken");
```

### Client Credentials

Authentication is configured using an `AuthenticationToken`, which requires a client ID and client secret obtained from Xurrent.

```csharp
AuthenticationToken token = new AuthenticationToken("ClientId", "ClientSecret");
```

The token instance is passed to the XurrentClient during initialization. The client will:
- Request an access token when needed
- Automatically refresh the token before it expires
- Reuse tokens across requests made by the same client instance

You do not need to manually manage token lifetimes.

### Environment and Region

When constructing the client, you must specify both the environment and region:

```csharp
XurrentClient client = new(
    token,
    "account-id",
    EnvironmentType.Production,
    EnvironmentRegion.EU,
    logger
);
```

- `EnvironmentType`  
  Determines whether requests are sent to the Demo, Quality Assurance, or Production environment.

- `EnvironmentRegion`  
  Specifies the geographic region of your Xurrent account.

These values control the base URLs used for authentication and API requests.

### Thread Safety and Reuse

`XurrentClient` instances are designed to be reused and are safe to use concurrently.

For most applications, a single long-lived client instance per account and environment is recommended.

## Clients and endpoints

The SDK exposes the Xurrent REST API through a set of resource-specific clients. Each client maps directly to a REST endpoint as documented on the [Xurrent developer pages](https://developer.xurrent.com/v1) and is accessed through the root `XurrentClient`.

The structure of the SDK mirrors the REST API itself: top-level resources are available as properties on `XurrentClient`, while related or nested resources are exposed through sub-clients.

### Accessing resource clients

Each REST resource has a dedicated client that is lazily created and reused by the `XurrentClient`, which are only accessible via the corresponding property on `XurrentClient` (for example `XurrentClient.People`).

The following example shows a simple query against the People endpoint using `GetAsync`:

```csharp
PersonQuery query = new PersonQuery()
    .Select(Person.Field.Id, Person.Field.Name, Person.Field.PrimaryEmail);

ReadOnlyKeyedDataCollection<Person> people = await client.People.GetAsync(query);

foreach (Person person in people)
{
    Console.WriteLine(person.Name);
}
```

`GetAsync` returns a read-only keyed collection. The key represents the Xurrent identifier of the returned object.

This one-to-one mapping is intentional and allows you to use the official REST documentation alongside this SDK with minimal translation.

### Related and nested resources

Some resource clients expose nested clients for related resources. These nested clients reflect the relationships defined in the Xurrent REST API and allow you to retrieve related data without manually constructing URLs or passing identifiers explicitly.

The following example shows how to retrieve configuration items related to each person:

```csharp
PersonQuery query = new PersonQuery()
    .Select(Person.Field.Id, Person.Field.Name, Person.Field.PrimaryEmail);

ReadOnlyKeyedDataCollection<Person> people = await client.People.GetAsync(query);

foreach (Person person in people)
{
    ReadOnlyKeyedDataCollection<ConfigurationItem> configurationItems =
        await client.People.ConfigurationItems.GetAsync(person, new ConfigurationItemQuery());

    foreach (ConfigurationItem configurationItem in configurationItems)
    {
        Console.WriteLine($"{configurationItem.Label} belongs to {person.Name}");
    }
}
```

In this example, the nested `ConfigurationItems` client is scoped to the parent `Person` instance. The SDK uses the identifier of the parent object to resolve the correct REST endpoint automatically.

### Endpoint mapping

Each resource client corresponds directly to the official Xurrent REST documentation. For example:

- `XurrentClient.People` maps to https://developer.xurrent.com/v1/people/
- `XurrentClient.Account` maps to https://developer.xurrent.com/v1/account/
- `XurrentClient.Requests` maps to https://developer.xurrent.com/v1/requests/

### Client lifetime and reuse

All resource clients are created internally by the `XurrentClient` and cached for reuse. You do not need to manage their lifetime manually. As long as the root `XurrentClient` instance is alive, all derived clients remain valid and share the same configuration, authentication context, and HTTP infrastructure.

## Pagination and streaming

The Xurrent REST API uses cursor-based pagination for collection endpoints. This SDK handles pagination automatically and exposes two complementary ways to consume result sets: materialized retrieval and asynchronous streaming.

### GetAsync

`GetAsync` retrieves the full result set and returns it as a read-only keyed collection. Internally, the client will issue as many paginated requests as required (within configured limits) and combine the results.

```csharp
PersonQuery query = new PersonQuery()
    .Select(Person.Field.Id, Person.Field.Name);

ReadOnlyKeyedDataCollection<Person> people = await client.People.GetAsync(query);
```

Use `GetAsync` when:

- The expected result set is reasonably small
- You need random access to the results by Xurrent identifier
- You want the full data set available before processing

### StreamAsync

`StreamAsync` returns an `IAsyncEnumerable<T>` and yields items as they are received from the API. Pagination happens transparently while iterating the sequence.

```csharp
PersonQuery query = new PersonQuery()
    .Select(Person.Field.Id, Person.Field.Name);

await foreach (Person person in client.People.StreamAsync(query))
{
    Console.WriteLine(person.Name);
}
```

Use `StreamAsync` when:

- You are working with large result sets
- You want to start processing data immediately
- You want to avoid buffering the entire result set in memory

### Paging limits and safety

To prevent unbounded requests, pagination behavior is governed by client-level limits:

- `DefaultItemsPerRequest`  
  Controls the number of items requested per API call.

- `MaximumRequestsPerQuery`  
  Limits the total number of paginated requests that a single query may trigger.

The number of items requested per API call can be overridden on a per-query basis:

```csharp
PersonQuery query = new PersonQuery()
    .ItemsPerRequest(10)
```

### Choosing between GetAsync and StreamAsync

Both methods provide access to the same underlying data and API endpoints. The choice depends on how you want to consume the results:

- Use `GetAsync` for convenience and keyed access
- Use `StreamAsync` for scalability and low memory usage

## Querying

The SDK uses strongly-typed query objects to model filtering, field selection, and ordering for REST endpoints. These query objects closely follow the structure and semantics described in the Xurrent REST API documentation and are designed to be used alongside the official developer pages.

Each resource has its own query type (for example `PersonQuery`, `RequestQuery`, `ConfigurationItemQuery`), exposing only the filters, fields, and ordering options that are valid for that resource.

### Selecting fields

By default, Xurrent endpoints return a limited set of fields. To control which fields are returned, explicitly specify them using `Select`.

```csharp
PersonQuery query = new PersonQuery()
    .Select(Person.Field.Id,Person.Field.Name);
```

Only the selected fields will be included in the response. This mirrors the behavior documented on the Xurrent developer pages and helps reduce payload size.

**Recommendation**  
Avoid relying on default field selection. Explicitly selecting only the fields you need reduces response size, lowers serialization overhead, and has a positive impact on overall performance, especially when working with large result sets.

### Filtering

Query objects expose strongly-typed filter methods that correspond directly to REST query parameters. These filters allow you to restrict results based on field values, relationships, or status, exactly as defined in the Xurrent REST API.

The following example filters configuration items that have a serial number present and a specific status:

```csharp
ConfigurationItemQuery query = new ConfigurationItemQuery()
    .Select(ConfigurationItem.Field.Label, ConfigurationItem.Field.SerialNr)
    .Where(ConfigurationItem.FilterField.SerialNr, FilterOperator.Present)
    .Where(ConfigurationItem.FilterField.Status, FilterOperator.Equality, ConfigurationItemStatus.InProduction);
```

You can also filter on multiple values for a single field using `FilterOperator.In`:

```csharp
ConfigurationItemQuery query = new ConfigurationItemQuery()
    .Select(ConfigurationItem.Field.Label, ConfigurationItem.Field.SerialNr)
    .Where(ConfigurationItem.FilterField.SerialNr, FilterOperator.Present)
    .Where(ConfigurationItem.FilterField.Status, FilterOperator.In, ConfigurationItemStatus.InProduction, ConfigurationItemStatus.Installed);
```

### Predefined filters

Most endpoints support predefined filters as documented by Xurrent. These filters are exposed directly by the Xurrent REST API and are surfaced in the SDK through `PredefinedFilter`.

```
PersonQuery query = new PersonQuery()
    .PredefinedFilter(Person.PredefinedFilter.Directory)
    .Select(Person.Field.Id,Person.Field.Name);
```

Predefined filters provide a concise and readable way to express common query patterns without manually composing multiple filter conditions.

Some filtering capabilities are only available through predefined filters and cannot be expressed using ad-hoc `Where` clauses. In those cases, using the predefined filter is required to access the corresponding API behavior.

The SDK does not implement additional filtering logic of its own; it exposes the predefined filters exactly as they are defined at the API level.

### Ordering

Many endpoints support ordering results based on one or more fields. Query objects expose ordering methods that map directly to the REST API ordering parameters for that resource.

```csharp
PersonQuery query = new PersonQuery()
    .OrderBy(Person.OrderField.Name, SortOrder.Descending)
    .Select( Person.Field.Id, Person.Field.Name);
```

## Mutations

### Create, Update and Delete

Mutations are exposed on the root resource clients as `CreateAsync` and `UpdateAsync`. Only a limited number of root resources support `DeleteAsync`.
Most root resources cannot be deleted and instead expose lifecycle actions such as archive, trash, or restore where applicable.

#### Create

To create a record, instantiate the corresponding model and pass it to `CreateAsync`.

```csharp
Person person = new Person("Jane Doe", "jane.doe@example.com")
{
    Organization = new Organization(12),
    JobTitle = "Developer",
    CustomFields = new CustomFieldCollection()
    {
        new CustomField("property_1", "Custom Value 1".ToJsonElement()),
        new CustomField("property_2", 123.ToJsonElement()),
    }
};
```

#### Update

To update a record, provide a model instance that includes the identifier and the fields you want to change.

```csharp
Person person = new Person(12345);
person.Name = "Jane Doe (Updated)";
person.CustomFields.AddOrUpdate("property_2", 567.ToJsonElement());

Person updatedPerson = await client.People.UpdateAsync(person);
Console.WriteLine($"Updated person {updatedPerson.Id}");
```

#### Delete

Only a subset of root resources support deletion. For delete-capable resources, use `DeleteAsync` and pass either the identifier or the model instance.

```csharp
bool deleted = await client.Webhooks.DeleteAsync(12345);
// or
// Webhook webhook = new Webhook(12345);
// bool deleted = await client.Webhooks.DeleteAsync(webhook);

Console.WriteLine($"Deleted: {deleted}");
```

### Relations between resources

Some endpoints manage explicit links between two resources that are each exposed as their own REST endpoint. These links are represented as separate REST operations and are managed independently from the lifecycle of the resources they connect.

Relationships that are represented as a single embedded object are exposed directly as properties on the model and are not mutated through relation endpoints (for example `Person.Organization`).

For link-based relationships, the SDK exposes mutation methods such as `AddAsync(...)`, `RemoveAsync(...)`, and `RemoveAllAsync(...)`. These operations affect only the link between the resources. They do not create, update, or delete either resource.

#### Example: People and Configuration Items

People and configuration items can be linked through a dedicated relationship endpoint. This relationship is exposed via the `ConfigurationItems` sub-client on `People`.

##### Add a link

```csharp
long personId = 12345;
long configurationItemId = 67890;

bool added = await client.People.ConfigurationItems.AddAsync(personId, configurationItemId);
Console.WriteLine($"Link added: {added}");
```

##### Remove a link
```csharp
long personId = 12345;
long configurationItemId = 67890;

bool removed = await client.People.ConfigurationItems.RemoveAllAsync(personId, configurationItemId);
Console.WriteLine($"Link removed: {removed}");
```

##### Remove all links
```csharp
long personId = 12345;

bool removed = await client.People.ConfigurationItems.RemoveAsync(personId);
Console.WriteLine($"Link removed: {removed}");
```

##### Using model instances

If model instances are available, they can be used instead of raw identifiers.

```csharp
Person person = new Person(12345);
ConfigurationItem configurationItem = new ConfigurationItem(67890);

bool added = await client.People.ConfigurationItems.AddAsync(person, configurationItem);
bool removed = await client.People.ConfigurationItems.RemoveAsync(person, configurationItem);
bool removedAll = await client.People.ConfigurationItems.RemoveAllAsync(person);
```

In all cases, the operation mutates only the relationship as defined by the Xurrent REST API.

### Mutations for owned relational data

Some resources expose related records that only exist in the context of a parent record. These records are always managed through a sub-client on the parent resource client (for example `client.People.Addresses`) and their endpoints require the parent identifier.

Owned records can typically be created, updated, and deleted. Many owned resources also support a bulk removal operation (for example `DeleteAllAsync`).

#### Example: Addresses of a Person

Addresses are managed via the `Addresses` sub-client on `People`.

##### Create

```csharp
long personId = 12345;

Address address = new Address();
// set the fields you need on the address model

Address createdAddress = await client.People.Addresses.CreateAsync(personId, address);
Console.WriteLine($"Created address with id {createdAddress.Id}");
```

##### Update

Updates are performed by sending an `Address` instance with its `Id` set and only the fields you want to change.


```csharp
long personId = 12345;

Address address = new Address(67890);
// update fields on the address model

Address updatedAddress = await client.People.Addresses.UpdateAsync(personId, address);
Console.WriteLine($"Updated address {updatedAddress.Id}");
```

##### Delete

```csharp
long personId = 12345;
long addressId = 67890;

bool deleted = await client.People.Addresses.DeleteAsync(personId, addressId);
Console.WriteLine($"Deleted: {deleted}");
```

##### Delete all

```csharp
long personId = 12345;

bool deletedAll = await client.People.Addresses.DeleteAllAsync(personId);
Console.WriteLine($"Deleted all addresses: {deletedAll}");
```

##### Using a loaded Person instance

Overloads are available that accept the parent model instance instead of the raw identifier.

```csharp
Person person = new Person(12345);

Address address = new Address();
Address createdAddress = await client.People.Addresses.CreateAsync(person, address);

bool deletedAll = await client.People.Addresses.DeleteAllAsync(person);
```

## Attachments

The `XurrentClient` exposes `UploadAttachmentAsync` for uploading files. Uploaded attachments can then be referenced during create or update operations on supported resources.

The upload response contains the metadata required to associate the attachment with other objects.

### Add a note with an attachment to a request

```csharp
AttachmentUploadResponse attachment = await client.UploadAttachmentAsync(@".\image.png", "image/png");

NoteCreate newNote = new NoteCreate()
{
    Text = "My message to the world!"
};
newNote.Attachments.Add(attachment, false);

Request request = await client.Requests.Notes.CreateAsync(704880, newNote);
```

### Add an inline attachment to the person information field

Inline attachments are referenced directly from rich-text fields using the attachment key.

```csharp
AttachmentUploadResponse attachment = await client.UploadAttachmentAsync(@".\image.png", "image/png");

Person person = new Person(12345)
{
    Information = $"Happy Friday\n![]({attachment.Key})"
};
person.InformationAttachments.Add(attachment, true);

Person updatedPerson = await client.People.UpdateAsync(person);
```

## Events API

The SDK provides access to the Xurrent Events REST API, which allows external systems to create or update requests in Xurrent by publishing events.

Events are processed asynchronously by Xurrent and result in the creation of a new request or an update to an existing one, depending on the event content and identifiers provided.

For detailed API semantics and supported fields, refer to the [Xurrent Developer Pages](https://developer.xurrent.com/v1/requests/events/).

### Create a New Event via the Events API

To publish an event, construct a `RequestEventCreateInput` instance and pass it to `CreateEventAsync`.

```csharp
RequestEventCreateInput requestCreate = new RequestEventCreateInput()
    .Category(RequestCategory.Incident)
    .Note("An event note")
    .Subject("SDK Test 2")
    .Source("Works4me.Xurrent.Rest")
    .SourceID("1")
    .ServiceInstance(34)
    .Impact(RequestImpact.Medium)
    .ConfigurationItem(150)
    .Team(16);

Request request = await client.CreateEventAsync(requestCreate);
```

The returned `Request` represents the request created or updated as a result of the event, as processed by Xurrent.

## Bulk API

The Bulk API is designed for moving larger datasets in and out of Xurrent using asynchronous jobs. It exposes two dedicated endpoints:
- Import API (`/v1/import`) for batch create and update using UTF-8 CSV or TSV files.
- Export API (`/v1/export`) for downloading batches of records as UTF-8 CSV or Excel files.
 
For more information, see the [Xurrent Developer Pages](https://developer.xurrent.com/v1/bulk/).

### Excel Export

This example demonstrates how to start an export of changed configuration items, people, and requests from the last 10 days.
The code waits for the export to complete, using a polling interval of 10 seconds and a timeout of 10 minutes. Once complete, it outputs the download URL for the exported file.

```csharp
CancellationTokenSource ct = new CancellationTokenSource(TimeSpan.FromMinutes(10));

string token = await client.Bulk.StartExcelExportAsync(["cis", "people", "requests"], DateTime.Now.AddDays(-10));
BulkExportResponse result = await client.Bulk.AwaitExportAsync(token, TimeSpan.FromSeconds(10), ct.Token);

Console.WriteLine(result.Url);
```

### CSV Export

This example shows how to export changed tasks from the last 15 days to a CSV file.
The code waits for completion, polling every 10 seconds with a timeout of 10 minutes, and saves the result as `tasks.csv`.

```csharp
CancellationTokenSource ct = new CancellationTokenSource(TimeSpan.FromMinutes(10));

string token = await client.Bulk.StartCsvExportAsync(["tasks"], ExportLineSeparator.LineFeed, DateTime.Now.AddDays(-15), ct.Token);
await client.Bulk.AwaitDownloadAndSaveAsync(@".\tasks.csv", token, TimeSpan.FromSeconds(10), ct.Token);
```

### CSV Import

This example demonstrates how to import data from a CSV file.
The code starts the import, waits for completion with a polling interval of 15 seconds and a timeout of 5 minutes, and then prints the results.

```csharp
CancellationTokenSource ct = new CancellationTokenSource(TimeSpan.FromMinutes(5));

string token = await client.Bulk.StartImportAsync("new_cis.csv", "cis", ct.Token);
BulkImportResponse response = await client.Bulk.AwaitImportAsync(token, TimeSpan.FromSeconds(15), ct.Token);
if (response.State == ImportExportStatus.Done)
{
    Console.WriteLine($"  Created: {response.Results.Created}");
    Console.WriteLine($"   Update: {response.Results.Updated}");
    Console.WriteLine($"  Deleted: {response.Results.Deleted}");
    Console.WriteLine($" Failures: {response.Results.Failures}");
    Console.WriteLine($"Unchanged: {response.Results.Unchanged}");
}
```

## Extension Methods

The SDK includes a small set of extension methods to simplify common tasks when working with Xurrent data types and SDK models.

All extension methods described in this section are available by adding:

```csharp
using Works4me.Xurrent.Rest.Extensions;
```

### DateTime special timestamp helpers

Xurrent can return special timestamp states that are represented in the SDK as reserved `DateTime` values. To detect these values without comparing raw `DateTime` instances, the following extension methods are available:

- `DateTime.IsBestEffort()`
- `DateTime.IsNoTarget()`
- `DateTime.IsClockStopped()`

Example:

```csharp
DateTime targetAt = request.TargetAt;

if (targetAt.IsBestEffort())
{
    // handle best_effort
}
```

### Enum serialization helper

All SDK value enums have a serialized Xurrent value that differs from the enum member name. The `ToXurrentString()` extension returns the value as used by the Xurrent API.

- If a serialized value is defined, it is returned.
- Otherwise, the enum member name is returned.

Example:
```csharp
RequestImpact impact = RequestImpact.Medium;
string value = impact.ToXurrentString();
```

### Custom field helpers

Custom fields are exposed as a dictionary keyed by the custom field identifier. Accessing a custom field is done via `TryGetValue`, which encapsulates both key existence and value retrieval.

- If the key does not exist, `TryGetValue` returns `false`.
- If the key exists, it returns `true` and provides a `CustomField` instance.
- The `CustomField` still contains its value as a `JsonElement`, allowing typed access via `JsonElement` extension methods.

Example:

```
Request request = new Request();

if (request.CustomFields.TryGetValue("key", out CustomField? customField))
{
    JsonElement value = customField.Value;
    // read the value using JsonElement APIs or extension methods
}
```

To assign values, primitive types and enums can be converted to `JsonElement` using the provided helpers:

    request.CustomFields["key"] = "test".ToJsonElement();

This approach avoids manual JSON construction, provides safe access when keys are missing, and keeps custom field handling explicit and predictable.

## Exception Handling

The SDK defines a small hierarchy of exceptions to distinguish between different failure scenarios and make error handling more precise.

- **XurrentException**  
  The base exception type for all errors raised by the SDK.
 When the error originates from an HTTP request, the exception includes HTTP-level details and, when available, the raw JSON response returned by the Xurrent API.

- **XurrentQueryException**  
  Thrown when a query is constructed in an invalid way. Although the SDK uses strong typing, certain invalid combinations or configurations can only be detected at runtime. In those cases, the SDK fails fast by throwing this exception before issuing the API request.

Consumers can catch `XurrentException` to handle all SDK-related errors, or catch the more specific derived exceptions to react differently to query construction errors versus API execution failures.

## Special timestamps

The Xurrent REST API defines a custom `ISO8601Timestamp` type that, in addition to normal date-time values, can represent three special states: `best_effort`, `no_target`, and `clock_stopped`. These values are not valid ISO 8601 date-time representations and therefore cannot be mapped directly to standard `DateTime` values.

To support these cases, the SDK includes a custom JSON converter that maps each special value to a reserved `DateTime` instance:

- `best_effort` maps to `0001-01-01 01:01:01.111`
- `no_target` maps to `0002-02-02 02:02:02.222`
- `clock_stopped` maps to `0003-03-03 03:03:03.333`

These mappings are exposed as predefined `SpecialTimestamp` values under `Works4me.Xurrent.Rest.SpecialTimestamps`.

The `SpecialTimestamps` helper also provides lookup dictionaries to convert between the textual API values and their corresponding `DateTime` representations. This enables reliable detection and comparison of these special timestamp values when working with Xurrent data in application logic.

For convenience, the SDK also exposes extension methods on DateTime to detect these special values:

- `DateTime.IsBestEffort()`
- `DateTime.IsNoTarget()`
- `DateTime.IsClockStopped()`

This allows special timestamp values to be identified and handled explicitly in application logic without comparing raw DateTime values.

## Client behavior and limits

This section describes how the client handles authentication tokens, rate limiting, request pacing, and logging.

### Multiple authentication tokens

The client supports the use of multiple authentication tokens. Each token is limited to 3600 API requests per hour. In scenarios with higher throughput requirements, multiple tokens can be configured.

When multiple tokens are available, the client automatically selects the token with the highest number of remaining requests.

For more information on rate limits, see the [Xurrent Developer Pages](https://developer.xurrent.com/v1/#rate-limiting).

### Rate and cost limits

Each `AuthenticationToken` exposes its live rate-limit counters after it has been used for the first query or mutation.

Available counters:

- **`AuthenticationToken.RequestLimit.Limit`**  
  The maximum number of requests allowed in a rolling 60-minute window.

- **`AuthenticationToken.RequestLimit.Remaining`**  
  The number of requests still available in the current window.

- **`AuthenticationToken.RequestLimit.Reset`**  
  The timestamp at which the current rate-limit window resets.

Example configuration using multiple tokens:

```csharp
AuthenticationTokenCollection tokens = new AuthenticationTokenCollection()
{
    new("TestPersonalAccessToken"),
    new("App1_ClientId", "App1_ClientSecret"),
    new("App2_ClientId", "App2_ClientSecret")
};

XurrentClient xurrentClient = new XurrentClient(tokens, "account-id", EnvironmentType.Quality, EnvironmentRegion.EU);
```

Inspecting rate-limit counters for a token:
```csharp
AuthenticationToken token = new AuthenticationToken("My Personal Access Token");

Console.WriteLine("Request limits");
Console.WriteLine($"  Limit     : {token.RequestLimit.Limit}");
Console.WriteLine($"  Remaining : {token.RequestLimit.Remaining}");
Console.WriteLine($"  Reset     : {token.RequestLimit.Reset:f}");
```

### Request pacing

In addition to hourly limits, the Xurrent REST API enforces a short-term request pacing limit of 20 requests per 2 seconds.

The SDK tracks request timing per authentication token and ensures these limits are not exceeded. Tokens must represent distinct users or applications in Xurrent for pacing and rate limits to be applied independently.

### Logging

All request and response details are logged using `ILogger` as structured `XurrentTraceMessage` entries.

Any standard .NET logging provider can be used, including console, file-based logging, Seq, or Application Insights.

For each HTTP operation, the SDK emits two log entries sharing the same unique identifier:

- A request entry containing the account ID, HTTP method, URL, and request payload.
- A response entry containing the HTTP status code, response time in milliseconds, and optional retry delay.

All log entries are structured and include contextual metadata via the `XurrentTraceMessage` type.

Example output:

```json
{"id":"7023a929-a3c7-46ea-b1d8-27357730a25a","method":"POST","uri":"https://oauth.xurrent.qa/token","content":"***"}
{"id":"7023a929-a3c7-46ea-b1d8-27357730a25a","response_code":200,"response_time_in_ms":391,"retry_after_in_ms":0}

{"id":"3d855586-5789-4bb7-864f-aef74d8e70db","method":"GET","uri":"https://api.xurrent.qa/v1/cis/?per_page=20","account_id":"account-id","content":null}
{"id":"3d855586-5789-4bb7-864f-aef74d8e70db","response_code":200,"response_time_in_ms":259,"retry_after_in_ms":0}

{"id":"24f3e7ed-b92f-48e8-b41c-cb24462a346f","method":"GET","uri":"https://api.4me.qa/v1/cis?per_page=20&search_after=eyJvZmZzZXQiOjE5LCJjdXJzb3IiOlsi4Zyh4YiE5omi44Sx5aCI44CE4aCAXHUwMDAxIiwxODA3XX0%3D","account_id":"account-id","content":null}
{"id":"24f3e7ed-b92f-48e8-b41c-cb24462a346f","response_code":200,"response_time_in_ms":280,"retry_after_in_ms":0}
```

# Xurrent REST .NET SDK

This SDK simplifies integration with the Xurrent REST API by abstracting HTTP request construction, JSON serialization and deserialization, and connection data retrieval. It exposes a set of fluent, strongly-typed classes so you can build REST operations with minimal boilerplate.

Under the covers, it manages rate-limit compliance, token renewal, and optimized handling of large result sets, allowing you to focus on application logic and business requirements.

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


## Getting Started

### Query Example

```csharp
using Works4me.Xurrent.Rest;;

AuthenticationToken token = new("ClientId", "ClientSecret");
XurrentClient client = new(token, "account-id", EnvironmentType.Demo, EnvironmentRegion.EU);

PersonQuery query = new()
    .Select(Person.Field.Id, Person.Field.Name, Person.Field.PrimaryEmail)
    .Where(Person.FilterField.Disabled, FilterOperator.Equality, false);
                    
ReadOnlyKeyedDataCollection<Person> people = await client.People.GetAsync(query).ConfigureAwait(false);
```

### Mutation Example

```csharp
using Works4me.Xurrent.Rest;

AuthenticationToken token = new("ClientId", "ClientSecret");
XurrentClient client = new(token, "account-id", EnvironmentType.Demo, EnvironmentRegion.EU);

try
{
    Person updatePerson = new()
    {
        Id = 6,
        Name = "Howard Tanner",
        PrimaryEmail = "howard.tanner@widget.com"
    };

    updatePerson = await client.People.UpdateAsync(updatePerson).ConfigureAwait(false);
}
catch (XurrentException ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
    Console.WriteLine($"Raw response data: {ex.RawBody}");                  
}
```

## Documentation

For detailed usage, please refer to the following resources:
- Full [Xurrent REST API Documentation](https://developer.xurrent.com/v1).
- Additional examples and usage details in the [GitHub README](https://github.com/klaasvandeweerdt/works4me-xurrent-rest).
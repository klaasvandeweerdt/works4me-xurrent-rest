using System;
using System.Collections.Generic;
using System.Text.Json;
using Works4me.Xurrent.Rest.Serialization;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Builder for creating request event input objects for Xurrent REST API.
    /// Only fields with non-null and meaningful values will be added to the serialized request.
    /// </summary>
    public sealed class RequestEventCreateInput
    {
        private readonly Dictionary<string, object> eventRequestProperties = new();

        /// <summary>
        /// Sets the category of the request.
        /// </summary>
        /// <param name="requestCategory">The request category. See <see cref="RequestCategory"/> for available values.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Category(RequestCategory requestCategory)
        {
            AddToRequest("category", requestCategory);
            return this;
        }

        /// <summary>
        /// Sets the configuration item related to the request by its label or name.
        /// </summary>
        /// <param name="labelOrName">The label or name of the configuration item to relate to the request.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput ConfigurationItem(string labelOrName)
        {
            AddToRequest("ci", labelOrName);
            return this;
        }

        /// <summary>
        /// Sets the configuration item related to the request by its REST API identifier.
        /// </summary>
        /// <param name="id">The REST API identifier of the configuration item.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput ConfigurationItem(long id)
        {
            AddToRequest("ci_id", id);
            return this;
        }

        /// <summary>
        /// Sets the configuration item related to the request by its source and source identifier.
        /// </summary>
        /// <param name="source">The source of the configuration item.</param>
        /// <param name="sourceID">The source identifier of the configuration item.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput ConfigurationItem(string source, string sourceID)
        {
            AddToRequest("ci_source", source, "ci_sourceID", sourceID);
            return this;
        }

        /// <summary>
        /// Sets the configuration item related to the request using a <see cref="Rest.ConfigurationItem"/> object.<br />
        /// </summary>
        /// <param name="configurationItem">The configuration item to relate to the request.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput ConfigurationItem(ConfigurationItem configurationItem)
        {
            if (configurationItem is not null)
            {
                if (configurationItem.Id != 0)
                    AddToRequest("ci_id", configurationItem);
                else
                    AddToRequest("ci_source", configurationItem.Source, "ci_sourceID", configurationItem.SourceID);
            }
            return this;
        }

        /// <summary>
        /// Sets the completion reason for the request.
        /// </summary>
        /// <param name="reason">The completion reason. See <see cref="RequestCompletionReason"/> for available values.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput CompletionReason(RequestCompletionReason reason)
        {
            AddToRequest("completion_reason", reason);
            return this;
        }

        /// <summary>
        /// Sets the desired completion date and time for the request.
        /// </summary>
        /// <param name="desiredCompletionAt">The desired completion <see cref="DateTime"/> for the request.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput DesiredCompletionAt(DateTime desiredCompletionAt)
        {
            AddToRequest("desired_completion_at", desiredCompletionAt);
            return this;
        }

        /// <summary>
        /// Sets the end date and time of a service outage for the request.
        /// </summary>
        /// <param name="downtimeEndAt">The end <see cref="DateTime"/> of the service outage.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput DownTimeEndAt(DateTime downtimeEndAt)
        {
            AddToRequest("downtime_end_at", downtimeEndAt);
            return this;
        }

        /// <summary>
        /// Sets the start date and time of a service outage for the request.
        /// </summary>
        /// <param name="downtimeStartAt">The start <see cref="DateTime"/> of the service outage.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput DownTimeStartAt(DateTime downtimeStartAt)
        {
            AddToRequest("downtime_start_at", downtimeStartAt);
            return this;
        }

        /// <summary>
        /// Sets the impact of the request.
        /// </summary>
        /// <param name="requestImpact">The impact value. See <see cref="RequestImpact"/> for available options.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Impact(RequestImpact requestImpact)
        {
            AddToRequest("impact", requestImpact);
            return this;
        }

        /// <summary>
        /// Adds an internal note to the request.
        /// </summary>
        /// <param name="text">The text of the internal note.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput InternalNote(string text)
        {
            AddToRequest("internal_note", text);
            return this;
        }

        /// <summary>
        /// Sets the member (person) to which the request is assigned by primary email address.
        /// </summary>
        /// <param name="primaryEmailAddress">The primary email address of the person to assign.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Member(string primaryEmailAddress)
        {
            AddToRequest("member", primaryEmailAddress);
            return this;
        }

        /// <summary>
        /// Sets the member (person) to which the request is assigned by REST API identifier.
        /// </summary>
        /// <param name="id">The REST API identifier of the person to assign.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Member(long id)
        {
            AddToRequest("member_id", id);
            return this;
        }

        /// <summary>
        /// Sets the member (person) to which the request is assigned using a <see cref="Person"/> object.<br />
        /// </summary>
        /// <param name="person">The person to assign.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Member(Person person)
        {
            if (person is not null)
            {
                if (person.Id != 0)
                    AddToRequest("member_id", person);
                else
                    AddToRequest("member", person.PrimaryEmail);
            }
            return this;
        }

        /// <summary>
        /// Adds a note to the request.
        /// </summary>
        /// <param name="text">The text of the note.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Note(string text)
        {
            AddToRequest("note", text);
            return this;
        }

        /// <summary>
        /// Sets the problem related to the request by its REST API identifier.
        /// </summary>
        /// <param name="id">The REST API identifier of the problem.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Problem(long id)
        {
            AddToRequest("problem_id", id);
            return this;
        }

        /// <summary>
        /// Sets the problem related to the request using a <see cref="Rest.Problem"/> object.
        /// </summary>
        /// <param name="problem">The problem to relate to the request.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Problem(Problem problem)
        {
            AddToRequest("problem_id", problem);
            return this;
        }

        /// <summary>
        /// Sets the person who is selected in the "requested by" field by primary email address.
        /// </summary>
        /// <param name="primaryEmailAddress">The primary email address of the person.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput RequestedBy(string primaryEmailAddress)
        {
            AddToRequest("requested_by", primaryEmailAddress);
            return this;
        }

        /// <summary>
        /// Sets the person who is selected in the "requested by" field by REST API identifier.
        /// </summary>
        /// <param name="id">The REST API identifier of the person.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput RequestedBy(long id)
        {
            AddToRequest("requested_by_id", id);
            return this;
        }

        /// <summary>
        /// Sets the person who is selected in the "requested by" field using a <see cref="Person"/> object.
        /// </summary>
        /// <param name="person">The person to set as \"requested by\".</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput RequestedBy(Person person)
        {
            if (person is not null)
            {
                if (person.Id != 0)
                    AddToRequest("requested_by_id", person);
                else
                    AddToRequest("requested_by", person.PrimaryEmail);
            }
            return this;
        }

        /// <summary>
        /// Sets the person who is selected in the "requested for" field by REST API identifier.
        /// </summary>
        /// <param name="id">The REST API identifier of the person.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput RequestedFor(long id)
        {
            AddToRequest("requested_for_id", id);
            return this;
        }

        /// <summary>
        /// Sets the person who is selected in the "requested for" field by primary email address.
        /// </summary>
        /// <param name="primaryEmailAddress">The primary email address of the person.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput RequestedFor(string primaryEmailAddress)
        {
            AddToRequest("requested_for", primaryEmailAddress);
            return this;
        }

        /// <summary>
        /// Sets the person who is selected in the "requested for" field using a <see cref="Person"/> object.
        /// </summary>
        /// <param name="person">The person to set as "requested for".</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput RequestedFor(Person person)
        {
            if (person is not null)
            {
                if (person.Id != 0)
                    AddToRequest("requested_for_id", person);
                else
                    AddToRequest("requested_for", person.PrimaryEmail);
            }
            return this;
        }

        /// <summary>
        /// Sets the service instance related to the request by its REST API identifier.
        /// </summary>
        /// <param name="id">The REST API identifier of the service instance.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput ServiceInstance(long id)
        {
            AddToRequest("service_instance_id", id);
            return this;
        }

        /// <summary>
        /// Sets the service instance related to the request by its name.
        /// </summary>
        /// <param name="name">The name of the service instance.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput ServiceInstance(string name)
        {
            AddToRequest("service_instance", name);
            return this;
        }

        /// <summary>
        /// Sets the service instance related to the request using a <see cref="Rest.ServiceInstance"/> object.
        /// </summary>
        /// <param name="serviceInstance">The service instance to relate to the request.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput ServiceInstance(ServiceInstance serviceInstance)
        {
            if (serviceInstance is not null)
            {
                if (serviceInstance.Id != 0)
                    AddToRequest("service_instance_id", serviceInstance);
                else
                    AddToRequest("service_instance", serviceInstance.Name);
            }
            return this;
        }


        /// <summary>
        /// Sets the source name for the request, typically identifying the monitoring tool or integration source.
        /// </summary>
        /// <param name="source">The source identifier.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Source(string source)
        {
            AddToRequest("source", source);
            return this;
        }

        /// <summary>
        /// Sets the unique source identifier for the event associated with the request.
        /// </summary>
        /// <param name="sourceID">The unique source identifier.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput SourceID(string sourceID)
        {
            AddToRequest("sourceID", sourceID);
            return this;
        }

        /// <summary>
        /// Sets the status of the request.
        /// </summary>
        /// <param name="status">
        /// The status of the request. See <see cref="RequestStatus"/> for available values.
        /// </param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Status(RequestStatus status)
        {
            AddToRequest("status", status);
            return this;
        }

        /// <summary>
        /// Sets the subject of the request.
        /// </summary>
        /// <param name="subject">The subject or title of the request.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Subject(string subject)
        {
            AddToRequest("subject", subject);
            return this;
        }

        /// <summary>
        /// Sets the supplier organization related to the request by its REST API identifier.
        /// </summary>
        /// <param name="id">The REST API identifier of the supplier organization.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Supplier(long id)
        {
            AddToRequest("supplier_id", id);
            return this;
        }

        /// <summary>
        /// Sets the supplier organization related to the request by its name.
        /// </summary>
        /// <param name="name">The name of the supplier organization.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Supplier(string name)
        {
            AddToRequest("supplier", name);
            return this;
        }

        /// <summary>
        /// Sets the supplier organization related to the request using a <see cref="Organization"/> object.
        /// </summary>
        /// <param name="supplier">The supplier organization.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Supplier(Organization supplier)
        {
            if (supplier is not null)
            {
                if (supplier.Id != 0)
                    AddToRequest("supplier_id", supplier);
                else
                    AddToRequest("supplier", supplier.Name);
            }
            return this;
        }


        /// <summary>
        /// Sets the support domain account for the request by its identifier.
        /// </summary>
        /// <param name="supportDomain">The identifier of the support domain account.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput SupportDomain(string supportDomain)
        {
            AddToRequest("support_domain", supportDomain);
            return this;
        }

        /// <summary>
        /// Sets the support domain account for the request using an <see cref="Account"/> object.
        /// </summary>
        /// <param name="supportDomain">The <see cref="Account"/> representing the support domain.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput SupportDomain(Account supportDomain)
        {
            AddToRequest("support_domain", supportDomain?.Id);
            return this;
        }

        /// <summary>
        /// Sets the team to which the request is assigned by its REST API identifier.
        /// </summary>
        /// <param name="id">The REST API identifier of the team.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Team(long id)
        {
            AddToRequest("team_id", id);
            return this;
        }

        /// <summary>
        /// Sets the team to which the request is assigned by its name.
        /// </summary>
        /// <param name="name">The name of the team.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Team(string name)
        {
            AddToRequest("team", name);
            return this;
        }

        /// <summary>
        /// Sets the team to which the request is assigned using a <see cref="Rest.Team"/> object.
        /// </summary>
        /// <param name="team">The team to assign the request to.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Team(Team team)
        {
            if (team is not null)
            {
                if (team.Id != 0)
                    AddToRequest("team_id", team);
                else
                    AddToRequest("team", team.Name);
            }
            return this;
        }

        /// <summary>
        /// Sets the request template to be applied to the request by its REST API identifier.
        /// </summary>
        /// <param name="id">The REST API identifier of the request template.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput RequestTemplate(long id)
        {
            AddToRequest("template_id", id);
            return this;
        }

        /// <summary>
        /// Sets the request template to be applied to the request using a <see cref="Rest.RequestTemplate"/> object.
        /// </summary>
        /// <param name="requestTemplate">The <see cref="Rest.RequestTemplate"/> to apply.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput RequestTemplate(RequestTemplate requestTemplate)
        {
            AddToRequest("template_id", requestTemplate);
            return this;
        }

        /// <summary>
        /// Sets the date and time until which the request will remain in the waiting state.
        /// </summary>
        /// <param name="waitingUntil">The <see cref="DateTime"/> until which the request waits.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput WaitingUntil(DateTime waitingUntil)
        {
            AddToRequest("waiting_until", waitingUntil);
            return this;
        }

        /// <summary>
        /// Sets the workflow related to the request by its REST API identifier.
        /// </summary>
        /// <param name="id">The REST API identifier of the workflow.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Workflow(long id)
        {
            AddToRequest("workflow_id", id);
            return this;
        }

        /// <summary>
        /// Sets the workflow related to the request using a <see cref="Rest.Workflow"/> object.
        /// </summary>
        /// <param name="workflow">The <see cref="Rest.Workflow"/> to relate to the request.</param>
        /// <returns>The current <see cref="RequestEventCreateInput"/> instance for method chaining.</returns>
        public RequestEventCreateInput Workflow(Workflow workflow)
        {
            AddToRequest("workflow_id", workflow);
            return this;
        }

        /// <summary>
        /// Serializes the set request properties to a JSON string suitable for use as the HTTP request body.
        /// </summary>
        /// <returns>A JSON string representing the current request event input.</returns>

        public string GetHttpRequestBody()
        {
            return JsonSerializer.Serialize(eventRequestProperties, SerializationConfiguration.CreateJsonOptions());
        }

        /// <summary>
        /// Adds a single key-value pair to the request properties if both the key and value are not null or empty.
        /// </summary>
        /// <param name="key">The property key.</param>
        /// <param name="value">The property value.</param>
        private void AddToRequest(string key, object? value)
        {
            if (!string.IsNullOrWhiteSpace(key) && value is not null)
                eventRequestProperties[key] = value;
        }

        /// <summary>
        /// Adds a single key-value pair to the request properties using an <see cref="IRecord"/> object if both the key and the node identifier are not null or empty.
        /// </summary>
        /// <param name="key">The property key.</param>
        /// <param name="value">The <see cref="IRecord"/> value to add, whose identifier will be used as the value.</param>
        private void AddToRequest(string key, IRecord value)
        {
            if (value is not null && value.Id != 0)
                eventRequestProperties[key] = value;
        }

        /// <summary>
        /// Adds two related key-value pairs to the request properties if all keys and values are not null or empty.
        /// </summary>
        /// <param name="sourceKey">The key for the source value.</param>
        /// <param name="sourceValue">The source value.</param>
        /// <param name="sourceIdKey">The key for the source ID value.</param>
        /// <param name="sourceIdvalue">The source ID value.</param>
        private void AddToRequest(string sourceKey, string? sourceValue, string sourceIdKey, string? sourceIdvalue)
        {
            if (!string.IsNullOrWhiteSpace(sourceKey) && !string.IsNullOrWhiteSpace(sourceValue) && !string.IsNullOrWhiteSpace(sourceIdKey) && !string.IsNullOrWhiteSpace(sourceIdvalue))
            {
                eventRequestProperties[sourceKey] = sourceValue!;
                eventRequestProperties[sourceIdKey] = sourceIdvalue!;
            }
        }
    }
}

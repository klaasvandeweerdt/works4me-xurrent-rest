using System.Text.Json;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a single custom field and its associated value.
    /// </summary>
    public sealed class CustomField
    {
        /// <summary>
        /// Gets or sets the identifier of the custom field.
        /// </summary>
        [XurrentField("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the value of the custom field.
        /// </summary>
        [XurrentField("value")]
        public JsonElement? Value { get; set; }

        /// <summary>
        /// Creates a new custom field instance.
        /// </summary>
        public CustomField()
        {
        }


        /// <summary>
        /// Creates a new custom field instance.
        /// </summary>
        /// <param name="id">The identifier of the custom field.</param>
        /// <param name="value">The value of the custom field.</param>
        public CustomField(string id, JsonElement? value)
        {
            Id = id;
            Value = value;
        }
    }
}

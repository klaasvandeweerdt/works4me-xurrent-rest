using System;

namespace Works4me.Xurrent.Rest.Attributes
{
    /// <summary>
    /// Specifies a custom value for an enum member.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    internal sealed class XurrentEnumAttribute : Attribute
    {
        /// <summary>
        /// Gets the value to use in API requests.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Excluded the property from the Xurrent API field selection.
        /// </summary>
        public bool IgnoreInFieldSelection { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentEnumAttribute"/> class.
        /// </summary>
        /// <param name="value">The value to use for this member.</param>
        public XurrentEnumAttribute(string value)
        {
            Value = value;
        }
    }
}

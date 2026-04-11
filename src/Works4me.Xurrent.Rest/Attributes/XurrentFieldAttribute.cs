using System;

namespace Works4me.Xurrent.Rest.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal sealed class XurrentFieldAttribute : Attribute
    {
        /// <summary>
        /// Gets the Xurrent API field name to which this property maps.
        /// </summary>
        public string FieldName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentFieldAttribute"/> class.
        /// </summary>
        /// <param name="fieldName">The name of the field in the Xurrent API schema to which this property maps.</param>
        public XurrentFieldAttribute(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}

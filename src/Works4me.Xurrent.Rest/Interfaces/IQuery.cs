using System.Collections.Generic;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Defines the structure of a query used to request filtered, ordered, or field-restricted data from the Xurrent REST API.</summary>
    internal interface IQuery
    {
        /// <summary>
        /// Gets the identifier filter, if specified.
        /// </summary>
        /// <value>A <see cref="long"/> representing the identifier to filter on, or <see langword="null"/> if no identifier filter was requested.</value>
        long? Id { get; }

        /// <summary>
        /// Gets the predefined filter, if specified.
        /// </summary>
        /// <value>A <see cref="string"/> containing the name of the predefined filter, or <see langword="null"/> if no predefined filter was selected.</value>
        string? PredefinedFilter { get; }

        /// <summary>
        /// Gets the maximum number of items returned per request, if specified.
        /// </summary>
        /// <value>An <see cref="int"/> representing the page size for the query, or <see langword="null"/> if no limit was defined.</value>
        int? ItemsPerRequest { get; }

        /// <summary>
        /// Gets the list of values used for ordering the results.
        /// </summary>
        /// <value>
        /// An <see cref="IReadOnlyList{T}"/> of <see cref="string"/> values representing the sort order for the query. <br />
        /// The list may be empty.
        /// </value>        
        IReadOnlyList<string> OrderBy { get; }

        /// <summary>
        /// Gets the list of field names selected in the query.
        /// </summary>
        /// <value>
        /// An <see cref="IReadOnlyList{T}"/> of <see cref="string"/> values specifying which fields should be included in the response.<br/>
        /// The list may be empty, indicating that all default fields are returned.
        /// </value>
        IReadOnlyList<string> Fields { get; }

        /// <summary>
        /// Gets the list of filters applied to the query.
        /// </summary>
        /// <value>
        /// An <see cref="IReadOnlyList{T}"/> of <see cref="string"/> values representing additional field-based filters. <br />  
        /// The list may be empty when no extra filters were provided.
        /// </value>
        IReadOnlyList<string> Filters { get; }
    }
}

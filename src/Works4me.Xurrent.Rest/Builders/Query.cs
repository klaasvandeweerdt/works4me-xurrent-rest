using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Works4me.Xurrent.Rest.Attributes;
using Works4me.Xurrent.Rest.Extensions;
using Works4me.Xurrent.Rest.Utilities;

namespace Works4me.Xurrent.Rest.Builders
{
    /// <summary>
    /// Fluent query base class used to compose REST query parameters. <br />
    /// Supports selecting fields, applying predefined filters, adding where clauses, paging, and sort definitions in a type-safe manner.
    /// </summary>
    public abstract class Query<TQueryEntity, TPredefinedFilter, TField, TFilterField, TOrderByField> : IQuery
        where TQueryEntity : Query<TQueryEntity, TPredefinedFilter, TField, TFilterField, TOrderByField>
        where TField : struct, Enum
        where TPredefinedFilter : struct, Enum
        where TFilterField : struct, Enum
        where TOrderByField : struct, Enum
    {
        /// <summary>
        /// Gets the current instance cast to the concrete query type.
        /// </summary>
        protected TQueryEntity Self => (TQueryEntity)this;

        private long? _id;
        private string? _predefinedFilter;
        private int? _itemPerRequest;
        private readonly HashSet<string> _orderBy = new();
        private readonly HashSet<string> _fields = new();
        private readonly HashSet<string> _filters = new();

        /// <inheritdoc/>
        long? IQuery.Id
        {
            get => _id;
        }

        /// <inheritdoc/>
        string? IQuery.PredefinedFilter
        {
            get => _predefinedFilter;
        }

        /// <inheritdoc/>
        IReadOnlyList<string> IQuery.OrderBy
        {
            get => _orderBy.ToList();
        }

        /// <inheritdoc/>
        int? IQuery.ItemsPerRequest
        {
            get => _itemPerRequest;
        }

        /// <inheritdoc/>
        IReadOnlyList<string> IQuery.Fields
        {
            get => _fields.ToList();
        }


        /// <inheritdoc/>
        public IReadOnlyList<string> Filters
        {
            get => _filters.ToList();
        }

        /// <summary>
        /// Adds one or more fields to the selection list using raw field names.
        /// </summary>
        /// <param name="fields">The field names to select.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="fields"/> is null.</exception>
        /// <exception cref="XurrentQueryException">Thrown when a field cannot be converted to a valid <typeparamref name="TField"/> value.</exception>
        public TQueryEntity Select(params string[] fields)
        {
            if (fields is null)
                throw new ArgumentNullException(nameof(fields));

            foreach (string field in fields)
            {
                if (Constants.DefaultFields.Contains(field))
                    continue;

                if (!field.TryGetXurrentEnumAttribute<TField>(out XurrentEnumAttribute? attribute))
                    throw new XurrentQueryException($"'{field}' could not be converted to a {typeof(TField).Name} value.");

                if (attribute is not null && !attribute.IgnoreInFieldSelection)
                    _fields.Add(field);
            }
            return Self;
        }

        /// <summary>
        /// Adds one or more fields to the selection list using enum values.
        /// </summary>
        /// <param name="fields">The fields to select.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="fields"/> is null.</exception>
        /// <exception cref="XurrentQueryException">Thrown when a field does not define a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity Select(params TField[] fields)
        {
            if (fields is null)
                throw new ArgumentNullException(nameof(fields));

            foreach (TField field in fields)
            {
                if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                    throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

                if (attribute is not null && !attribute.IgnoreInFieldSelection)
                    _fields.Add(attribute.Value);
            }
            return Self;
        }

        /// <summary>
        /// Selects all fields defined by <typeparamref name="TField"/> that are not marked as ignored.
        /// </summary>
        /// <remarks>
        /// <b>Warning:</b> This method will significantly impact performance.<br />
        /// It is intended for debugging or testing purposes. Using this method in production may fail if certain fields do not yet exist in the production schema.<br />
        /// </remarks>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when a field does not define a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity SelectAll()
        {
            Array fields = typeof(TField).GetEnumValues();
            foreach (TField field in fields)
            {
                if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                    throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

                if (attribute is not null && !attribute.IgnoreInFieldSelection)
                    _fields.Add(attribute.Value);
            }
            return Self;
        }

        /// <summary>
        /// Filters the query to a single entity identifier.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when an identifier filter is already set or when <paramref name="id"/> is invalid.</exception>
        public TQueryEntity WithId(long id)
        {
            if (_id is not null)
                throw new XurrentQueryException($"An identifier filter has already been applied. '{nameof(WithId)}' may only be called once per query.");

            if (id < 1)
                throw new XurrentQueryException($"Invalid identifier: {id}. {nameof(WithId)} must be greater than zero.");

            _id = id;
            return Self;
        }

        /// <summary>
        /// Applies a predefined filter using an enum value.
        /// </summary>
        /// <param name="predefinedFilter">The predefined filter to apply.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when a predefined filter is already set or when the enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity PredefinedFilter(TPredefinedFilter predefinedFilter)
        {
            if (_predefinedFilter is not null)
                throw new XurrentQueryException($"A predefined filter has already been applied. '{nameof(PredefinedFilter)}' may only be called once per query.");

            if (!predefinedFilter.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                throw new XurrentQueryException($"The enum value '{predefinedFilter}' of type '{typeof(TPredefinedFilter).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

            if (!string.IsNullOrWhiteSpace(attribute!.Value))
                _predefinedFilter = attribute!.Value;

            return Self;
        }

        /// <summary>
        /// Applies a predefined filter using its raw string value.
        /// </summary>
        /// <param name="predefinedFilter">The predefined filter value.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when a predefined filter is already set or when the value is not valid for <typeparamref name="TPredefinedFilter"/>.</exception>
        public TQueryEntity PredefinedFilter(string predefinedFilter)
        {
            if (_predefinedFilter is not null)
                throw new XurrentQueryException($"A predefined filter has already been applied. '{nameof(PredefinedFilter)}' may only be called once per query.");

            if (!predefinedFilter.TryGetXurrentEnumAttribute<TPredefinedFilter>(out _))
                throw new XurrentQueryException($"'{predefinedFilter}' could not be converted to a {typeof(TPredefinedFilter).Name} value.");

            if (!string.IsNullOrWhiteSpace(predefinedFilter))
                _predefinedFilter = predefinedFilter;

            return Self;
        }

        /// <summary>
        /// Adds a sort definition using an enum field and sort order.
        /// </summary>
        /// <param name="field">The sort field.</param>
        /// <param name="sortOrder">The sort order to apply.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity OrderBy(TOrderByField field, SortOrder sortOrder)
        {
            if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TOrderByField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

            if (!string.IsNullOrWhiteSpace(attribute!.Value))
                _orderBy.Add(FormatOrderBy(attribute!.Value, sortOrder));

            return Self;
        }

        /// <summary>
        /// Adds a sort definition using a raw field name and sort order.
        /// </summary>
        /// <param name="field">The sort field name.</param>
        /// <param name="sortOrder">The sort order to apply.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the value is not valid for <typeparamref name="TOrderByField"/>.</exception>
        public TQueryEntity OrderBy(string field, SortOrder sortOrder)
        {
            if (!field.TryGetXurrentEnumAttribute<TOrderByField>(out _))
                throw new XurrentQueryException($"'{field}' could not be converted to a {typeof(TOrderByField).Name} value.");

            if (!string.IsNullOrWhiteSpace(field))
                _orderBy.Add(FormatOrderBy(field, sortOrder));

            return Self;
        }

        /// <summary>
        /// Sets the number of items to request per page.
        /// </summary>
        /// <param name="value">The items-per-request value.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when <paramref name="value"/> is outside the allowed range.</exception>
        public TQueryEntity ItemsPerRequest(int value)
        {
            if (value < 1 || value > 100)
                throw new XurrentQueryException($"Invalid items per request value: {value}. {nameof(ItemsPerRequest)} must be between 1 and 100 inclusive.");

            _itemPerRequest = value;
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using an enum field and operator, without explicit values.
        /// </summary>
        /// <param name="field">The filter field.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity Where(TFilterField field, FilterOperator @operator)
        {
            if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TFilterField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

            AddFilter(attribute!.Value, @operator);
            return Self;
        }


        /// <summary>
        /// Adds a filter clause using a raw field name and operator, without explicit values.
        /// </summary>
        /// <param name="field">The filter field name.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the value is not valid for <typeparamref name="TFilterField"/>.</exception>
        public TQueryEntity Where(string field, FilterOperator @operator)
        {
            if (!field.TryGetXurrentEnumAttribute<TFilterField>(out _))
                throw new XurrentQueryException($"'{field}' could not be converted to a {typeof(TFilterField).Name} value.");

            AddFilter(field, @operator);
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using an enum field, operator, and string value.
        /// </summary>
        /// <param name="field">The filter field.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="value">The value to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity Where(TFilterField field, FilterOperator @operator, string value)
        {
            if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TFilterField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

            AddFilter(attribute!.Value, @operator, Uri.EscapeDataString(value));
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using a raw field name, operator, and string value.
        /// </summary>
        /// <param name="field">The filter field name.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="value">The value to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the value is not valid for <typeparamref name="TFilterField"/>.</exception>
        public TQueryEntity Where(string field, FilterOperator @operator, string value)
        {
            if (!field.TryGetXurrentEnumAttribute<TFilterField>(out _))
                throw new XurrentQueryException($"'{field}' could not be converted to a {typeof(TFilterField).Name} value.");

            AddFilter(field, @operator, Uri.EscapeDataString(value));
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using an enum field, operator, and date/time value.
        /// </summary>
        /// <param name="field">The filter field.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="value">The value to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity Where(TFilterField field, FilterOperator @operator, DateTime value)
        {
            if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TFilterField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

            AddFilter(attribute!.Value, @operator, Uri.EscapeDataString(value.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture)));
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using a raw field name, operator, and date/time value.
        /// </summary>
        /// <param name="field">The filter field name.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="value">The value to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the value is not valid for <typeparamref name="TFilterField"/>.</exception>
        public TQueryEntity Where(string field, FilterOperator @operator, DateTime value)
        {
            if (!field.TryGetXurrentEnumAttribute<TFilterField>(out _))
                throw new XurrentQueryException($"'{field}' could not be converted to a {typeof(TFilterField).Name} value.");

            AddFilter(field, @operator, Uri.EscapeDataString(value.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture)));
            return Self;
        }

        /// <summary>
        /// Adds a range filter clause using an enum field, operator, and two date/time values.
        /// </summary>
        /// <param name="field">The filter field.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity Where(TFilterField field, FilterOperator @operator, DateTime value1, DateTime value2)
        {
            if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TFilterField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

            AddFilter(attribute!.Value,
                @operator,
                Uri.EscapeDataString(value1.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture)),
                Uri.EscapeDataString(value2.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture)));
            return Self;
        }

        /// <summary>
        /// Adds a range filter clause using a raw field name, operator, and two date/time values.
        /// </summary>
        /// <param name="field">The filter field name.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the value is not valid for <typeparamref name="TFilterField"/>.</exception>
        public TQueryEntity Where(string field, FilterOperator @operator, DateTime value1, DateTime value2)
        {
            if (!field.TryGetXurrentEnumAttribute<TFilterField>(out _))
                throw new XurrentQueryException($"'{field}' could not be converted to a {typeof(TFilterField).Name} value.");

            AddFilter(field,
                @operator,
                Uri.EscapeDataString(value1.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture)),
                Uri.EscapeDataString(value2.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture)));
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using an enum field, operator, and record value.
        /// </summary>
        /// <param name="field">The filter field.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="value">The record whose identifier is used as the filter value.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
        /// <exception cref="XurrentQueryException">Thrown when the enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity Where(TFilterField field, FilterOperator @operator, IRecord value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TFilterField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

            AddFilter(attribute!.Value, @operator, value.Id.ToString(CultureInfo.InvariantCulture));
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using a raw field name, operator, and record value.
        /// </summary>
        /// <param name="field">The filter field name.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="value">The record whose identifier is used as the filter value.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
        /// <exception cref="XurrentQueryException">Thrown when the value is not valid for <typeparamref name="TFilterField"/>.</exception>
        public TQueryEntity Where(string field, FilterOperator @operator, IRecord value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            if (!field.TryGetXurrentEnumAttribute<TFilterField>(out _))
                throw new XurrentQueryException($"'{field}' could not be converted to a {typeof(TFilterField).Name} value.");

            AddFilter(field, @operator, value.Id.ToString(CultureInfo.InvariantCulture));
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using an enum field, operator, and boolean value.
        /// </summary>
        /// <param name="field">The filter field.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="value">The boolean value to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity Where(TFilterField field, FilterOperator @operator, bool value)
        {
            if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TFilterField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

            AddFilter(attribute!.Value, @operator, value ? "true" : "false");
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using a raw field name, operator, and boolean value.
        /// </summary>
        /// <param name="field">The filter field name.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="value">The boolean value to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the value is not valid for <typeparamref name="TFilterField"/>.</exception>
        public TQueryEntity Where(string field, FilterOperator @operator, bool value)
        {
            if (!field.TryGetXurrentEnumAttribute<TFilterField>(out _))
                throw new XurrentQueryException($"'{field}' could not be converted to a {typeof(TFilterField).Name} value.");

            AddFilter(field, @operator, value ? "true" : "false");
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using an enum field, operator, and one or more 16-bit integer values.
        /// </summary>
        /// <param name="field">The filter field.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="values">The values to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity Where(TFilterField field, FilterOperator @operator, params short[] values)
        {
            if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TFilterField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

            AddFilter(attribute!.Value, @operator, values.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray());
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using a raw field name, operator, and one or more 16-bit integer values.
        /// </summary>
        /// <param name="field">The filter field name.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="values">The values to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the value is not valid for <typeparamref name="TFilterField"/>.</exception>
        public TQueryEntity Where(string field, FilterOperator @operator, params short[] values)
        {
            if (!field.TryGetXurrentEnumAttribute<TFilterField>(out _))
                throw new XurrentQueryException($"'{field}' could not be converted to a {typeof(TFilterField).Name} value.");

            AddFilter(field, @operator, values.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray());
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using an enum field, operator, and one or more 32-bit integer values.
        /// </summary>
        /// <param name="field">The filter field.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="values">The values to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity Where(TFilterField field, FilterOperator @operator, params int[] values)
        {
            if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TFilterField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

            AddFilter(attribute!.Value, @operator, values.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray());
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using a raw field name, operator, and one or more 32-bit integer values.
        /// </summary>
        /// <param name="field">The filter field name.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="values">The values to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the value is not valid for <typeparamref name="TFilterField"/>.</exception>
        public TQueryEntity Where(string field, FilterOperator @operator, params int[] values)
        {
            if (!field.TryGetXurrentEnumAttribute<TFilterField>(out _))
                throw new XurrentQueryException($"'{field}' could not be converted to a {typeof(TFilterField).Name} value.");

            AddFilter(field, @operator, values.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray());
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using an enum field, operator, and one or more 64-bit integer values.
        /// </summary>
        /// <param name="field">The filter field.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="values">The values to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity Where(TFilterField field, FilterOperator @operator, params long[] values)
        {
            if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TFilterField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

            AddFilter(attribute!.Value, @operator, values.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray());
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using a raw field name, operator, and one or more 64-bit integer values.
        /// </summary>
        /// <param name="field">The filter field name.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="values">The values to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="XurrentQueryException">Thrown when the value is not valid for <typeparamref name="TFilterField"/>.</exception>
        public TQueryEntity Where(string field, FilterOperator @operator, params long[] values)
        {
            if (!field.TryGetXurrentEnumAttribute<TFilterField>(out _))
                throw new XurrentQueryException($"'{field}' could not be converted to a {typeof(TFilterField).Name} value.");

            AddFilter(field, @operator, values.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray());
            return Self;
        }

        /// <summary>
        /// Adds a filter clause using an enum field, operator, and one or more enum values.
        /// </summary>
        /// <param name="field">The filter field.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="values">The enum values to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="values"/> is null.</exception>
        /// <exception cref="XurrentQueryException">Thrown when an enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity Where(TFilterField field, FilterOperator @operator, params Enum[] values)
        {
            if (values is null)
                throw new ArgumentNullException(nameof(values));

            if (!field.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attribute))
                throw new XurrentQueryException($"The enum value '{field}' of type '{typeof(TFilterField).Name}' does not define a {nameof(XurrentEnumAttribute)}.");

            HashSet<string> items = new();
            foreach (Enum enumValue in values)
            {
                if (!enumValue.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? enumAttribute))
                    throw new XurrentQueryException($"The enum value '{enumValue}' of type '{enumValue.GetType().Name}' does not define a {nameof(XurrentEnumAttribute)}.");
                
                items.Add(enumAttribute!.Value);
            }
            AddFilter(attribute!.Value, @operator, items.ToArray());

            return Self;
        }

        /// <summary>
        /// Adds a filter clause using a raw field name, operator, and one or more enum values.
        /// </summary>
        /// <param name="field">The filter field name.</param>
        /// <param name="operator">The operator to apply.</param>
        /// <param name="values">The enum values to filter on.</param>
        /// <returns>The current query instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="values"/> is null.</exception>
        /// <exception cref="XurrentQueryException">Thrown when an enum value lacks a <see cref="XurrentEnumAttribute"/>.</exception>
        public TQueryEntity Where(string field, FilterOperator @operator, params Enum[] values)
        {
            if (values is null)
                throw new ArgumentNullException(nameof(values));

            if (!field.TryGetXurrentEnumAttribute<TFilterField>(out _))
                throw new XurrentQueryException($"'{field}' could not be converted to a {typeof(TFilterField).Name} value.");

            HashSet<string> items = new();
            foreach (Enum enumValue in values)
            {
                if (!enumValue.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? enumAttribute))
                    throw new XurrentQueryException($"The enum value '{enumValue}' of type '{enumValue.GetType().Name}' does not define a {nameof(XurrentEnumAttribute)}.");

                items.Add(enumAttribute!.Value);
            }
            AddFilter(field, @operator, items.ToArray());

            return Self;
        }

        /// <summary>
        /// Adds a filter expression to the query in the format expected by the API. <br />
        /// Validates operator/value cardinality and normalizes filter encoding.
        /// </summary>
        /// <param name="field">The field name to filter on.</param>
        /// <param name="operator">The filter operator to apply.</param>
        /// <param name="values">The values to include in the filter expression.</param>
        /// <exception cref="XurrentQueryException">Thrown when the operator requires a different number of values.</exception>
        private void AddFilter(string field, FilterOperator @operator, params string[] values)
        {
            if (string.IsNullOrEmpty(field))
                return;

            switch (@operator)
            {
                case FilterOperator.GreaterThan:
                    if (values is null || values.Length != 1)
                        throw new XurrentQueryException($"The {@operator} filter requires a single value.");
                    _filters.Add($"{field}=>{values[0]}");
                    break;

                case FilterOperator.GreaterThanOrEqualsTo:
                    if (values is null || values.Length != 1)
                        throw new XurrentQueryException($"The {@operator} filter requires a single value.");
                    _filters.Add($"{field}=>={values[0]}");
                    break;

                case FilterOperator.LessThan:
                    if (values is null || values.Length != 1)
                        throw new XurrentQueryException($"The {@operator} filter requires a single value.");
                    _filters.Add($"{field}=<{values[0]}");
                    break;

                case FilterOperator.LessThanOrEqualsTo:
                    if (values is null || values.Length != 1)
                        throw new XurrentQueryException($"The {@operator} filter requires a single value.");
                    _filters.Add($"{field}=<={values[0]}");
                    break;

                case FilterOperator.GreaterThanAndLessThan:
                    if (values is null || values.Length != 2)
                        throw new XurrentQueryException($"The {@operator} filter requires two value.");
                    _filters.Add($"{field}=>{values[0]}<{values[1]}");
                    break;

                case FilterOperator.GreaterThanOrEqualToAndLessThanOrEqualTo:
                    if (values is null || values.Length != 2)
                        throw new XurrentQueryException($"The {@operator} filter requires two values.");
                    _filters.Add($"{field}=>={values[0]}<={values[1]}");
                    break;

                case FilterOperator.Negation:
                    if (values is null || values.Length != 1)
                        throw new XurrentQueryException($"The {@operator} filter requires a single value.");
                    _filters.Add($"{field}=!{values[0]}");
                    break;

                case FilterOperator.In:
                    _filters.Add($"{field}={string.Join(",", values)}");
                    break;

                case FilterOperator.NotIn:
                    _filters.Add($"{field}=!{string.Join(",", values)}");
                    break;

                case FilterOperator.Present:
                    _filters.Add($"{field}=!");
                    break;

                case FilterOperator.Empty:
                    _filters.Add($"{field}=");
                    break;

                default:
                    if (values == null || values.Length != 1)
                        throw new XurrentQueryException($"The {@operator} filter requires a single value.");
                    _filters.Add($"{field}={values[0]}");
                    break;
            }
        }

        /// <summary>
        /// Formats a sort field for the API, prefixing descending fields with a minus sign.
        /// </summary>
        /// <param name="field">The field name.</param>
        /// <param name="sortOrder">The requested sort order.</param>
        /// <returns>The formatted sort field.</returns>
        private static string FormatOrderBy(string field, SortOrder sortOrder)
        {
            return sortOrder == SortOrder.Ascending ? field : "-" + field;
        }
    }
}

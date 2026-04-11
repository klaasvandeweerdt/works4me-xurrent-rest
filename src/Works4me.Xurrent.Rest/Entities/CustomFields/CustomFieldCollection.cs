using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.Json;
using Works4me.Xurrent.Rest.Extensions;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a keyed collection of custom fields indexed by custom field identifier.
    /// </summary>
    public sealed class CustomFieldCollection : KeyedCollection<string, CustomField>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when the collection changes (items are added, removed, replaced, or the collection is reset).
        /// </summary>
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Initializes a new, empty instance of the <see cref="CustomFieldCollection"/> class.
        /// </summary>
        public CustomFieldCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldCollection"/> class containing the specified items.
        /// </summary>
        /// <param name="items">The custom fields to add to the collection.</param>
        public CustomFieldCollection(IEnumerable<CustomField> items)
        {
            if (items is not null)
            {
                foreach (CustomField item in items)
                    Add(item);
            }
        }

        /// <summary>
        /// Gets or sets the custom field value for the specified custom field identifier.
        /// </summary>
        /// <param name="key">The custom field identifier.</param>
        /// <value>
        /// The current <see cref="JsonElement"/> value for the specified custom field, or <see langword="null"/> if not present.
        /// </value>
        public new JsonElement? this[string key]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(key))
                    throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));

                return this.TryGetValue(key, out CustomField? field) ? field?.Value : null;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(key))
                    throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));

                if (this.TryGetValue(key, out CustomField? existing))
                {
                    existing.Value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
                }
                else
                {
                    base.Add(new CustomField() { Id = key, Value = value });
                }
            }
        }

        /// <summary>
        /// Extracts the key for the specified item.
        /// </summary>
        /// <param name="item">The custom field item.</param>
        /// <returns>The key used to index the item, which is the value of <see cref="CustomField.Id"/>.</returns>
        protected override string GetKeyForItem(CustomField item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            return item.Id;
        }

        /// <summary>
        /// Adds the specified custom field to the collection.
        /// </summary>
        /// <param name="item">The custom field to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when a field with the same <see cref="CustomField.Id"/> already exists.</exception>
        public new void Add(CustomField item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (Contains(item.Id))
                throw new ArgumentException($"An item with key '{item.Id}' already exists.", nameof(item));

            base.Add(item);
        }

        /// <summary>
        /// Adds a new custom field with the specified identifier and value.
        /// </summary>
        /// <param name="id">The custom field identifier.</param>
        /// <param name="value">The custom field value.</param>
        /// <exception cref="ArgumentException">Thrown when a field with the same identifier already exists.</exception>
        public void Add(string id, JsonElement? value)
        {
            if (Contains(id))
                throw new ArgumentException($"An item with key '{id}' already exists.", nameof(id));

            base.Add(new CustomField { Id = id, Value = value });
        }

        /// <summary>
        /// Adds a new custom field or updates an existing one with the specified identifier and value.
        /// </summary>
        /// <param name="id">The custom field identifier.</param>
        /// <param name="value">The custom field value.</param>
        public void AddOrUpdate(string id, JsonElement? value)
        {
            this[id] = value;
        }

        /// <summary>
        /// Adds a new custom field or updates an existing one with the same identifier.
        /// </summary>
        /// <param name="item">The custom field to add or update.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is <see langword="null"/>.</exception>
        public void AddOrUpdate(CustomField item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            this[item.Id] = item.Value;
        }

        /// <summary>
        /// Inserts an item into the collection and raises a collection changed notification.
        /// </summary>
        /// <param name="index">The zero-based index at which to insert the item.</param>
        /// <param name="item">The item to insert.</param>
        protected override void InsertItem(int index, CustomField item)
        {
            base.InsertItem(index, item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
        }

        /// <summary>
        /// Replaces the item at the specified index and raises a collection changed notification.
        /// </summary>
        /// <param name="index">The zero-based index of the item to replace.</param>
        /// <param name="item">The new item.</param>
        protected override void SetItem(int index, CustomField item)
        {
            CustomField oldItem = this[index];
            base.SetItem(index, item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, oldItem, index));
        }

        /// <summary>
        /// Removes the item at the specified index and raises a collection changed notification.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        protected override void RemoveItem(int index)
        {
            CustomField oldItem = this[index];
            base.RemoveItem(index);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItem, index));
        }

        /// <summary>
        /// Removes all items from the collection and raises a collection reset notification.
        /// </summary>
        protected override void ClearItems()
        {
            base.ClearItems();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}

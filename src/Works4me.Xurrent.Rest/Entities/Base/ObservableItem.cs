using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Works4me.Xurrent.Rest.Comparers;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Base type that provides change tracking for properties and collections and supports JSON deserialization hooks.
    /// </summary>
    public abstract class ObservableItem : IMergeKeyProvider, IJsonOnDeserializing, IJsonOnDeserialized
    {
        private readonly Dictionary<string, object?> _changes = new();
        private bool _isTrackingEnabled = true;
        private readonly object _changesLock = new();
        private readonly object _trackingLock = new();

        /// <summary>
        /// Gets a value indicating whether any changes have been recorded.
        /// </summary>
        public bool HasChanged
        {
            get
            {
                lock (_changesLock)
                {
                    return _changes.Count > 0;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether change tracking is enabled for the current instance.
        /// </summary>
        protected internal bool IsTrackingEnabled
        {
            get
            {
                lock (_trackingLock)
                {
                    return _isTrackingEnabled; ;
                }
            }
            set
            {
                lock (_trackingLock)
                {
                    _isTrackingEnabled = value;
                }
            }
        }

        /// <summary>
        /// Records a property value change and returns the new value.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="name">The API field name used to record the change.</param>
        /// <param name="oldValue">The previous value.</param>
        /// <param name="newValue">The new value to set.</param>
        /// <returns>The provided <paramref name="newValue"/>.</returns>
        protected internal T SetValue<T>(string name, T oldValue, T newValue)
        {
            if (_isTrackingEnabled && (newValue is null || !GenericComparer.Compare(oldValue, newValue)))
            {
                lock (_changesLock)
                {
                    string idKey = name + "_id";
                    bool isIdBackedReference = typeof(Account).IsAssignableFrom(typeof(T)) || typeof(IRecord).IsAssignableFrom(typeof(T));

                    if (isIdBackedReference)
                    {
                        if (newValue is Account account)
                        {
                            _changes[idKey] = account.Id;
                        }
                        else if (newValue is IRecord record)
                        {
                            _changes[idKey] = record.Id;
                        }
                        else
                        {
                            _changes[idKey] = null;
                        }
                    }
                    else
                    {
                        _changes[name] = newValue;
                    }
                }
            }
            return newValue;
        }

        /// <summary>
        /// Records a property value assignment and returns the assigned value.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="name">The API field name used to record the change.</param>
        /// <param name="newValue">The new value to set.</param>
        /// <returns>The provided <paramref name="newValue"/>.</returns>
        protected internal T SetValue<T>(string name, T newValue)
        {
            if (_isTrackingEnabled)
            {
                lock (_changesLock)
                {
                    string idKey = name + "_id";
                    bool isIdBackedReference = typeof(Account).IsAssignableFrom(typeof(T)) || typeof(IRecord).IsAssignableFrom(typeof(T));

                    if (isIdBackedReference)
                    {
                        if (newValue is Account account)
                        {
                            _changes[idKey] = account.Id;
                        }
                        else if (newValue is IRecord record)
                        {
                            _changes[idKey] = record.Id;
                        }
                        else
                        {
                            _changes[idKey] = null;
                        }
                    }
                    else
                    {
                        _changes[name] = newValue;
                    }
                }
            }

            return newValue;
        }

        /// <summary>
        /// Marks a custom field collection as changed for the specified API property name.
        /// </summary>
        protected void MarkCollectionChanged(CustomFieldCollection? collection, string propertyName)
        {
            if (_isTrackingEnabled)
            {
                lock (_changesLock)
                {
                    _changes[propertyName] = collection;
                }
            }
        }

        /// <summary>
        /// Marks a collection as changed for the specified API property name.
        /// </summary>
        protected void MarkCollectionChanged<T>(ObservableCollection<T> collection, string propertyName)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            if (_isTrackingEnabled)
            {
                if (typeof(IRecord).IsAssignableFrom(typeof(T)))
                {
                    HashSet<long> ids = new();
                    for (int index = 0; index < collection.Count; index++)
                    {
                        if (collection[index] is IRecord identifier)
                        {
                            ids.Add(identifier.Id);
                        }
                    }

                    lock (_changesLock)
                    {
                        _changes[propertyName + "_ids"] = ids;
                    }
                }
                else
                {
                    lock (_changesLock)
                    {
                        _changes[propertyName] = collection;
                    }
                }
            }
        }

        /// <summary>
        /// Gets a tracked collection instance, initializing it if necessary and wiring the specified change handler.
        /// </summary>
        protected static ObservableCollection<T> GetCollection<T>(ref ObservableCollection<T>? collection, NotifyCollectionChangedEventHandler eventHandler)
        {
            if (collection is null)
            {
                collection = new();
                collection.CollectionChanged += eventHandler;
            }
            return collection;
        }

        /// <summary>
        /// Gets a tracked custom field collection instance, initializing it if necessary and wiring change handlers.
        /// </summary>
        protected static CustomFieldCollection GetCollection(ref CustomFieldCollection? collection, NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler, PropertyChangedEventHandler propertyChangedEventHandler)
        {
            if (collection is null)
            {
                collection = new();
                collection.CollectionChanged += notifyCollectionChangedEventHandler;
                collection.PropertyChanged += propertyChangedEventHandler;
            }
            return collection;
        }

        /// <summary>
        /// Replaces a tracked collection, records it as changed, and rewires the change handler.
        /// </summary>
        protected void SetCollection<T>(ref ObservableCollection<T>? collection, string propertyName, ObservableCollection<T>? value, NotifyCollectionChangedEventHandler eventHandler)
        {
            if (collection is not null)
            {
                collection.CollectionChanged -= eventHandler;
            }
            collection = value ?? new();
            MarkCollectionChanged(collection, propertyName);
            collection.CollectionChanged += eventHandler;
        }

        /// <summary>
        /// Replaces a tracked custom field collection, records it as changed, and rewires change handlers.
        /// </summary>
        protected void SetCollection(ref CustomFieldCollection? collection, string propertyName, CustomFieldCollection? value, NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler, PropertyChangedEventHandler propertyChangedEventHandler)
        {
            if (collection is not null)
            {
                collection.CollectionChanged -= notifyCollectionChangedEventHandler;
                collection.PropertyChanged -= propertyChangedEventHandler;
            }
            collection = value ?? new();
            MarkCollectionChanged(collection, propertyName);
            collection.CollectionChanged += notifyCollectionChangedEventHandler;
            collection.PropertyChanged += propertyChangedEventHandler;
        }

        /// <summary>
        /// Serializes the recorded changes to a JSON request body.
        /// </summary>
        internal string GetHttpRequestBody(JsonSerializerOptions jsonSerializerOptions)
        {
            Dictionary<string, object?> output;

            lock (_changesLock)
            {
                output = new Dictionary<string, object?>(_changes);
            }

            return JsonSerializer.Serialize(output, jsonSerializerOptions);
        }

        /// <inheritdoc/>
        public virtual long GetMergeKey()
        {
            return GetHashCode();
        }

        /// <inheritdoc/>
        public void OnDeserializing()
        {
            _isTrackingEnabled = false;
        }

        /// <inheritdoc/>
        public void OnDeserialized()
        {
            _isTrackingEnabled = true;
            _changes.Clear();
        }
    }
}

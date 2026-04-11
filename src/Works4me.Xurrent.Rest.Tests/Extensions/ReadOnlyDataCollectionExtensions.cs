using System;
using System.Linq;

namespace Works4me.Xurrent.Rest.Tests.Extensions
{
    internal static class ReadOnlyDataCollectionExtensions
    {
        private static readonly Random _random = new();

        public static T GetRandomItem<T>(this ReadOnlyKeyedDataCollection<T> collection)
            where T : IMergeKeyProvider
        {
            int randomIndex = _random.Next(collection.Count);
            return collection.Skip(randomIndex).First();
        }
    }
}

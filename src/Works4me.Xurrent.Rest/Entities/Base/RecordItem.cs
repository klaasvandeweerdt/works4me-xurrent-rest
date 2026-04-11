using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// The base class that tracks property and collection changes.
    /// </summary>
    public abstract class RecordItem : ObservableItem, IRecord
    {
        private long _id;
        private string _nodeId = string.Empty;
        private Account? _account;

        /// <inheritdoc/>
        [XurrentField("id")]
        public long Id
        {
            get => _id;
            set => _id = value;
        }

        /// <inheritdoc/>
        [XurrentField("nodeID")]
        public string NodeID
        {
            get => _nodeId;
            internal set => _nodeId = value;
        }

        /// <inheritdoc/>
        [XurrentField("account")]
        public Account? Account
        {
            get => _account;
            internal set => _account = value;
        }

        /// <inheritdoc/>
        public override long GetMergeKey()
        {
            return _id;
        }
    }
}

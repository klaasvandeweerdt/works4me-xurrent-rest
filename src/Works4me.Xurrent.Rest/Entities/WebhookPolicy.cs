using System;
using System.Diagnostics;
using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent webhook policy object.
    /// </summary>
    [DebuggerDisplay("{Id}")]
    public sealed class WebhookPolicy : RecordItem
    {
        /// <summary>
        /// Represents the queryable fields of a <see cref="WebhookPolicy"/> object.
        /// </summary>
        public enum Field
        {
            /// <summary>
            /// The created at field.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// The disabled field.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// The identifier field.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// The jwt alg field.
            /// </summary>
            [XurrentEnum("jwt_alg")]
            JwtAlg,

            /// <summary>
            /// The jwt audience field.
            /// </summary>
            [XurrentEnum("jwt_audience")]
            JwtAudience,

            /// <summary>
            /// The jwt claim expires in field.
            /// </summary>
            [XurrentEnum("jwt_claim_expires_in")]
            JwtClaimExpiresIn,

            /// <summary>
            /// The name field.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// The node identifier field.
            /// </summary>
            [XurrentEnum("nodeID", IgnoreInFieldSelection = true)]
            NodeId,

            /// <summary>
            /// The public key pem field.
            /// </summary>
            [XurrentEnum("public_key_pem", IgnoreInFieldSelection = true)]
            PublicKeyPem,

            /// <summary>
            /// The updated at field.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the filterable fields of a <see cref="WebhookPolicy"/> object.
        /// </summary>
        public enum FilterField
        {
            /// <summary>
            /// Filters webhook policies by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Filters webhook policies by disabled state.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Filters webhook policies by identifier.
            /// </summary>
            [XurrentEnum("id")]
            Id,

            /// <summary>
            /// Filters webhook policies by name.
            /// </summary>
            [XurrentEnum("name")]
            Name,

            /// <summary>
            /// Filters webhook policies by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        /// <summary>
        /// Represents the predefined filters of a <see cref="WebhookPolicy"/> object.
        /// </summary>
        public enum PredefinedFilter
        {
            /// <summary>
            /// Lists all disabled webhook policies.
            /// </summary>
            [XurrentEnum("disabled")]
            Disabled,

            /// <summary>
            /// Lists all enabled webhook policies.
            /// </summary>
            [XurrentEnum("enabled")]
            Enabled
        }

        /// <summary>
        /// Represents the fields used to order a <see cref="WebhookPolicy"/> object.
        /// </summary>
        public enum OrderField
        {
            /// <summary>
            /// Sorts webhook policies by creation date and time.
            /// </summary>
            [XurrentEnum("created_at")]
            CreatedAt,

            /// <summary>
            /// Sorts webhook policies by last update date and time.
            /// </summary>
            [XurrentEnum("updated_at")]
            UpdatedAt
        }

        private DateTime? _createdAt;
        private bool? _disabled;
        private JwtAlgorithm? _jwtAlg;
        private string? _jwtAudience;
        private int? _jwtClaimExpiresIn;
        private string? _name;
        private string? _publicKeyPem;
        private DateTime? _updatedAt;

        /// <summary>
        /// Gets the date and time at which the webhook policy was created.
        /// </summary>
        [XurrentField("created_at")]
        public DateTime? CreatedAt
        {
            get => _createdAt;
            internal set => _createdAt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the webhook policy is disabled.
        /// </summary>
        [XurrentField("disabled")]
        public bool? Disabled
        {
            get => _disabled;
            set => _disabled = SetValue("disabled", _disabled, value);
        }

        /// <summary>
        /// Gets or sets the JSON Web Token algorithm used for cryptographic signing of webhook messages.
        /// </summary>
        [XurrentField("jwt_alg")]
        public JwtAlgorithm? JwtAlg
        {
            get => _jwtAlg;
            set => _jwtAlg = SetValue("jwt_alg", _jwtAlg, value);
        }

        /// <summary>
        /// Gets or sets the value for the audience claim in the JSON Web Token.
        /// </summary>
        [XurrentField("jwt_audience")]
        public string? JwtAudience
        {
            get => _jwtAudience;
            set => _jwtAudience = SetValue("jwt_audience", _jwtAudience, value);
        }

        /// <summary>
        /// Gets or sets the expiration time after which the JSON Web Token must no longer be accepted for processing.
        /// </summary>
        [XurrentField("jwt_claim_expires_in")]
        public int? JwtClaimExpiresIn
        {
            get => _jwtClaimExpiresIn;
            set => _jwtClaimExpiresIn = SetValue("jwt_claim_expires_in", _jwtClaimExpiresIn, value);
        }

        /// <summary>
        /// Gets the generated name of the webhook policy.
        /// </summary>
        [XurrentField("name")]
        public string? Name
        {
            get => _name;
            internal set => _name = value;
        }

        /// <summary>
        /// Gets the public key of the webhook policy in PEM format.<br />
        /// This property is only available when a new policy is created.
        /// </summary>
        [XurrentField("public_key_pem")]
        public string? PublicKeyPem
        {
            get => _publicKeyPem;
            internal set => _publicKeyPem = value;
        }

        /// <summary>
        /// Gets the date and time at which the webhook policy was last updated.
        /// </summary>
        [XurrentField("updated_at")]
        public DateTime? UpdatedAt
        {
            get => _updatedAt;
            internal set => _updatedAt = value;
        }

        /// <summary>
        /// Creates a new webhook policy instance.
        /// </summary>
        public WebhookPolicy()
        {
        }

        /// <summary>
        /// Creates a new webhook policy instance.
        /// </summary>
        /// <param name="id">The unique identifier of the webhook policy.</param>
        public WebhookPolicy(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Creates a new webhook policy instance.
        /// </summary>
        /// <param name="jwtAlg">The jwt alg of the webhook policy.</param>
        public WebhookPolicy(JwtAlgorithm jwtAlg)
        {
            _jwtAlg = SetValue("jwt_alg", jwtAlg);
        }
    }
}

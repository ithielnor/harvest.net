using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for a client in the harvest system.
    /// </summary>
    [SerializeAs(Name = "client")]
    public class Client : IModel
    {
        /// <summary>
        /// Identifier of the client.
        /// <example>
        /// 3398386
        /// </example>
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Time when the client entry was updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Time when the client entry was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Name of the client.
        /// Example:
        /// <example>
        /// "Your Account"
        /// </example>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id of the high-rise.
        /// </summary>
        public long? HighriseId { get; set; }

        /// <summary>
        /// Version of the cache.
        /// Example:
        /// <example>
        /// 821859237
        /// </example>
        /// </summary>
        public long CacheVersion { get; set; }

        /// <summary>
        /// Currency which is used by the client. For currencies lookup <see cref="Currency"/>.
        /// </summary>
        public Currency? Currency { get; set; }

        /// <summary>
        /// Boolean which describes if the client is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Symbol of the currency used by the client.
        /// Example:
        /// <example>
        /// $
        /// </example>
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Details of the client. This can be various information.
        /// Example: 
        /// <example>
        /// "123 Main St\r\nAnytown, NY 12345"
        /// </example>
        /// </summary>
        public string Details { get; set; }
    }
}

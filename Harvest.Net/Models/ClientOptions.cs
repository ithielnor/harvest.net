using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model which is used for general operations in the client context.
    /// </summary>
    [SerializeAs(Name = "client")]
    public class ClientOptions
    {
        /// <summary>
        /// New client name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Optional Highrise ID for our legacy integration.
        /// </summary>
        public long? HighriseId { get; set; }

        /// <summary>
        /// The currency you�d like to use for the client.
        /// </summary>
        public Currency? Currency { get; set; }

        /// <summary>
        /// Additional details, normally used for address information.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Determines if the client is active, or archived.
        /// </summary>
        public bool? Active { get; set; }
    }
}

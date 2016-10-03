using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// A failed request or missing resource, in which case an error message may be returned.
    /// </summary>
    [SerializeAs(Name = "request")]
    public class ErrorResult
    {
        /// <summary>
        /// Message of the error.
        /// </summary>
        public string Message { get; set; }
    }
}

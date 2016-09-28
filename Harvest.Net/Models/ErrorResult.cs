using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "request")]
    public class ErrorResult
    {
        public string Message { get; set; }
    }
}

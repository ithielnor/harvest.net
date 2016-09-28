using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "client")]
    public class ClientOptions
    {
        public string Name { get; set; }

        public long? HighriseId { get; set; }

        public Currency? Currency { get; set; }

        public string Details { get; set; }

        public bool? Active { get; set; }
    }
}

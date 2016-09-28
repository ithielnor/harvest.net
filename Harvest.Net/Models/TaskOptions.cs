using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "task")]
    public class TaskOptions
    {
        public string Name { get; set; }

        public bool? BillableByDefault { get; set; }

        public bool? IsDefault { get; set; }

        public decimal? DefaultHourlyRate { get; set; }
    }
}

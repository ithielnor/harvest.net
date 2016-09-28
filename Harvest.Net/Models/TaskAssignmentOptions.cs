using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "task-assignment")]
    public class TaskAssignmentOptions
    {
        public bool? Billable { get; set; }

        public bool? Deactivated { get; set; }

        public decimal? HourlyRate { get; set; }

        public decimal? Budget { get; set; }
    }
}

using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model to create and update Tasks.
    /// </summary>
    [SerializeAs(Name = "task")]
    public class TaskOptions
    {
        /// <summary>
        /// Name of the task.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Boolean which describes if the task is billable by default.
        /// </summary>
        public bool? BillableByDefault { get; set; }

        /// <summary>
        /// Boolean which describes if it is a default task.
        /// </summary>
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Default hourly rate of the task.
        /// </summary>
        public decimal? DefaultHourlyRate { get; set; }
    }
}

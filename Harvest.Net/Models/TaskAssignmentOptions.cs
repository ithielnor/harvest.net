using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for updating <see cref="TaskAssignment"/>s.
    /// </summary>
    [SerializeAs(Name = "task-assignment")]
    public class TaskAssignmentOptions
    {
        /// <summary>
        /// Value which describes if the task assignment is billable.
        /// </summary>
        public bool? Billable { get; set; }

        /// <summary>
        /// Value which describes if the task assignment was deactivated.
        /// </summary>
        public bool? Deactivated { get; set; }

        /// <summary>
        /// Hourly rate for the task assignment.
        /// </summary>
        public decimal? HourlyRate { get; set; }

        /// <summary>
        /// Total budget given for the task assignment.
        /// </summary>
        public decimal? Budget { get; set; }
    }
}

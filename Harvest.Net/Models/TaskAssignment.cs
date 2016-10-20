using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Task assignment used in the harvest API.
    /// </summary>
    [SerializeAs(Name = "task-assignment")]
    public class TaskAssignment : IModel
    {
        /// <summary>
        /// Identifier of the Task assignment.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Time when the task assignment was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Time when the task assignment was updated last.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Id of the taks which was assigned.
        /// </summary>
        public long TaskId { get; set; }

        /// <summary>
        /// Id of the project which is referenced.
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// Value which describes if the task assignment is billable.
        /// </summary>
        public bool Billable { get; set; }

        /// <summary>
        /// Value which describes if the task assignment was deactivated.
        /// </summary>
        public bool Deactivated { get; set; }

        /// <summary>
        /// Hourly rate for the task assignment.
        /// </summary>
        public decimal HourlyRate { get; set; }

        /// <summary>
        /// Total budget given for the task assignment.
        /// </summary>
        public decimal? Budget { get; set; }

        /// <summary>
        /// Estimated amount to spend on this assignment.
        /// </summary>
        public decimal? Estimate { get; set; }
    }
}

using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model to visualize tasks in the API.
    /// </summary>
    [SerializeAs(Name = "task")]
    public class Task : IModel
    {
        /// <summary>
        /// Id of the task.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Time the task got created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Time when the task was updated last time.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Name of the task.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Boolean which describes if the task is billable by default.
        /// </summary>
        public bool BillableByDefault { get; set; }

        /// <summary>
        /// Boolean which describes if it is a default task.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Default hourly rate of the task.
        /// </summary>
        public decimal? DefaultHourlyRate { get; set; }

        /// <summary>
        /// Boolean which describes if the task is deactivated.
        /// </summary>
        public bool Deactivated { get; set; }

        /// <summary>
        /// Boolean which describes if the task is billable.
        /// </summary>
        public bool? Billable { get; set; }
    }
}

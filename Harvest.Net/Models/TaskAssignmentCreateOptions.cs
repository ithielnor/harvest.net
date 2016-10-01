using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for creating a task assignment.
    /// </summary>
    [SerializeAs(Name = "task")]
    internal class TaskAssignmentCreateOptions
    {
        /// <summary>
        /// Identifier of the Task assignment.
        /// </summary>
        public long Id { get; set; }
    }
}

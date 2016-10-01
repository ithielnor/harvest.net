using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for updating existing user assignment.
    /// </summary>
    [SerializeAs(Name = "user-assignment")]
    public class UserAssignmentOptions
    {
        /// <summary>
        /// Identifier of the user.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Project id referenced to the assignment.
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// Value which describes if the user of the assignment is the project manager.
        /// </summary>
        public bool? IsProjectManager { get; set; }

        /// <summary>
        /// Value which describes if the assignment was deactivated.
        /// </summary>
        public bool? Deactivated { get; set; }

        /// <summary>
        /// Hourly rate of the user assignment.
        /// </summary>
        public decimal? HourlyRate { get; set; }

        /// <summary>
        /// Budget fir the user assignment.
        /// </summary>
        public decimal? Budget { get; set; }
    }
}

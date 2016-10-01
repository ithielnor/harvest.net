using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// User assignment model in the harvest API.
    /// </summary>
    [SerializeAs(Name = "user-assignment")]
    public class UserAssignment : IModel
    {
        /// <summary>
        /// Identifier of the user assignment.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Time the user was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Time when the user assignment was updated last.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

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
        public bool IsProjectManager { get; set; }

        /// <summary>
        /// Value which describes if the assignment was deactivated.
        /// </summary>
        public bool Deactivated { get; set; }

        /// <summary>
        /// Hourly rate of the user assignment.
        /// </summary>
        public decimal? HourlyRate { get; set; }

        /// <summary>
        /// Budget fir the user assignment.
        /// </summary>
        public decimal? Budget { get; set; }

        /// <summary>
        /// Estimated amount for the user assignment.
        /// </summary>
        public decimal? Estimate { get; set; }
    }
}

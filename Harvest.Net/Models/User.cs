using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for interacting with users in the harvest API.
    /// </summary>
    [SerializeAs(Name = "user")]
    public class User : IModel
    {
        /// <summary>
        /// Identifier of the user.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Time the user was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Time when the user was updated last.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// E-Mail of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Telephone number of the user.
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// First name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Url to the avatar of the user.
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Url to the identity of the user.
        /// </summary>
        public string IdentityUrl { get; set; }

        /// <summary>
        /// Identifier for the open social.
        /// </summary>
        public string OpensocialIdentifier { get; set; }

        /// <summary>
        /// Department for user.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Value which describes if user is an admin.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Value which describes if user is a contractor.
        /// </summary>
        public bool IsContractor { get; set; }

        /// <summary>
        /// If the user is active, or archived.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// If true this user will automatically be assigned to all new projects.
        /// </summary>
        public bool HasAccessToAllFutureProjects { get; set; }

        /// <summary>
        /// Value which describes if the user wants the newsletter.
        /// </summary>
        public bool WantsNewsletter { get; set; }

        /// <summary>
        /// Describes if the user wants a weekly digest.
        /// </summary>
        public bool WantsWeeklyDigest { get; set; }

        public DateTime? WeeklyDigestSentOn { get; set; }

        /// <summary>
        /// Default rate for the user in new projects, if no rate is specified.
        /// </summary>
        public decimal? DefaultHourlyRate { get; set; }

        /// <summary>
        /// Cost (internal) rate for user.
        /// </summary>
        public decimal? CostRate { get; set; }

        /// <summary>
        /// To set a timezone other than the account default.
        /// </summary>
        public string Timezone { get; set; }
    }
}

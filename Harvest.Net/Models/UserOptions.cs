using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for updating and creating users in the API.
    /// </summary>
    [SerializeAs(Name = "user")]
    public class UserOptions
    {
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
        /// Department for user.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Value which describes if user is an admin.
        /// </summary>
        public bool? IsAdmin { get; set; }

        /// <summary>
        /// Value which describes if user is a contractor.
        /// </summary>
        public bool? IsContractor { get; set; }

        /// <summary>
        /// If the user is active, or archived.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// If true this user will automatically be assigned to all new projects.
        /// </summary>
        public bool? HasAccessToAllFutureProjects { get; set; }

        /// <summary>
        /// Value which describes if the user wants the newsletter.
        /// </summary>
        public bool? WantsNewsletter { get; set; }

        /// <summary>
        /// Describes if the user wants a weekly digest.
        /// </summary>
        public bool? WantsWeeklyDigest { get; set; }

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

        /// <summary>
        /// The number of seconds per week this person is available to work.
        /// </summary>
        public long WeeklyCapacity { get; set; }
    }
}

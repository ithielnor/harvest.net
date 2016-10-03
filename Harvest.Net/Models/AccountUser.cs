using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model to show important properties of a user.
    /// </summary>
    [SerializeAs(Name = "user")]
    public class AccountUser
    {
        /// <summary>
        /// Identifier for the user.
        /// <example>
        /// 12345
        /// </example>
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// E-Mail of the user.
        /// <example>
        /// admin@getharvest.com
        /// </example>
        /// </summary>
        public string Email { get; set; }

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
        /// <example>
        /// /assets/profile_images/big_ben.png?1389271
        /// </example>
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Boolean which describes if the user is an admin or not.
        /// </summary>
        public bool Admin { get; set; }

        /// <summary>
        /// Timezone of the User.
        /// <example>
        /// Eastern Time (US &amp; Canada)
        /// </example>
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// Identifier of the timezone.
        /// <example>
        /// America/New_York
        /// </example>
        /// </summary>
        public string TimezoneIdentifier { get; set; }

        /// <summary>
        /// Offset from UTC time.
        /// <example>
        /// -14400
        /// </example>
        /// </summary>
        public long? TimezoneUtcOffset { get; set; }

        /// <summary>
        /// Boolean which desribes if timestamp timers are activated.
        /// </summary>
        public bool? TimestampTimers { get; set; }

        /// <summary>
        /// Description field for the project manager information of the user. For further reference lookup <see cref="ProjectManager"/>.
        /// </summary>
        public ProjectManager ProjectManager { get; set; }
    }
}

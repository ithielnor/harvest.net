using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// This call will return user and account information for the currently authenticated user.
    /// </summary>
    [SerializeAs(Name = "hash")]
    public class Account
    {
        /// <summary>
        /// Company which is bound to the user.
        /// </summary>
        public Company Company { get; set; }

        /// <summary>
        /// Information about the user who is the owner of the account.
        /// </summary>
        public AccountUser User { get; set; }
    }
}

using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for assigning a user to a user assignment.
    /// </summary>
    [SerializeAs(Name = "user")]
    internal class UserAssignmentCreateOptions
    {
        /// <summary>
        /// Identifier of the user.
        /// </summary>
        public long Id { get; set; }
    }
}

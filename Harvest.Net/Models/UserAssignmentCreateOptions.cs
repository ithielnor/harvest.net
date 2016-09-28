using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "user")]
    internal class UserAssignmentCreateOptions
    {
        public long Id { get; set; }
    }
}

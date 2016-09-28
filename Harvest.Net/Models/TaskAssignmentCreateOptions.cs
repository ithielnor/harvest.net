using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "task")]
    internal class TaskAssignmentCreateOptions
    {
        public long Id { get; set; }
    }
}

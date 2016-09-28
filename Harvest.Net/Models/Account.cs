using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "hash")]
    public class Account
    {
        public Company Company { get; set; }

        public AccountUser User { get; set; }
    }
}

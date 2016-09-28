using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "modules")]
    public class Modules
    {
        public bool Expenses { get; set; }

        public bool Invoices { get; set; }

        public bool Estimates { get; set; }

        public bool Approval { get; set; }
    }
}

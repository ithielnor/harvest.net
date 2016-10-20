using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Class which desribes which modules are activated for companies.
    /// </summary>
    [SerializeAs(Name = "modules")]
    public class Modules
    {
        /// <summary>
        /// Boolean which describes if the expenses module is activated.
        /// </summary>
        public bool Expenses { get; set; }

        /// <summary>
        /// Boolean which describes if the invoices module is activated.
        /// </summary>
        public bool Invoices { get; set; }

        /// <summary>
        /// Boolean which describes if the estimates module is activated.
        /// </summary>
        public bool Estimates { get; set; }

        /// <summary>
        /// Boolean which describes if the approval module is activated.
        /// </summary>
        public bool Approval { get; set; }
    }
}

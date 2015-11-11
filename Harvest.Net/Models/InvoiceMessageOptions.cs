using Harvest.Net.Serialization;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "invoice-message")]
    public class InvoiceMessageOptions
    {
        public string Body { get; set; }

        public bool AttachPdf { get; set; }

        /// <summary>
        /// Include a payment link in the message body
        /// </summary>
        public bool IncludePayPalLink { get; set; }

        /// <summary>
        /// Send a copy to the current user
        /// </summary>
        public bool SendMeACopy { get; set; }

        /// <summary>
        /// Comma delimited list of recipient emails
        /// </summary>
        public string Recipients { get; set; }
    }
}

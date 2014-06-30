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
    public class InvoiceMessage : IModel
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

        public long InvoiceId { get; set; }

        public bool SendMeACopy { get; set; }

        public string SentBy { get; set; }

        public string SentByEmail { get; set; }

        public string FullRecipientList { get; set; }

        public string Body { get; set; }
    }
}

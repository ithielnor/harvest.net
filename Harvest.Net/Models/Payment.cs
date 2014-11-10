using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "payment")]
    public class Payment : IModel
    {
        public long Id { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Amount { get; set; }

        public long InvoiceId { get; set; }

        public DateTime PaidAt { get; set; }

        public string Notes { get; set; }

        public string RecordedBy { get; set; }

        public string RecordedByEmail { get; set; }

        public string PayPalTransactionId { get; set; }

        public string Authorization { get; set; }

        public long? PaymentGatewayId { get; set; }
    }
}

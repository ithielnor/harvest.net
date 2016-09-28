using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "payment")]
    public class PaymentOptions
    {
        public decimal? Amount { get; set; }

        public DateTime? PaidAt { get; set; }

        public string Notes { get; set; }
    }
}

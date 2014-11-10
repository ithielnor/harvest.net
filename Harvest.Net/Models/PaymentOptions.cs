using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

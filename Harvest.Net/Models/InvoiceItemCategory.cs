using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "invoice-item-category")]
    public class InvoiceItemCategory : IModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool UseAsExpense { get; set; }

        public bool UseAsService { get; set; }
    }
}

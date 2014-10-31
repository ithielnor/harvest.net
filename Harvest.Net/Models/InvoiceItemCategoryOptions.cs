using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "invoice-item-category")]
    public class InvoiceItemCategoryOptions
    {
        public string Name { get; set; }

        public bool? UseAsExpense { get; set; }

        public bool? UseAsService { get; set; }
    }
}

using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "expense")]
    public class ExpenseOptions
    {
        public decimal? TotalCost { get; set; }

        public decimal? Units { get; set; }

        public long? ProjectId { get; set; }
        
        public long? ExpenseCategoryId { get; set; }

        public DateTime? SpentAt { get; set; }

        public string Notes { get; set; }

        public bool? Billable { get; set; }
    }
}

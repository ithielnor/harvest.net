using RestSharp.Serializers;
using System;

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

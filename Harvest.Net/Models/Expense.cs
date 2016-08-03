using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "expense")]
    public class Expense : IModel
    {
        public long Id { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal TotalCost { get; set; }

        public decimal Units { get; set; }

        public long ProjectId { get; set; }

        public long ExpenseCategoryId { get; set; }

        public long UserId { get; set; }

        public DateTime SpentAt { get; set; }

        public bool IsClosed { get; set; }

        public string Notes { get; set; }

        public long InvoiceId { get; set; }

        public long CompanyId { get; set; }

        public bool Billable { get; set; }

        public bool HasReceipt { get; set; }

        public string ReceiptUrl { get; set; }

        public bool IsLocked { get; set; }

        public string LockedReason { get; set; }
    }
}

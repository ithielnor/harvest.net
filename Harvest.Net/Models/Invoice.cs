using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "invoice")]
    public class Invoice : IModel
    {
        public long Id { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Amount { get; set; }

        public decimal DueAmount { get; set; }

        public DateTime DueAt { get; set; }

        public InvoiceDateAtFormat DueAtHumanFormat { get; set; }

        public DateTime? PeriodEnd { get; set; }

        public DateTime? PeriodStart { get; set; }

        public long ClientId { get; set; }

        public InvoiceKind Kind { get; set; }

        public string Subject { get; set; }

        public Currency? Currency { get; set; }

        public DateTime IssuedAt { get; set; }

        public long CreatedById { get; set; }

        public string Notes { get; set; }

        public string Number { get; set; }

        public string PurchaseOrder { get; set; }

        public string ClientKey { get; set; }

        public InvoiceState State { get; set; }

        public decimal? Tax { get; set; }

        public decimal? Tax2 { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal? TaxAmount2 { get; set; }

        public decimal? Discount { get; set; }

        public decimal DiscountAmount { get; set; }

        public long? RecurringInvoiceId { get; set; }

        public long? EstimateId { get; set; }

        public long? RetainerId { get; set; }

        /// <summary>
        /// Free form items
        /// </summary>
        public string CsvLineItems { get; set; }
    }
}

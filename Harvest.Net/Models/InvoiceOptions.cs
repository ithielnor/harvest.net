using Harvest.Net.Serialization;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Object for creating or updating an invoice. Only supply values for the fields you want to modify.
    /// </summary>
    [SerializeAs(Name = "invoice")]
    public class InvoiceOptions
    {
        public long? ClientId { get; set; }

        public Currency? Currency { get; set; }

        [HarvestSerialize(DateOnly = true)]
        public DateTime? IssuedAt { get; set; }

        public InvoiceDateAtFormat? DueAtHumanFormat { get; set; }

        [HarvestSerialize(DateOnly = true)]
        public DateTime? DueAt { get; set; }

        public string Number { get; set; }

        public string Subject { get; set; }

        public string PurchaseOrder { get; set; }

        public string ClientKey { get; set; }

        public string Notes { get; set; }

        public decimal? Tax { get; set; }

        public decimal? Tax2 { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal? Tax2Amount { get; set; }

        public InvoiceKind? Kind { get; set; }
        
        /// <summary>
        /// Free form items
        /// </summary>
        public string CsvLineItems { get; set; }
        
        /// <summary>
        /// Project IDs to gather data from
        /// </summary>
        public string ProjectsToInvoice { get; set; }

        public void SetInvoiceItems(IList<InvoiceItem> items)
        {
            CsvLineItems = InvoiceItem.GetHeaders() + "\n" + string.Join("\n", items.Select(ii => ii.ToString()));
        }
    }
}

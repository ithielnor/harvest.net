using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public long? CreatedById { get; set; }

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

        private IList<InvoiceItem> _listLineItems;

        public IList<InvoiceItem> ListLineItems()
        {
            if (_listLineItems == null)
            {
                var lines = CsvLineItems.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => line.Split(','));

                var headers = lines.First();
                _listLineItems = new List<InvoiceItem>();

                foreach (var row in lines.Skip(1))
                {
                    _listLineItems.Add(new InvoiceItem()
                    {
                        ProjectId = row[Array.IndexOf<string>(headers, "project_id")].ParseNullableLong(),
                        UnitPrice = decimal.Parse(row[Array.IndexOf<string>(headers, "unit_price")]),
                        Quantity = decimal.Parse(row[Array.IndexOf<string>(headers, "quantity")]),
                        Amount = decimal.Parse(row[Array.IndexOf<string>(headers, "amount")]),
                        Taxed = bool.Parse(row[Array.IndexOf<string>(headers, "taxed")]),
                        Taxed2 = bool.Parse(row[Array.IndexOf<string>(headers, "taxed2")]),
                        Kind = row[Array.IndexOf<string>(headers, "kind")],
                        Description = row[Array.IndexOf<string>(headers, "description")],
                    });
                }
            }

            return _listLineItems;
        }
    }
}

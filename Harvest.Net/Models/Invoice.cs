using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Harvest.Net.Models
{
    /// <summary>
    /// API Model for Invoices.
    /// </summary>
    [SerializeAs(Name = "invoice")]
    public class Invoice : IModel
    {
        /// <summary>
        /// The identifier for the Invoice.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Date invoice was last updated.
        /// <example>
        /// Input example given by the API: 2015-04-09T12:07:56Z.
        /// This will be represented as DateTime.
        /// </example>
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Date invoice was created.
        /// <example>
        /// Input example given by the API: 2015-04-09T12:07:56Z.
        /// This will be represented as DateTime.
        /// </example>
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The amount given in the invoice.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Amount which is required by the invoice to the <see cref="DueAt"/> date.
        /// </summary>
        public decimal DueAmount { get; set; }

        /// <summary>
        /// Date given which is similar to <see cref="DueAtHumanFormat"/> but rather than this type it is an instance of <see cref="DateTime"/>.
        /// </summary>
        public DateTime DueAt { get; set; }

        /// <summary>
        /// Invoice due date. Acceptable formats are NET N where N is the number of days until the invoice is due.
        /// This is implemented by <see cref="InvoiceDateAtFormat"/>.
        /// </summary>
        public InvoiceDateAtFormat DueAtHumanFormat { get; set; }

        /// <summary>
        /// End date for included project hours.
        /// <example>
        /// Input example given by the API: 2015-05-22.
        /// This will be represented as DateTime.
        /// </example>
        /// </summary>
        public DateTime? PeriodEnd { get; set; }

        /// <summary>
        /// Date for included project hours.
        /// <example>
        /// Input example given by the API: 2015-04-22.
        /// This will be represented as nullable DateTime.
        /// </example>
        /// </summary>
        public DateTime? PeriodStart { get; set; }

        /// <summary>
        /// A valid client-id.
        /// </summary>
        public long ClientId { get; set; }

        /// <summary>
        /// Invoice type. Options:
        /// <list type="bullet">
        /// <item>
        /// <description>free-form</description>
        /// </item>
        /// <item>
        /// <description>project</description>
        /// </item>
        /// <item>
        /// <description>task</description>
        /// </item>
        /// <item>
        /// <description>people</description>
        /// </item>
        /// <item>
        /// <description>detailed</description>
        /// </item>
        /// </list>
        /// For further reference, lookup: <see cref="InvoiceKind"/>.
        /// </summary>
        public InvoiceKind Kind { get; set; }

        /// <summary>
        /// Optional invoice subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// A valid currency format (Example: United States Dollar - USD). Optional, and will default to the client currency if no value is passed.
        /// For further reference, lookup: <see cref="Currency"/>.
        /// </summary>
        public Currency? Currency { get; set; }

        /// <summary>
        /// Invoice creation date.
        /// <example>
        /// This is an example given by the API.
        /// 2015-04-22
        /// </example>
        /// </summary>
        public DateTime IssuedAt { get; set; }

        /// <summary>
        /// User ID of the invoice creator.
        /// </summary>
        public long? CreatedById { get; set; }

        /// <summary>
        /// Optional invoice notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Optional invoice number. If no value is set, the number will be automatically generated.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Optional purchase order number.
        /// </summary>
        public string PurchaseOrder { get; set; }

        /// <summary>
        /// Value to generate URL to client dashboard.
        /// <example>
        /// https://YOURACCOUNT.harvestapp.com/clients/invoices/{CLIENTKEY}
        /// </example>
        /// </summary>
        public string ClientKey { get; set; }

        /// <summary>
        /// Updated when invoice is created, sent, paid, late, or written off.
        /// <list type="bullet">
        /// <item>
        /// <description>draft</description>
        /// </item>
        /// <item>
        /// <description>paid</description>
        /// </item>
        /// <item>
        /// <description>late</description>
        /// </item>
        /// <item>
        /// <description>sent</description>
        /// </item>
        /// <item>
        /// <description>written-off</description>
        /// </item>
        /// </list>
        /// </summary>
        public InvoiceState State { get; set; }

        /// <summary>
        /// First tax rate for created invoice. Optional. Account default used otherwise.
        /// </summary>
        public decimal? Tax { get; set; }

        /// <summary>
        /// Second tax rate for created invoice. Optional. Account default used otherwise.
        /// </summary>
        public decimal? Tax2 { get; set; }

        /// <summary>
        /// Amount which is bound to the first tax. The tax rate is defined in <see cref="Tax"/>.
        /// </summary>
        public decimal? TaxAmount { get; set; }

        /// <summary>
        /// Amount which is bound to the second tax. The tax rate is defined in <see cref="Tax2"/>.
        /// </summary>
        public decimal? TaxAmount2 { get; set; }

        /// <summary>
        /// Optional value to discount invoice total.
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// Amount of the discount on an invoice.
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// This value will exist if the invoice is recurring, and automatically generated.
        /// </summary>
        public long? RecurringInvoiceId { get; set; }

        /// <summary>
        /// This value will exist if an estimate was converted into an invoice.
        /// </summary>
        public long? EstimateId { get; set; }

        /// <summary>
        /// This value will exist if the invoice was created from a retainer.
        /// </summary>
        public long? RetainerId { get; set; }

        /// <summary>
        /// Free form items
        /// </summary>
        public string CsvLineItems { get; set; }

        private IList<InvoiceItem> _listLineItems;

        /// <summary>
        /// List of invoice items.
        /// This is used for free-form invoices.
        /// </summary>
        /// <returns>The list of invoices.</returns>
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

using Harvest.Net.Serialization;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Object for creating or updating an invoice. Only supply values for the fields you want to modify.
    /// </summary>
    [SerializeAs(Name = "invoice")]
    public class InvoiceOptions
    {
        /// <summary>
        /// A valid client-id.
        /// </summary>
        public long? ClientId { get; set; }

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
        [HarvestSerialize(DateOnly = true)]
        public DateTime? IssuedAt { get; set; }

        /// <summary>
        /// Invoice due date. Acceptable formats are NET N where N is the number of days until the invoice is due.
        /// This is implemented by <see cref="InvoiceDateAtFormat"/>.
        /// </summary>
        public InvoiceDateAtFormat? DueAtHumanFormat { get; set; }

        /// <summary>
        /// Date given which is similar to <see cref="DueAtHumanFormat"/> but rather than this type it is an instance of <see cref="DateTime"/>.
        /// </summary>
        [HarvestSerialize(DateOnly = true)]
        public DateTime? DueAt { get; set; }

        /// <summary>
        /// Optional invoice number. If no value is set, the number will be automatically generated.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Optional invoice subject.
        /// </summary>
        public string Subject { get; set; }

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
        /// Optional invoice notes.
        /// </summary>
        public string Notes { get; set; }

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
        public decimal? Tax2Amount { get; set; }

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
        public InvoiceKind? Kind { get; set; }

        /// <summary>
        /// Free form items.
        /// </summary>
        public string CsvLineItems { get; set; }

        /// <summary>
        /// Project IDs to gather data from.
        /// </summary>
        public string ProjectsToInvoice { get; set; }

        /// <summary>
        /// Which hours to import into invoices. Options:
        /// <list type="bullet">
        /// <item>
        /// <description>all</description>
        /// </item>
        /// <item>
        /// <description>yes</description>
        /// </item>
        /// <item>
        /// <description>no</description>
        /// </item>
        /// </list>
        /// For further reference, lookup: <see cref="InvoiceImportHours"/>.
        /// </summary>
        public InvoiceImportHours? ImportHours { get; set; }

        /// <summary>
        /// Date for included project hours.
        /// <example>
        /// This is an example given by the API.
        /// 2015-04-22
        /// </example>
        /// </summary>
        [HarvestSerialize(DateOnly = true)]
        public DateTime? PeriodStart { get; set; }

        /// <summary>
        /// End date for included project hours.
        /// <example>
        /// This is an example given by the API.
        /// 2015-04-22
        /// </example>
        /// </summary>
        [HarvestSerialize(DateOnly = true)]
        public DateTime? PeriodEnd { get; set; }

        /// <summary>
        /// Method to set invoice items of the invoice options.
        /// </summary>
        /// <param name="items">
        /// List of items which should be added to the invoice otions.
        /// </param>
        public void SetInvoiceItems(IList<InvoiceItem> items)
        {
            CsvLineItems = InvoiceItem.GetHeaders() + "\n" + string.Join("\n", items.Select(ii => ii.ToString()));
        }
    }
}

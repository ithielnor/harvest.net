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

                _listLineItems = new List<InvoiceItem>();

                // Null check
                if (string.IsNullOrEmpty(CsvLineItems)) return _listLineItems;

                // Get memory stream of data
                System.IO.MemoryStream stream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(CsvLineItems));

                // Use the inbuildt .NET CSV parser
                Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(stream);
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(",");

                List<string> headers = new List<string>();
                int lineindex = 0;
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    int fieldindex = 0;
                    InvoiceItem invocieitem = null;
                    foreach (string field in fields)
                    {
                        // Header, or content?
                        if (lineindex == 0)
                        {
                            headers.Add(field);
                        }
                        else
                        {
                            if (invocieitem == null) invocieitem = new InvoiceItem();

                            // Parse by header name
                            switch (headers[fieldindex])
                            {
                                case "kind": invocieitem.Kind = field; break;
                                case "description": invocieitem.Description = field; break;
                                case "quantity": invocieitem.Quantity = decimal.Parse(field, System.Globalization.CultureInfo.InvariantCulture); break;
                                case "unit_price": invocieitem.UnitPrice = decimal.Parse(field, System.Globalization.CultureInfo.InvariantCulture); break;
                                case "amount": invocieitem.Amount  = decimal.Parse(field, System.Globalization.CultureInfo.InvariantCulture); break;
                                case "taxed": invocieitem.Taxed = bool.Parse(field); break;
                                case "taxed2": invocieitem.Taxed2 = bool.Parse(field); break;
                                case "project_id": invocieitem.ProjectId = (string.IsNullOrEmpty(field) ? 0 : long.Parse(field)); break;
                            }

                        }
                        fieldindex++;
                    }
                    lineindex++;
                    if (invocieitem != null) _listLineItems.Add(invocieitem);
                }
                parser.Close();
            }
            return _listLineItems;
        }
    }
}

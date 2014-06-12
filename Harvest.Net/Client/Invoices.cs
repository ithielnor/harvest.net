using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        /// <summary>
        /// Retrieve a list of invoices from the authenticated account. Makes a GET request to the Invoices resource.
        /// </summary>
        /// <param name="page">The page to retrieve (1-based)</param>
        /// <param name="from">The earliest date of invoices to retrieve</param>
        /// <param name="to">The latest date of invoices to retrieve</param>
        /// <param name="updatedSince">The earliest update date of invoices to retrieve</param>
        /// <param name="status">The status of invoices to retrieve</param>
        /// <param name="clientId">The client ID of invoices to retrieve</param>
        public IList<Invoice> ListInvoices(int page = 1, DateTime? from = null, DateTime? to = null, DateTime? updatedSince = null, InvoiceState? status = null, long? clientId = null)
        {
            var request = Request("invoices");

            if (page > 1)
                request.AddParameter("page", page);

            if (from != null)
                request.AddParameter("from", from.Value.ToString("yyyyMMdd"));
            if (to != null)
                request.AddParameter("to", to.Value.ToString("yyyyMMdd"));

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            if (status != null)
                request.AddParameter("status", status.Value.ToString().ToLower());

            if (clientId != null)
                request.AddParameter("client", clientId.Value);

            return Execute<List<Invoice>>(request);
        }

        /// <summary>
        /// Retrieve an invoice from the authenticated account. Makes a GET request to the Invoices resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to retrieve</param>
        public Invoice Invoice(long invoiceId)
        {
            var request = Request("invoices/" + invoiceId, rootElement: "invoice");

            return Execute<Invoice>(request);
        }

        /// <summary>
        /// Create a new invoice on the authenticated account. Makes both a POST and a GET request to the Invoices resource.
        /// </summary>
        /// <param name="kind">The kind of invoice to create</param>
        /// <param name="clientId">The client the new invoice is for</param>
        /// <param name="issuedAt">The date the invoice should be issued</param>
        /// <param name="dueAt">The date the invoice should be due</param>
        /// <param name="currency">The currency of the invoice</param>
        /// <param name="subject">The invoice subject</param>
        /// <param name="notes">Notes to include on the invoice</param>
        /// <param name="number">The number for the invoice</param>
        /// <param name="projectIds">The IDs of projects to include in the invoice (useless for FreeForm invoices)</param>
        /// <param name="lineItems">A collection of line items for the invoice (only for FreeForm invoices)</param>
        public Invoice CreateInvoice(InvoiceKind kind, long clientId, DateTime issuedAt, 
            DateTime? dueAt = null, Currency? currency = null, string subject = null, string notes = null, string number = null, long[] projectIds = null, List<InvoiceItem> lineItems = null)
        {
            var invoice = new InvoiceOptions()
            {
                Kind = kind,
                ClientId = clientId,
                IssuedAt = issuedAt,
                DueAt = dueAt,
                Currency = currency,
                Subject = subject,
                Notes = notes,
                Number = number,
                ProjectsToInvoice = string.Join(",", projectIds.Select(id => id.ToString())),
            };

            invoice.SetInvoiceItems(lineItems);

            return CreateInvoice(invoice);
        }

        /// <summary>
        /// Create a new invoice on the authenticated account. Makes both a POST and a GET request to the Invoices resource.
        /// </summary>
        /// <param name="options">The options for the new invoice to create</param>
        public Invoice CreateInvoice(InvoiceOptions options)
        {
            var request = Request("invoices", RestSharp.Method.POST, "invoice");

            request.AddBody(options);

            return Execute<Invoice>(request);
        }

        /// <summary>
        /// Delete an invoice from the authenticated account. Makes a DELETE request to the Invoices resource.
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public bool DeleteInvoice(long invoiceId)
        {
            var request = Request("invoices/" + invoiceId, RestSharp.Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        } 

        /// <summary>
        /// Update an existing invoice on the authenticated account. Makes both a PUT and a GET request to the Invoices resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to update</param>
        /// <param name="options">The fields to be updated</param>
        public Invoice UpdateInvoice(long invoiceId, InvoiceOptions options)
        {
            var request = Request("invoices/" + invoiceId, RestSharp.Method.PUT, "invoice");

            request.AddBody(options);

            return Execute<Invoice>(request);
        }
    }
}

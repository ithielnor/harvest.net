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
        // https://github.com/harvesthq/api/blob/master/Sections/Invoice%20Messages.md

        /// <summary>
        /// Retrieve a list of messages for an invoice on the authenticated account. Makes a GET request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to retrieve messages for</param>
        public IList<InvoiceMessage> ListInvoiceMessages(long invoiceId)
        {
            var request = Request("invoices/" + invoiceId + "/messages");

            return Execute<List<InvoiceMessage>>(request);
        }

        /// <summary>
        /// Retrieve a single message for an invoice on the authenticated account. Makes a GET request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice the message is on</param>
        /// <param name="messageId">The ID of the message to retrieve</param>
        public InvoiceMessage InvoiceMessage(long invoiceId, long messageId)
        {
            var request = Request("invoices/" + invoiceId + "/messages/" + messageId);

            return Execute<InvoiceMessage>(request);
        }

        /// <summary>
        /// Send an existing invoice to a list of recipients. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to send</param>
        /// <param name="recipients">The email addresses of the recipients</param>
        /// <param name="body">The body of the message</param>
        /// <param name="sendMeACopy">Whether to send a copy of the invoice to the authenticated user</param>
        /// <param name="attachPdf">Whether to attach a pdf copy of the invoice to the email(s)</param>
        public InvoiceMessage SendInvoice(long invoiceId, string recipients, string body = null, bool sendMeACopy = true, bool attachPdf = true, bool includeLink = false)
        {
            var options = new InvoiceMessageOptions()
            {
                Recipients = recipients,
                Body = body,
                SendMeACopy = sendMeACopy,
                AttachPdf = attachPdf,
                IncludePayPalLink = includeLink
            };

            return SendInvoice(invoiceId, options);
        }

        /// <summary>
        /// Send an existing invoice to a list of recipients. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to send</param>
        /// <param name="options">The options of the message to send</param>
        public InvoiceMessage SendInvoice(long invoiceId, InvoiceMessageOptions options)
        {
            var request = Request("invoices/" + invoiceId + "/messages", RestSharp.Method.POST);

            request.AddBody(options);

            return Execute<InvoiceMessage>(request);
        }

        /// <summary>
        /// Delete an existing invoice message from the authenticated account. Makes a DELETE request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice containing the message</param>
        /// <param name="messageId">The ID of the message to delete</param>
        public bool DeleteInvoiceMessage(long invoiceId, long messageId)
        {
            var request = Request("invoices/" + invoiceId + "/messages/" + messageId, RestSharp.Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Mark an existing invoice from the authenticated account as closed (written-off). Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to close</param>
        /// <param name="body">The message body</param>
        public bool MarkInvoiceClosed(long invoiceId, string body)
        {
            return _createInvoiceMessageAction(invoiceId, body, "mark_as_closed");
        }

        /// <summary>
        /// Mark an existing invoice from the authenticated account as sent. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to mark as sent</param>
        /// <param name="body">The message body</param>
        public bool MarkInvoiceSent(long invoiceId, string body)
        {
            return _createInvoiceMessageAction(invoiceId, body, "mark_as_sent");
        }

        /// <summary>
        /// Mark an existing invoice from the authenticated account as draft. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to mark as draft</param>
        public bool MarkInvoiceDraft(long invoiceId)
        {
            return _createInvoiceMessageAction(invoiceId, null, "mark_as_draft");
        }

        /// <summary>
        /// Mark an existing invoice from the authenticated account as open. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to open</param>
        /// <param name="body">The message body</param>
        public bool ReopenInvoice(long invoiceId, string body)
        {
            return _createInvoiceMessageAction(invoiceId, body, "re_open");
        }

        private bool _createInvoiceMessageAction(long invoiceId, string body, string action)
        {
            var request = Request("invoices/" + invoiceId + "/messages/" + action, RestSharp.Method.POST);

            var options = new InvoiceMessageOptions()
            {
                Body = body
            };

            request.AddBody(options);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}

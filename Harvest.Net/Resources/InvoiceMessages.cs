using Harvest.Net.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        private const string MESSAGES_SUBRESOURCE = "messages";
        private const string MARK_AS_CLOSED_ACTION = "mark_as_closed";
        private const string MARK_AS_SENT_ACTION = "mark_as_sent";
        private const string MARK_AS_DRAFT_ACTION = "mark_as_draft";
        private const string REOPEN_ACTION = "re_open";

        // https://github.com/harvesthq/api/blob/master/Sections/Invoice%20Messages.md

        /// <summary>
        /// Retrieve a list of messages for an invoice on the authenticated account. Makes a GET request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to retrieve messages for</param>
        public IList<InvoiceMessage> ListInvoiceMessages(long invoiceId)
        {
            var request = Request(INVOICES_RESOURCE, invoiceId, MESSAGES_SUBRESOURCE, Method.GET);

            return Execute<List<InvoiceMessage>>(request);
        }

        /// <summary>
        /// Retrieve a list of messages for an invoice on the authenticated account. Makes a GET request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to retrieve messages for</param>
        public async Task<IList<InvoiceMessage>> ListInvoiceMessagesAsync(long invoiceId)
        {
            var request = Request(INVOICES_RESOURCE, invoiceId, MESSAGES_SUBRESOURCE, Method.GET);

            // ReSharper disable once AsyncConverter.AsyncAwaitMayBeElidedHighlighting
            return await ExecuteAsync<List<InvoiceMessage>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve a single message for an invoice on the authenticated account. Makes a GET request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice the message is on</param>
        /// <param name="messageId">The ID of the message to retrieve</param>
        public InvoiceMessage InvoiceMessage(long invoiceId, long messageId)
        {
            var request = Request(INVOICES_RESOURCE, invoiceId, $"{MESSAGES_SUBRESOURCE}/{messageId}", Method.GET);

            return Execute<InvoiceMessage>(request);
        }

        /// <summary>
        /// Retrieve a single message for an invoice on the authenticated account. Makes a GET request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice the message is on</param>
        /// <param name="messageId">The ID of the message to retrieve</param>
        public Task<InvoiceMessage> InvoiceMessageAsync(long invoiceId, long messageId)
        {
            var request = Request(INVOICES_RESOURCE, invoiceId, $"{MESSAGES_SUBRESOURCE}/{messageId}", Method.GET);

            return ExecuteAsync<InvoiceMessage>(request);
        }

        /// <summary>
        /// Send an existing invoice to a list of recipients. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to send</param>
        /// <param name="recipients">The email addresses of the recipients</param>
        /// <param name="body">The body of the message</param>
        /// <param name="sendMeACopy">Whether to send a copy of the invoice to the authenticated user</param>
        /// <param name="attachPdf">Whether to attach a pdf copy of the invoice to the email(s)</param>
        /// <param name="includePayPalLink">Set to true to include a link to the client dashboard, so the client can pay the invoice online with the payment gateway you’ve previously set up.</param>
        public InvoiceMessage SendInvoice(long invoiceId, string recipients, string body = null, bool sendMeACopy = true, bool attachPdf = true, bool includePayPalLink = false)
        {
            var options = GetInvoiceMessageOptions(recipients, body, sendMeACopy, attachPdf, includePayPalLink);

            return SendInvoice(invoiceId, options);
        }

        /// <summary>
        /// Send an existing invoice to a list of recipients. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to send</param>
        /// <param name="recipients">The email addresses of the recipients</param>
        /// <param name="body">The body of the message</param>
        /// <param name="sendMeACopy">Whether to send a copy of the invoice to the authenticated user</param>
        /// <param name="attachPdf">Whether to attach a pdf copy of the invoice to the email(s)</param>
        /// <param name="includePayPalLink">Set to true to include a link to the client dashboard, so the client can pay the invoice online with the payment gateway you’ve previously set up.</param>
        public Task<InvoiceMessage> SendInvoiceAsync(long invoiceId, string recipients, string body = null, bool sendMeACopy = true, bool attachPdf = true, bool includePayPalLink = false)
        {
            var options = GetInvoiceMessageOptions(recipients, body, sendMeACopy, attachPdf, includePayPalLink);

            return SendInvoiceAsync(invoiceId, options);
        }

        /// <summary>
        /// Send an existing invoice to a list of recipients. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to send</param>
        /// <param name="options">The options of the message to send</param>
        public InvoiceMessage SendInvoice(long invoiceId, InvoiceMessageOptions options)
        {
            var request = CreateRequest(INVOICES_RESOURCE, invoiceId, MESSAGES_SUBRESOURCE, options);
            
            return Execute<InvoiceMessage>(request);
        }

        /// <summary>
        /// Send an existing invoice to a list of recipients. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to send</param>
        /// <param name="options">The options of the message to send</param>
        public Task<InvoiceMessage> SendInvoiceAsync(long invoiceId, InvoiceMessageOptions options)
        {
            var request = CreateRequest(INVOICES_RESOURCE, invoiceId, MESSAGES_SUBRESOURCE, options);

            return ExecuteAsync<InvoiceMessage>(request);
        }

        /// <summary>
        /// Delete an existing invoice message from the authenticated account. Makes a DELETE request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice containing the message</param>
        /// <param name="messageId">The ID of the message to delete</param>
        public bool DeleteInvoiceMessage(long invoiceId, long messageId)
        {
            var request = Request(INVOICES_RESOURCE, invoiceId, $"{MESSAGES_SUBRESOURCE}/{messageId}", Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Delete an existing invoice message from the authenticated account. Makes a DELETE request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice containing the message</param>
        /// <param name="messageId">The ID of the message to delete</param>
        public async Task<bool> DeleteInvoiceMessageAsync(long invoiceId, long messageId)
        {
            var request = Request(INVOICES_RESOURCE, invoiceId, $"{MESSAGES_SUBRESOURCE}/{messageId}", Method.DELETE);

            var result = await ExecuteAsync(request).ConfigureAwait(false);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Mark an existing invoice from the authenticated account as closed (written-off). Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to close</param>
        /// <param name="body">The message body</param>
        public bool MarkInvoiceClosed(long invoiceId, string body)
        {
            return CreateInvoiceMessageAction(invoiceId, body, MARK_AS_CLOSED_ACTION);
        }

        /// <summary>
        /// Mark an existing invoice from the authenticated account as closed (written-off). Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to close</param>
        /// <param name="body">The message body</param>
        public Task<bool> MarkInvoiceClosedAsync(long invoiceId, string body)
        {
            return CreateInvoiceMessageActionAsync(invoiceId, body, MARK_AS_CLOSED_ACTION);
        }

        /// <summary>
        /// Mark an existing invoice from the authenticated account as sent. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to mark as sent</param>
        /// <param name="body">The message body</param>
        public bool MarkInvoiceSent(long invoiceId, string body)
        {
            return CreateInvoiceMessageAction(invoiceId, body, MARK_AS_SENT_ACTION);
        }

        /// <summary>
        /// Mark an existing invoice from the authenticated account as sent. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to mark as sent</param>
        /// <param name="body">The message body</param>
        public Task<bool> MarkInvoiceSentAsync(long invoiceId, string body)
        {
            return CreateInvoiceMessageActionAsync(invoiceId, body, MARK_AS_SENT_ACTION);
        }

        /// <summary>
        /// Mark an existing invoice from the authenticated account as draft. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to mark as draft</param>
        public bool MarkInvoiceDraft(long invoiceId)
        {
            return CreateInvoiceMessageAction(invoiceId, null, MARK_AS_DRAFT_ACTION);
        }

        /// <summary>
        /// Mark an existing invoice from the authenticated account as draft. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to mark as draft</param>
        public Task<bool> MarkInvoiceDraftAsync(long invoiceId)
        {
            return CreateInvoiceMessageActionAsync(invoiceId, null, MARK_AS_DRAFT_ACTION);
        }

        /// <summary>
        /// Mark an existing invoice from the authenticated account as open. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to open</param>
        /// <param name="body">The message body</param>
        public bool ReopenInvoice(long invoiceId, string body)
        {
            return CreateInvoiceMessageAction(invoiceId, body, REOPEN_ACTION);
        }

        /// <summary>
        /// Mark an existing invoice from the authenticated account as open. Makes a POST request to the Invoices/Messages resource.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to open</param>
        /// <param name="body">The message body</param>
        public Task<bool> ReopenInvoiceAsync(long invoiceId, string body)
        {
            return CreateInvoiceMessageActionAsync(invoiceId, body, REOPEN_ACTION);
        }

        private bool CreateInvoiceMessageAction(long invoiceId, string body, string action)
        {
            var request = CreateInvoiceMessageActionRequest(invoiceId, body, action);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        private async Task<bool> CreateInvoiceMessageActionAsync(long invoiceId, string body, string action)
        {
            var request = CreateInvoiceMessageActionRequest(invoiceId, body, action);

            var result = await ExecuteAsync(request).ConfigureAwait(false);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        private IRestRequest CreateInvoiceMessageActionRequest(long invoiceId, string body, string action)
        {
            var request = Request(INVOICES_RESOURCE, invoiceId, $"{MESSAGES_SUBRESOURCE}/{action}", Method.POST);

            var options = new InvoiceMessageOptions
            {
                Body = body
            };

            request.AddBody(options);

            return request;
        }

        private static InvoiceMessageOptions GetInvoiceMessageOptions(string recipients, string body, bool sendMeACopy, bool attachPdf, bool includePayPalLink)
        {
            return new InvoiceMessageOptions
            {
                Recipients = recipients,
                Body = body,
                SendMeACopy = sendMeACopy,
                AttachPdf = attachPdf,
                IncludePayPalLink = includePayPalLink
            };
        }
    }
}

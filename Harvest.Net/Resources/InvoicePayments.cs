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
        // https://github.com/harvesthq/api/blob/master/Sections/Invoice%20Payments.md

        /// <summary>
        /// List all invoice payments for and invoice on the authenticated account. Makes a GET request to the Invoices/Payments resource.
        /// </summary>
        /// <param name="invoiceId">The Id of the invoice for which to list payments</param>
        public IList<Payment> ListPayments(long invoiceId)
        {
            var request = Request("invoices/" + invoiceId + "/payments");

            return Execute<List<Payment>>(request);
        }

        /// <summary>
        /// List all invoice payments for and invoice on the authenticated account. Makes a GET request to the Invoices/Payments resource.
        /// </summary>
        /// <param name="invoiceId">The Id of the invoice for which to list payments</param>
        public async Task<IList<Payment>> ListPaymentsAsync(long invoiceId)
        {
            var request = Request("invoices/" + invoiceId + "/payments");

            // ReSharper disable once AsyncConverter.AsyncAwaitMayBeElidedHighlighting
            return await ExecuteAsync<List<Payment>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve an invoice payment on the authenticated account. Makes a GET request to the Invoices/Payments resource.
        /// </summary>
        /// <param name="invoiceId">The Id of the invoice on which the payment exists</param>
        /// <param name="paymentId">The Id of the payment to retrieve</param>
        public Payment Payment(long invoiceId, long paymentId)
        {
            var request = Request("invoices/" + invoiceId + "/payments/" + paymentId);

            return Execute<Payment>(request);
        }

        /// <summary>
        /// Retrieve an invoice payment on the authenticated account. Makes a GET request to the Invoices/Payments resource.
        /// </summary>
        /// <param name="invoiceId">The Id of the invoice on which the payment exists</param>
        /// <param name="paymentId">The Id of the payment to retrieve</param>
        public Task<Payment> PaymentAsync(long invoiceId, long paymentId)
        {
            var request = Request("invoices/" + invoiceId + "/payments/" + paymentId);

            return ExecuteAsync<Payment>(request);
        }

        /// <summary>
        /// Creates a new payment under the authenticated account. Makes both a POST and a GET request to the Invoices/Payments resource.
        /// </summary>
        /// <param name="invoiceId">The Id of the invoice being paid</param>
        /// <param name="amount">The amount of the payment</param>
        /// <param name="paidAt">The the date of the payment</param>
        /// <param name="notes">Notes on the payment</param>
        public Payment CreatePayment(long invoiceId, decimal amount, DateTime paidAt, string notes = null)
        {
            var newPayment = new PaymentOptions()
            {
                Amount = amount,
                PaidAt = paidAt,
                Notes = notes
            };

            return CreatePayment(invoiceId, newPayment);
        }

        /// <summary>
        /// Creates a new payment under the authenticated account. Makes both a POST and a GET request to the Invoices/Payments resource.
        /// </summary>
        /// <param name="invoiceId">The Id of the invoice being paid</param>
        /// <param name="amount">The amount of the payment</param>
        /// <param name="paidAt">The the date of the payment</param>
        /// <param name="notes">Notes on the payment</param>
        public Task<Payment> CreatePaymentAsync(long invoiceId, decimal amount, DateTime paidAt, string notes = null)
        {
            var newPayment = new PaymentOptions()
            {
                Amount = amount,
                PaidAt = paidAt,
                Notes = notes
            };

            return CreatePaymentAsync(invoiceId, newPayment);
        }

        /// <summary>
        /// Creates a new payment under the authenticated account. Makes a POST and a GET request to the Invoices/Payments resource.
        /// </summary>
        /// <param name="invoiceId">The Id of the invoice being paid</param>
        /// <param name="options">The options for the new payment to be created</param>
        public Payment CreatePayment(long invoiceId, PaymentOptions options)
        {
            var request = Request("invoices/" + invoiceId + "/payments", RestSharp.Method.POST);

            request.AddBody(options);

            return Execute<Payment>(request);
        }

        /// <summary>
        /// Creates a new payment under the authenticated account. Makes a POST and a GET request to the Invoices/Payments resource.
        /// </summary>
        /// <param name="invoiceId">The Id of the invoice being paid</param>
        /// <param name="options">The options for the new payment to be created</param>
        public Task<Payment> CreatePaymentAsync(long invoiceId, PaymentOptions options)
        {
            var request = Request("invoices/" + invoiceId + "/payments", RestSharp.Method.POST);

            request.AddBody(options);

            return ExecuteAsync<Payment>(request);
        }

        /// <summary>
        /// Delete a payment from the authenticated account. Makes a DELETE request to the Invoices/Payments resource.
        /// </summary>
        /// <param name="invoiceId">The Id of the invoice containing the payment to be deleted</param>
        /// <param name="paymentId">The Id of the payment to delete</param>
        public bool DeletePayment(long invoiceId, long paymentId)
        {
            var request = Request("invoices/" + invoiceId + "/payments/" + paymentId, RestSharp.Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Delete a payment from the authenticated account. Makes a DELETE request to the Invoices/Payments resource.
        /// </summary>
        /// <param name="invoiceId">The Id of the invoice containing the payment to be deleted</param>
        /// <param name="paymentId">The Id of the payment to delete</param>
        public async Task<bool> DeletePaymentAsync(long invoiceId, long paymentId)
        {
            var request = Request("invoices/" + invoiceId + "/payments/" + paymentId, RestSharp.Method.DELETE);

            var result = await ExecuteAsync(request).ConfigureAwait(false);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}

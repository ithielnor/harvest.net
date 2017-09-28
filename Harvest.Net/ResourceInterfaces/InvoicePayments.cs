using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        IList<Payment> ListPayments(long invoiceId);

        Task<IList<Payment>> ListPaymentsAsync(long invoiceId);

        Payment Payment(long invoiceId, long paymentId);

        Task<Payment> PaymentAsync(long invoiceId, long paymentId);

        Payment CreatePayment(long invoiceId, decimal amount, DateTime paidAt, string notes = null);

        Task<Payment> CreatePaymentAsync(long invoiceId, decimal amount, DateTime paidAt, string notes = null);

        Payment CreatePayment(long invoiceId, PaymentOptions options);

        Task<Payment> CreatePaymentAsync(long invoiceId, PaymentOptions options);

        bool DeletePayment(long invoiceId, long paymentId);

        Task<bool> DeletePaymentAsync(long invoiceId, long paymentId);
    }
}

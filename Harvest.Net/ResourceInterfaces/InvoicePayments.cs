using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        List<Payment> ListPayments(long invoiceId);

        Payment Payment(long invoiceId, long paymentId);

        Payment CreatePayment(long invoiceId, decimal amount, DateTime paidAt, string notes = null);

        Payment CreatePayment(long invoiceId, PaymentOptions options);

        bool DeletePayment(long invoiceId, long paymentId);
    }
}

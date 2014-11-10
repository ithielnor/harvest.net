using Harvest.Net.Models;
using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class InvoicePaymentFacts : FactBase, IDisposable
    {
        Payment _todelete = null;
        
        [Fact]
        public void ListPayments_Returns()
        {
            var list = Api.ListPayments(GetTestId(TestId.InvoiceId));

            Assert.True(list != null, "Result list is null.");
            Assert.NotEqual(0, list.First().Id);
        }

        [Fact]
        public void Payment_ReturnsPayment()
        {
            var Payment = Api.Payment(GetTestId(TestId.InvoiceId), GetTestId(TestId.PaymentId));

            Assert.NotNull(Payment);
            Assert.Equal("TEST PAYMENT DO NOT DELETE", Payment.Notes);
        }

        [Fact]
        public void DeletePayment_ReturnsTrue()
        {
            var Payment = Api.CreatePayment(GetTestId(TestId.InvoiceId), 1, DateTime.Now, "Test Delete Payment");

            var result = Api.DeletePayment(Payment.InvoiceId, Payment.Id);

            Assert.Equal(true, result);
        }

        [Fact]
        public void CreatePayment_ReturnsANewPayment()
        {
            _todelete = Api.CreatePayment(GetTestId(TestId.InvoiceId), 1, DateTime.Now, "Test Create Payment");

            Assert.Equal("Test Create Payment", _todelete.Notes);
        }

        public void Dispose()
        {
            if (_todelete != null)
                Api.DeletePayment(_todelete.InvoiceId, _todelete.Id);
        }
    }
}

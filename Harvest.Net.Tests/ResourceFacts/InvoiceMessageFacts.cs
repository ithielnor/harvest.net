using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class InvoiceMessageFacts : FactBase, IDisposable
    {
        InvoiceMessage _toDeleteMessage = null;
        Invoice _toDeleteInvoice = null;

        [Fact]
        public void ListInvoiceMessages_Returns()
        {
            var invoice = Api.Invoice(GetTestId(TestId.InvoiceId));

            var messages = Api.ListInvoiceMessages(invoice.Id);

            Assert.NotNull(messages);
            Assert.NotEqual(0, messages.First().Id);
        }

        [Fact]
        public void InvoiceMessage_Returns()
        {
            var invoice = Api.Invoice(GetTestId(TestId.InvoiceId));

            var message = Api.InvoiceMessage(invoice.Id, Api.ListInvoiceMessages(invoice.Id).First().Id);

            Assert.NotNull(message);
            Assert.NotEqual(0, message.Id);
        }

        [Fact]
        public void StateChangesApply()
        {
            var invoice = Api.CreateInvoice(InvoiceKind.FreeForm, GetTestId(TestId.ClientId), DateTime.Now, lineItems: new List<InvoiceItem>());
            _toDeleteInvoice = invoice;

            Assert.Equal(InvoiceState.Draft, invoice.State);

            // test send
            var success = Api.MarkInvoiceSent(invoice.Id, "MARK AS SENT");
            var messages = Api.ListInvoiceMessages(invoice.Id);
            invoice = Api.Invoice(invoice.Id);

            Assert.True(success);
            Assert.Contains("MARK AS SENT", messages.Select(m => m.Body));
            Assert.Equal(InvoiceState.Open, invoice.State);

            // test draft
            success = Api.MarkInvoiceDraft(invoice.Id);
            invoice = Api.Invoice(invoice.Id);

            Assert.True(success);
            Assert.Equal(InvoiceState.Draft, invoice.State);

            // test close
            Api.MarkInvoiceSent(invoice.Id, null);
            success = Api.MarkInvoiceClosed(invoice.Id, "MARK AS CLOSED");
            messages = Api.ListInvoiceMessages(invoice.Id);
            invoice = Api.Invoice(invoice.Id);

            Assert.True(success);
            Assert.Contains("MARK AS CLOSED", messages.Select(m => m.Body));
            Assert.Equal(InvoiceState.Closed, invoice.State);

            // test reopen
            success = Api.ReopenInvoice(invoice.Id, "RE-OPEN");
            messages = Api.ListInvoiceMessages(invoice.Id);
            invoice = Api.Invoice(invoice.Id);

            Assert.True(success);
            //Assert.Contains("RE-OPEN", messages.Select(m => m.Body)); I think there is a bug in Harvest. The body does not get saved on reopen.
            Assert.Equal(InvoiceState.Open, invoice.State);
        }


        public void Dispose()
        {
            if (_toDeleteMessage != null)
                Api.DeleteInvoiceMessage(_toDeleteMessage.InvoiceId, _toDeleteMessage.Id);

            if (_toDeleteInvoice != null)
                Api.DeleteInvoice(_toDeleteInvoice.Id);
        }
    }
}

using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class InvoiceMessageFacts : FactBase, IDisposable
    {
        InvoiceMessage _toDelete = null;

        [Fact]
        public void ListInvoiceMessages_Returns()
        {
            var invoice = Api.Invoice(4861513);

            var messages = Api.ListInvoiceMessages(invoice.Id);

            Assert.NotNull(messages);
            Assert.NotEqual(0, messages.First().Id);
        }

        [Fact]
        public void InvoiceMessage_Returns()
        {
            var invoice = Api.Invoice(4861513);

            var message = Api.InvoiceMessage(invoice.Id, Api.ListInvoiceMessages(invoice.Id).First().Id);

            Assert.NotNull(message);
            Assert.NotEqual(0, message.Id);
        }


        public void Dispose()
        {
            if (_toDelete != null)
                Api.DeleteInvoiceMessage(_toDelete.InvoiceId, _toDelete.Id);
        }
    }
}

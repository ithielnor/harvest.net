using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class InvoiceFacts : FactBase
    {
        [Fact]
        public void ListInvoices_Returns()
        {
            var list = Api.ListInvoices();

            Assert.True(list != null, "Result list is null.");
        }

        //[Fact]
        //public void CreateInvoice_ReturnsANewInvoice()
        //{
        //    var invoice = Client.CreateInvoice();

        //    TearDownEvents.Add(() =>
        //    {
        //        Client.DeleteInvoice(invoice);

        //        return true;
        //    });
        //}
    }
}

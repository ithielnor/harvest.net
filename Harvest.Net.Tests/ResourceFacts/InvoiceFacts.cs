using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class InvoiceFacts : FactBase, IDisposable
    {
        Invoice _toDelete = null;
        const long _test = 4861513; // TODO: move this into a config file

        [Fact]
        public void ListInvoices_Returns()
        {
            var list = Api.ListInvoices();

            Assert.True(list != null, "Result list is null.");
            Assert.NotEqual(0, list.First().Id);
        }

        [Fact]
        public void Invoice_ReturnsInvoice()
        {
            var invoice = Api.Invoice(GetTestId(TestId.InvoiceId));

            Assert.NotNull(invoice);
        }

        [Fact]
        public void CreateInvoice_ReturnsNewInvoice()
        {
            var client = Api.ListClients().First();

            _toDelete = Api.CreateInvoice(new InvoiceOptions()
            {
                ClientId = client.Id,
                Subject = "Test Create Invoice"
            });

            Assert.NotEqual(0, _toDelete.Id);
            Assert.Equal("Test Create Invoice", _toDelete.Subject);
            Assert.Equal(client.Id, _toDelete.ClientId);
        }

        [Fact]
        public void DeleteInvoice_ReturnsTrue()
        {
            var client = Api.ListClients().First();

            var invoice = Api.CreateInvoice(new InvoiceOptions()
            {
                ClientId = client.Id,
                Subject = "Test Delete Invoice"
            });

            var result = Api.DeleteInvoice(invoice.Id);

            Assert.Equal(true, result);
        }

        [Fact]
        public void UpdateInvoice_ReturnsUpdatedInvoice()
        {
            var client = Api.ListClients().First();

            var invoice = Api.CreateInvoice(new InvoiceOptions()
            {
                ClientId = client.Id,
                Subject = "Test Update Invoice",
                Notes = "Notes",
                IssuedAt = DateTime.Now.AddDays(-1),
                DueAtHumanFormat = InvoiceDateAtFormat.Net15
            });

            Assert.Equal(DateTime.Now.AddDays(14).ToString("yyyy-MM-dd"), invoice.DueAt.ToString("yyyy-MM-dd"));
            Assert.Equal(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), invoice.IssuedAt.ToString("yyyy-MM-dd"));

            // REVIEW: Bugs in the api currently prevent setting the due-at date.
            // https://github.com/harvesthq/api/issues/66

            var updated = Api.UpdateInvoice(invoice.Id, new InvoiceOptions()
            {
                Subject = "Tested",
                //DueAtHumanFormat = InvoiceDateAtFormat.Custom,
                //DueAt = DateTime.Now.AddDays(10)
            });

            _toDelete = invoice;

            // fields that changed
            Assert.Equal("Tested", updated.Subject);
            //Assert.Equal(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), updated.IssuedAt.ToString("yyyy-MM-dd"));
            //Assert.Equal(DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"), updated.DueAt.ToString("yyyy-MM-dd"));

            // fields that didn't change
            Assert.Equal(invoice.ClientId, updated.ClientId);
            Assert.Equal(invoice.Notes, updated.Notes);
        }

        [Fact]
        public void CreateInvoice_WithItemsContainsItems()
        {
            var client = Api.ListClients().First();

            var options = new InvoiceOptions()
            {
                ClientId = client.Id,
                Subject = "Test Items Invoice",
                Kind = InvoiceKind.FreeForm
            };

            options.SetInvoiceItems(new List<InvoiceItem>()
            {
                new InvoiceItem() { Kind = "Product", Description = "Description 1", Quantity = 1, Amount = 10 },
                new InvoiceItem() { Kind = "Product", Description = "Description 2", Quantity = 2, Amount = 10 }
            });

            _toDelete = Api.CreateInvoice(options);

            Assert.Equal(2, _toDelete.ListLineItems().Count());
        }

        public void Dispose()
        {
            if (_toDelete != null)
                Api.DeleteInvoice(_toDelete.Id);
        }
    }
}

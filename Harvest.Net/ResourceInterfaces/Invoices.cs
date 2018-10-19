using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        IList<Invoice> ListInvoices(int page = 1, DateTime? from = null, DateTime? to = null, DateTime? updatedSince = null, InvoiceState? status = null, long? clientId = null);

        Task<IList<Invoice>> ListInvoicesAsync(int page = 1, DateTime? from = null, DateTime? to = null, DateTime? updatedSince = null, InvoiceState? status = null, long? clientId = null);

        Invoice Invoice(long invoiceId);

        Task<Invoice> InvoiceAsync(long invoiceId);

        Invoice CreateInvoice(InvoiceKind kind, long clientId, DateTime issuedAt,
            DateTime? dueAt = null, Currency? currency = null, string subject = null, string notes = null, string number = null, long[] projectIds = null, List<InvoiceItem> lineItems = null);

        Task<Invoice> CreateInvoiceAsync(InvoiceKind kind, long clientId, DateTime issuedAt,
            DateTime? dueAt = null, Currency? currency = null, string subject = null, string notes = null, string number = null, long[] projectIds = null, List<InvoiceItem> lineItems = null);

        Invoice CreateInvoice(InvoiceOptions options);

        Task<Invoice> CreateInvoiceAsync(InvoiceOptions options);

        bool DeleteInvoice(long invoiceId);

        Task<bool> DeleteInvoiceAsync(long invoiceId);

        Invoice UpdateInvoice(long invoiceId, InvoiceOptions options);

        Task<Invoice> UpdateInvoiceAsync(long invoiceId, InvoiceOptions options);
    }
}

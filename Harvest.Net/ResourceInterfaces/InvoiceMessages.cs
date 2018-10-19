using System.Collections.Generic;
using System.Threading.Tasks;
using Harvest.Net.Models;

namespace Harvest.Net.ResourceInterfaces
{
    public partial interface IHarvestRestClient
    {
        IList<InvoiceMessage> ListInvoiceMessages(long invoiceId);

        Task<IList<InvoiceMessage>> ListInvoiceMessagesAsync(long invoiceId);

        InvoiceMessage InvoiceMessage(long invoiceId, long messageId);

        Task<InvoiceMessage> InvoiceMessageAsync(long invoiceId, long messageId);

        InvoiceMessage SendInvoice(long invoiceId, string recipients, string body = null, bool sendMeACopy = true, bool attachPdf = true, bool includePayPalLink = false);

        Task<InvoiceMessage> SendInvoiceAsync(long invoiceId, string recipients, string body = null, bool sendMeACopy = true, bool attachPdf = true, bool includePayPalLink = false);

        InvoiceMessage SendInvoice(long invoiceId, InvoiceMessageOptions options);

        Task<InvoiceMessage> SendInvoiceAsync(long invoiceId, InvoiceMessageOptions options);

        bool DeleteInvoiceMessage(long invoiceId, long messageId);

        Task<bool> DeleteInvoiceMessageAsync(long invoiceId, long messageId);

        bool MarkInvoiceClosed(long invoiceId, string body);

        Task<bool> MarkInvoiceClosedAsync(long invoiceId, string body);

        bool MarkInvoiceSent(long invoiceId, string body);

        Task<bool> MarkInvoiceSentAsync(long invoiceId, string body);

        bool MarkInvoiceDraft(long invoiceId);

        Task<bool> MarkInvoiceDraftAsync(long invoiceId);

        bool ReopenInvoice(long invoiceId, string body);

        Task<bool> ReopenInvoiceAsync(long invoiceId, string body);
    }
}

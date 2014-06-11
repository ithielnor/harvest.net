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
        public IList<Invoice> ListInvoices(int page = 1, DateTime? from = null, DateTime? to = null, DateTime? updatedSince = null, InvoiceState? status = null, long? clientId = null)
        {
            var request = Request("invoices");

            if (page > 1)
                request.AddParameter("page", page);

            if (from != null)
                request.AddParameter("from", from.Value.ToString("yyyyMMdd"));
            if (to != null)
                request.AddParameter("to", to.Value.ToString("yyyyMMdd"));

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            if (status != null)
                request.AddParameter("status", status.Value.ToString().ToLower());

            if (clientId != null)
                request.AddParameter("client", clientId.Value);

            return Execute<List<Invoice>>(request);
        }
    }
}

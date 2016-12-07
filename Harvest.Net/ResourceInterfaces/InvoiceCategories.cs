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
        List<InvoiceItemCategory> ListInvoiceCategories();

        InvoiceItemCategory InvoiceCategory(long invoiceCategoryId);

        InvoiceItemCategory CreateInvoiceCategory(string name, bool useAsExpense = false, bool useAsService = false);

        InvoiceItemCategory CreateInvoiceCategory(InvoiceItemCategoryOptions options);

        bool DeleteInvoiceCategory(long invoiceCategoryId);

        InvoiceItemCategory UpdateInvoiceCategory(long invoiceCategoryId, string name = null, bool? useAsExpense = null, bool? useAsService = null);

        InvoiceItemCategory UpdateInvoiceCategory(long invoiceCategoryId, InvoiceItemCategoryOptions options);
    }
}

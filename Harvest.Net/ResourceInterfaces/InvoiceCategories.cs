using Harvest.Net.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        IList<InvoiceItemCategory> ListInvoiceCategories();

        Task<IList<InvoiceItemCategory>> ListInvoiceCategoriesAsync();

        InvoiceItemCategory InvoiceCategory(long invoiceCategoryId);

        Task<InvoiceItemCategory> InvoiceCategoryAsync(long invoiceCategoryId);

        InvoiceItemCategory CreateInvoiceCategory(string name, bool useAsExpense = false, bool useAsService = false);

        Task<InvoiceItemCategory> CreateInvoiceCategoryAsync(string name, bool useAsExpense = false, bool useAsService = false);

        InvoiceItemCategory CreateInvoiceCategory(InvoiceItemCategoryOptions options);

        Task<InvoiceItemCategory> CreateInvoiceCategoryAsync(InvoiceItemCategoryOptions options);

        bool DeleteInvoiceCategory(long invoiceCategoryId);

        Task<bool> DeleteInvoiceCategoryAsync(long invoiceCategoryId);

        InvoiceItemCategory UpdateInvoiceCategory(long invoiceCategoryId, string name = null, bool? useAsExpense = null, bool? useAsService = null);

        Task<InvoiceItemCategory> UpdateInvoiceCategoryAsync(long invoiceCategoryId, string name = null, bool? useAsExpense = null, bool? useAsService = null);

        InvoiceItemCategory UpdateInvoiceCategory(long invoiceCategoryId, InvoiceItemCategoryOptions options);

        Task<InvoiceItemCategory> UpdateInvoiceCategoryAsync(long invoiceCategoryId, InvoiceItemCategoryOptions options);
    }
}

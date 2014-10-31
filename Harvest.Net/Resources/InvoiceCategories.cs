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
        // https://github.com/harvesthq/api/blob/master/Sections/Invoice%20Categories.md

        /// <summary>
        /// List all invoice categories for the authenticated account. Makes a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        public List<InvoiceItemCategory> ListInvoiceCategories()
        {
            var request = Request("invoice_item_categories");

            return Execute<List<InvoiceItemCategory>>(request);
        }

        /// <summary>
        /// Retrieve an invoice category on the authenticated account. Makes a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="InvoiceCategoryId">The Id of the invoice category to retrieve</param>
        public InvoiceItemCategory InvoiceCategory(long invoiceCategoryId)
        {
            var request = Request("invoice_item_categories/" + invoiceCategoryId);

            return Execute<InvoiceItemCategory>(request);
        }

        /// <summary>
        /// Creates a new invoice category under the authenticated account. Makes both a POST and a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="name">The name of the invoice category</param>
        /// <param name="unitName">The unit name of the invoice category (Unit name and price must be set together)</param>
        /// <param name="unitPrice">The unit price of the invoice category (Unit name and price must be set together)</param>
        public InvoiceItemCategory CreateInvoiceCategory(string name, bool useAsExpense = false, bool useAsService = false)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            var newInvoiceCategory = new InvoiceItemCategoryOptions()
            {
                Name = name,
                UseAsExpense = useAsExpense,
                UseAsService = useAsService
            };

            return CreateInvoiceCategory(newInvoiceCategory);
        }

        /// <summary>
        /// Creates a new invoice category under the authenticated account. Makes a POST and a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="options">The options for the new invoice category to be created</param>
        public InvoiceItemCategory CreateInvoiceCategory(InvoiceItemCategoryOptions options)
        {
            var request = Request("invoice_item_categories", RestSharp.Method.POST);

            request.AddBody(options);

            return Execute<InvoiceItemCategory>(request);
        }

        /// <summary>
        /// Delete an invoice category from the authenticated account. Makes a DELETE request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="invoiceCategoryId">The ID of the invoice category to delete</param>
        public bool DeleteInvoiceCategory(long invoiceCategoryId)
        {
            var request = Request("invoice_item_categories/" + invoiceCategoryId, RestSharp.Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Update a invoice category on the authenticated account. Makes a PUT and a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="invoiceCategoryId">The ID of the invoice category to update</param>
        /// <param name="name">The updated name</param>
        /// <param name="unitName">The updated unit name (Unit name and price must be set together)</param>
        /// <param name="unitPrice">The updated unit price (Unit name and price must be set together)</param>
        public InvoiceItemCategory UpdateInvoiceCategory(long invoiceCategoryId, string name = null, bool? useAsExpense = null, bool? useAsService = null)
        {
            var options = new InvoiceItemCategoryOptions()
            {
                Name = name,
                UseAsExpense = useAsExpense,
                UseAsService = useAsService
            };

            return UpdateInvoiceCategory(invoiceCategoryId, options);
        }

        /// <summary>
        /// Updates an Invoice category on the authenticated account. Makes a PUT and a GET request to the Clients resource.
        /// </summary>
        /// <param name="invoiceCategoryId">The ID for the invoice category to update</param>
        /// <param name="options">The options to be updated</param>
        public InvoiceItemCategory UpdateInvoiceCategory(long invoiceCategoryId, InvoiceItemCategoryOptions options)
        {
            var request = Request("invoice_item_categories/" + invoiceCategoryId, RestSharp.Method.PUT);

            request.AddBody(options);

            return Execute<InvoiceItemCategory>(request);
        }
    }
}

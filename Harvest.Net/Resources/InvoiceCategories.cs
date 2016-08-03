using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        private const string INVOICE_CATEGORIES_RESOURCE = "invoice_item_categories";

        // https://github.com/harvesthq/api/blob/master/Sections/Invoice%20Categories.md

        /// <summary>
        /// List all invoice categories for the authenticated account. Makes a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        public IList<InvoiceItemCategory> ListInvoiceCategories()
        {
            var request = Request(INVOICE_CATEGORIES_RESOURCE);

            return Execute<List<InvoiceItemCategory>>(request);
        }

        /// <summary>
        /// List all invoice categories for the authenticated account. Makes a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        public async Task<IList<InvoiceItemCategory>> ListInvoiceCategoriesAsync()
        {
            var request = Request(INVOICE_CATEGORIES_RESOURCE);

            return await ExecuteAsync<List<InvoiceItemCategory>>(request);
        }

        /// <summary>
        /// Retrieve an invoice category on the authenticated account. Makes a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="invoiceCategoryId">The Id of the invoice category to retrieve</param>
        public InvoiceItemCategory InvoiceCategory(long invoiceCategoryId)
        {
            var request = Request(INVOICE_CATEGORIES_RESOURCE, invoiceCategoryId, Method.GET);

            return Execute<InvoiceItemCategory>(request);
        }

        /// <summary>
        /// Retrieve an invoice category on the authenticated account. Makes a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="invoiceCategoryId">The Id of the invoice category to retrieve</param>
        public Task<InvoiceItemCategory> InvoiceCategoryAsync(long invoiceCategoryId)
        {
            var request = Request(INVOICE_CATEGORIES_RESOURCE, invoiceCategoryId, Method.GET);

            return ExecuteAsync<InvoiceItemCategory>(request);
        }

        /// <summary>
        /// Creates a new invoice category under the authenticated account. Makes both a POST and a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="name">The name of the invoice category</param>
        /// <param name="useAsExpense">Whether to use as expense</param>
        /// <param name="useAsService">Whether to use as service</param>
        public InvoiceItemCategory CreateInvoiceCategory(string name, bool useAsExpense = false, bool useAsService = false)
        {
            var newInvoiceCategory = GetInvoiceItemCategoryOptions(name, useAsExpense, useAsService);

            return CreateInvoiceCategory(newInvoiceCategory);
        }

        /// <summary>
        /// Creates a new invoice category under the authenticated account. Makes both a POST and a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="name">The name of the invoice category</param>
        /// <param name="useAsExpense">Whether to use as expense</param>
        /// <param name="useAsService">Whether to use as service</param>
        public Task<InvoiceItemCategory> CreateInvoiceCategoryAsync(string name, bool useAsExpense = false, bool useAsService = false)
        {
            var newInvoiceCategory = GetInvoiceItemCategoryOptions(name, useAsExpense, useAsService);

            return CreateInvoiceCategoryAsync(newInvoiceCategory);
        }

        /// <summary>
        /// Creates a new invoice category under the authenticated account. Makes a POST and a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="options">The options for the new invoice category to be created</param>
        public InvoiceItemCategory CreateInvoiceCategory(InvoiceItemCategoryOptions options)
        {
            var request = CreateRequest(INVOICE_CATEGORIES_RESOURCE, options);

            return Execute<InvoiceItemCategory>(request);
        }

        /// <summary>
        /// Creates a new invoice category under the authenticated account. Makes a POST and a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="options">The options for the new invoice category to be created</param>
        public Task<InvoiceItemCategory> CreateInvoiceCategoryAsync(InvoiceItemCategoryOptions options)
        {
            var request = CreateRequest(INVOICE_CATEGORIES_RESOURCE, options);

            return ExecuteAsync<InvoiceItemCategory>(request);
        }

        /// <summary>
        /// Delete an invoice category from the authenticated account. Makes a DELETE request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="invoiceCategoryId">The ID of the invoice category to delete</param>
        public bool DeleteInvoiceCategory(long invoiceCategoryId)
        {
            var request = Request(INVOICE_CATEGORIES_RESOURCE, invoiceCategoryId, Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Delete an invoice category from the authenticated account. Makes a DELETE request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="invoiceCategoryId">The ID of the invoice category to delete</param>
        public async Task<bool> DeleteInvoiceCategoryAsync(long invoiceCategoryId)
        {
            var request = Request(INVOICE_CATEGORIES_RESOURCE, invoiceCategoryId, Method.DELETE);

            var result = await ExecuteAsync(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Update a invoice category on the authenticated account. Makes a PUT and a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="invoiceCategoryId">The ID of the invoice category to update</param>
        /// <param name="name">The updated name</param>
        /// <param name="useAsExpense">Whether to use as expense</param>
        /// <param name="useAsService">Whether to use as service</param>
        public InvoiceItemCategory UpdateInvoiceCategory(long invoiceCategoryId, string name = null, bool? useAsExpense = null, bool? useAsService = null)
        {
            var options = GetInvoiceItemCategoryOptions(name, useAsExpense, useAsService);

            return UpdateInvoiceCategory(invoiceCategoryId, options);
        }

        /// <summary>
        /// Update a invoice category on the authenticated account. Makes a PUT and a GET request to the Invoice_Item_Categories resource.
        /// </summary>
        /// <param name="invoiceCategoryId">The ID of the invoice category to update</param>
        /// <param name="name">The updated name</param>
        /// <param name="useAsExpense">Whether to use as expense</param>
        /// <param name="useAsService">Whether to use as service</param>
        public Task<InvoiceItemCategory> UpdateInvoiceCategoryAsync(long invoiceCategoryId, string name = null, bool? useAsExpense = null, bool? useAsService = null)
        {
            var options = GetInvoiceItemCategoryOptions(name, useAsExpense, useAsService);

            return UpdateInvoiceCategoryAsync(invoiceCategoryId, options);
        }

        /// <summary>
        /// Updates an Invoice category on the authenticated account. Makes a PUT and a GET request to the Clients resource.
        /// </summary>
        /// <param name="invoiceCategoryId">The ID for the invoice category to update</param>
        /// <param name="options">The options to be updated</param>
        public InvoiceItemCategory UpdateInvoiceCategory(long invoiceCategoryId, InvoiceItemCategoryOptions options)
        {
            var request = UpdateRequest(INVOICE_CATEGORIES_RESOURCE, invoiceCategoryId, options);

            return Execute<InvoiceItemCategory>(request);
        }

        /// <summary>
        /// Updates an Invoice category on the authenticated account. Makes a PUT and a GET request to the Clients resource.
        /// </summary>
        /// <param name="invoiceCategoryId">The ID for the invoice category to update</param>
        /// <param name="options">The options to be updated</param>
        public Task<InvoiceItemCategory> UpdateInvoiceCategoryAsync(long invoiceCategoryId, InvoiceItemCategoryOptions options)
        {
            var request = UpdateRequest(INVOICE_CATEGORIES_RESOURCE, invoiceCategoryId, options);

            return ExecuteAsync<InvoiceItemCategory>(request);
        }

        private static InvoiceItemCategoryOptions GetInvoiceItemCategoryOptions(string name, bool? useAsExpense, bool? useAsService)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return new InvoiceItemCategoryOptions()
            {
                Name = name,
                UseAsExpense = useAsExpense,
                UseAsService = useAsService
            };
        }
    }
}

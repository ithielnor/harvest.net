using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        private const string EXPENSE_CATEGORIES_RESOURCE = "expense_categories";

        // https://github.com/harvesthq/api/blob/master/Sections/Expense%20Categories.md

        /// <summary>
        /// List all expense categories for the authenticated account. Makes a GET request to the Expense_Categories resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the updated-at property</param>
        public IList<ExpenseCategory> ListExpenseCategories(DateTime? updatedSince = null)
        {
            var request = ListRequest(EXPENSE_CATEGORIES_RESOURCE, updatedSince);
            
            return Execute<List<ExpenseCategory>>(request);
        }

        /// <summary>
        /// List all expense categories for the authenticated account. Makes a GET request to the Expense_Categories resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the updated-at property</param>
        public async Task<IList<ExpenseCategory>> ListExpenseCategoriesAsync(DateTime? updatedSince = null)
        {
            var request = ListRequest(EXPENSE_CATEGORIES_RESOURCE, updatedSince);

            // ReSharper disable once AsyncConverter.AsyncAwaitMayBeElidedHighlighting
            return await ExecuteAsync<List<ExpenseCategory>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve an expense category on the authenticated account. Makes a GET request to the Expense_Categories resource.
        /// </summary>
        /// <param name="expenseCategoryId">The Id of the expense category to retrieve</param>
        public ExpenseCategory ExpenseCategory(long expenseCategoryId)
        {
            var request = Request(EXPENSE_CATEGORIES_RESOURCE, expenseCategoryId, Method.GET);

            return Execute<ExpenseCategory>(request);
        }

        /// <summary>
        /// Retrieve an expense category on the authenticated account. Makes a GET request to the Expense_Categories resource.
        /// </summary>
        /// <param name="expenseCategoryId">The Id of the expense category to retrieve</param>
        public Task<ExpenseCategory> ExpenseCategoryAsync(long expenseCategoryId)
        {
            var request = Request(EXPENSE_CATEGORIES_RESOURCE, expenseCategoryId, Method.GET);

            return ExecuteAsync<ExpenseCategory>(request);
        }

        /// <summary>
        /// Creates a new expense category under the authenticated account. Makes both a POST and a GET request to the Expense_Categories resource.
        /// </summary>
        /// <param name="name">The name of the expense category</param>
        /// <param name="unitName">The unit name of the expense category (Unit name and price must be set together)</param>
        /// <param name="unitPrice">The unit price of the expense category (Unit name and price must be set together)</param>
        public ExpenseCategory CreateExpenseCategory(string name, string unitName = null, decimal? unitPrice = null)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var newExpenseCategory = GetExpenseCategoryOptions(name, unitName, unitPrice);

            return CreateExpenseCategory(newExpenseCategory);
        }

        /// <summary>
        /// Creates a new expense category under the authenticated account. Makes both a POST and a GET request to the Expense_Categories resource.
        /// </summary>
        /// <param name="name">The name of the expense category</param>
        /// <param name="unitName">The unit name of the expense category (Unit name and price must be set together)</param>
        /// <param name="unitPrice">The unit price of the expense category (Unit name and price must be set together)</param>
        public Task<ExpenseCategory> CreateExpenseCategoryAsync(string name, string unitName = null, decimal? unitPrice = null)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var newExpenseCategory = GetExpenseCategoryOptions(name, unitName, unitPrice);

            return CreateExpenseCategoryAsync(newExpenseCategory);
        }

        /// <summary>
        /// Creates a new expense category under the authenticated account. Makes a POST and a GET request to the Expense_Categories resource.
        /// </summary>
        /// <param name="options">The options for the new expense category to be created</param>
        public ExpenseCategory CreateExpenseCategory(ExpenseCategoryOptions options)
        {
            var request = CreateRequest(EXPENSE_CATEGORIES_RESOURCE, options);

            return Execute<ExpenseCategory>(request);
        }

        /// <summary>
        /// Creates a new expense category under the authenticated account. Makes a POST and a GET request to the Expense_Categories resource.
        /// </summary>
        /// <param name="options">The options for the new expense category to be created</param>
        public Task<ExpenseCategory> CreateExpenseCategoryAsync(ExpenseCategoryOptions options)
        {
            var request = CreateRequest(EXPENSE_CATEGORIES_RESOURCE, options);

            return ExecuteAsync<ExpenseCategory>(request);
        }

        /// <summary>
        /// Delete an expense category from the authenticated account. Makes a DELETE request to the Expense_Categories resource.
        /// </summary>
        /// <param name="expenseCategoryId">The ID of the expense category to delete</param>
        public bool DeleteExpenseCategory(long expenseCategoryId)
        {
            var request = Request(EXPENSE_CATEGORIES_RESOURCE, expenseCategoryId, Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Delete an expense category from the authenticated account. Makes a DELETE request to the Expense_Categories resource.
        /// </summary>
        /// <param name="expenseCategoryId">The ID of the expense category to delete</param>
        public async Task<bool> DeleteExpenseCategoryAsync(long expenseCategoryId)
        {
            var request = Request(EXPENSE_CATEGORIES_RESOURCE, expenseCategoryId, Method.DELETE);

            var result = await ExecuteAsync(request).ConfigureAwait(false);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Update a expense category on the authenticated account. Makes a PUT and a GET request to the Expense_Category resource.
        /// </summary>
        /// <param name="expenseCategoryId">The ID of the expense category to update</param>
        /// <param name="name">The updated name</param>
        /// <param name="unitName">The updated unit name (Unit name and price must be set together)</param>
        /// <param name="unitPrice">The updated unit price (Unit name and price must be set together)</param>
        public ExpenseCategory UpdateExpenseCategory(long expenseCategoryId, string name = null, string unitName = null, decimal? unitPrice = null)
        {
            var options = GetExpenseCategoryOptions(name, unitName, unitPrice);

            return UpdateExpenseCategory(expenseCategoryId, options);
        }

        /// <summary>
        /// Update a expense category on the authenticated account. Makes a PUT and a GET request to the Expense_Category resource.
        /// </summary>
        /// <param name="expenseCategoryId">The ID of the expense category to update</param>
        /// <param name="name">The updated name</param>
        /// <param name="unitName">The updated unit name (Unit name and price must be set together)</param>
        /// <param name="unitPrice">The updated unit price (Unit name and price must be set together)</param>
        public Task<ExpenseCategory> UpdateExpenseCategoryAsync(long expenseCategoryId, string name = null, string unitName = null, decimal? unitPrice = null)
        {
            var options = GetExpenseCategoryOptions(name, unitName, unitPrice);

            return UpdateExpenseCategoryAsync(expenseCategoryId, options);
        }

        /// <summary>
        /// Updates an expense category on the authenticated account. Makes a PUT and a GET request to the Expense_Category resource.
        /// </summary>
        /// <param name="expenseCategoryId">The ID for the expense category to update</param>
        /// <param name="options">The options to be updated</param>
        public ExpenseCategory UpdateExpenseCategory(long expenseCategoryId, ExpenseCategoryOptions options)
        {
            var request = UpdateRequest(EXPENSE_CATEGORIES_RESOURCE, expenseCategoryId, options);

            return Execute<ExpenseCategory>(request);
        }

        /// <summary>
        /// Updates an expense category on the authenticated account. Makes a PUT and a GET request to the Expense_Category resource.
        /// </summary>
        /// <param name="expenseCategoryId">The ID for the expense category to update</param>
        /// <param name="options">The options to be updated</param>
        public Task<ExpenseCategory> UpdateExpenseCategoryAsync(long expenseCategoryId, ExpenseCategoryOptions options)
        {
            var request = UpdateRequest(EXPENSE_CATEGORIES_RESOURCE, expenseCategoryId, options);

            return ExecuteAsync<ExpenseCategory>(request);
        }

        private static ExpenseCategoryOptions GetExpenseCategoryOptions(string name, string unitName, decimal? unitPrice)
        {
            return new ExpenseCategoryOptions
            {
                Name = name,
                UnitName = unitName,
                UnitPrice = unitPrice
            };
        }
    }
}

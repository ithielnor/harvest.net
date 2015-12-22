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
        // https://github.com/harvesthq/api/blob/master/Sections/Expense%20Categories.md

        /// <summary>
        /// List all expense categories for the authenticated account. Makes a GET request to the Expense_Categories resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the updated-at property</param>
        public List<ExpenseCategory> ListExpenseCategories(DateTime? updatedSince = null)
        {
            var request = Request("expense_categories");

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return Execute<List<ExpenseCategory>>(request);
        }

        /// <summary>
        /// Retrieve an expense category on the authenticated account. Makes a GET request to the Expense_Categories resource.
        /// </summary>
        /// <param name="expenseCategoryId">The Id of the expense category to retrieve</param>
        public ExpenseCategory ExpenseCategory(long expenseCategoryId)
        {
            var request = Request("expense_categories/" + expenseCategoryId);

            return Execute<ExpenseCategory>(request);
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
                throw new ArgumentNullException("name");

            var newExpenseCategory = new ExpenseCategoryOptions()
            {
                Name = name,
                UnitName = unitName,
                UnitPrice = unitPrice
            };

            return CreateExpenseCategory(newExpenseCategory);
        }

        /// <summary>
        /// Creates a new expense category under the authenticated account. Makes a POST and a GET request to the Expense_Categories resource.
        /// </summary>
        /// <param name="options">The options for the new expense category to be created</param>
        public ExpenseCategory CreateExpenseCategory(ExpenseCategoryOptions options)
        {
            var request = Request("expense_categories", RestSharp.Method.POST);

            request.AddBody(options);

            return Execute<ExpenseCategory>(request);
        }

        /// <summary>
        /// Delete an expense category from the authenticated account. Makes a DELETE request to the Expense_Categories resource.
        /// </summary>
        /// <param name="expenseCategoryId">The ID of the expense category to delete</param>
        public bool DeleteExpenseCategory(long expenseCategoryId)
        {
            var request = Request("expense_categories/" + expenseCategoryId, RestSharp.Method.DELETE);

            var result = Execute(request);

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
            var options = new ExpenseCategoryOptions()
            {
                Name = name,
                UnitName = unitName,
                UnitPrice = unitPrice
            };

            return UpdateExpenseCategory(expenseCategoryId, options);
        }

        /// <summary>
        /// Updates an expense category on the authenticated account. Makes a PUT and a GET request to the Expense_Category resource.
        /// </summary>
        /// <param name="expenseCategoryId">The ID for the expense category to update</param>
        /// <param name="options">The options to be updated</param>
        public ExpenseCategory UpdateExpenseCategory(long expenseCategoryId, ExpenseCategoryOptions options)
        {
            var request = Request("expense_categories/" + expenseCategoryId, RestSharp.Method.PUT);

            request.AddBody(options);

            return Execute<ExpenseCategory>(request);
        }
    }
}

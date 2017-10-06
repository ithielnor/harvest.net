using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        private const string EXPENSES_RESOURCE = "expenses";
        private const string RECEIPT_ACTION = "receipt";

        // https://github.com/harvesthq/api/blob/master/Sections/Expense%20Tracking.md

        /// <summary>
        /// List all expenses for the authenticated account. Makes a GET request to the Expenses resource.
        /// </summary>
        /// <param name="ofUser">The user ID to filter expenses by.</param>
        public IList<Expense> ListExpenses(long? ofUser = null)
        {
            var request = Request(EXPENSES_RESOURCE);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            return Execute<List<Expense>>(request);
        }

        /// <summary>
        /// List all expenses for the authenticated account. Makes a GET request to the Expenses resource.
        /// </summary>
        /// <param name="ofUser">The user ID to filter expenses by.</param>
        public async Task<IList<Expense>> ListExpensesAsync(long? ofUser = null)
        {
            var request = Request(EXPENSES_RESOURCE);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            // ReSharper disable once AsyncConverter.AsyncAwaitMayBeElidedHighlighting
            return await ExecuteAsync<List<Expense>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve an expense on the authenticated account. Makes a GET request to the Expenses resource.
        /// </summary>
        /// <param name="expenseId">The Id of the expense to retrieve</param>
        public Expense Expense(long expenseId, long? ofUser = null)
        {
            var request = Request(EXPENSES_RESOURCE, expenseId, Method.GET);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            return Execute<Expense>(request);
        }

        /// <summary>
        /// Retrieve an expense on the authenticated account. Makes a GET request to the Expenses resource.
        /// </summary>
        /// <param name="expenseId">The Id of the expense to retrieve</param>
        public Task<Expense> ExpenseAsync(long expenseId, long? ofUser = null)
        {
            var request = Request(EXPENSES_RESOURCE, expenseId, Method.GET);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            return ExecuteAsync<Expense>(request);
        }

        /// <summary>
        /// Create a new expense for on the authenticated account. Makes both a POST and a GET request to the Expense resource.
        /// </summary>
        /// <param name="spentAt">The date of the expense</param>
        /// <param name="projectId">The project to bill</param>
        /// <param name="expenseCategoryId">The category of the expense</param>
        /// <param name="totalCost">The total expense price</param>
        /// <param name="units">integer value for use with an expense calculated by unit price (Example: Mileage)</param>
        /// <param name="notes">The notes on the expense</param>
        /// <param name="isBillable">Whether the expense is billable</param>
        public Expense CreateExpense(DateTime spentAt, long projectId, long expenseCategoryId, decimal? totalCost = null, decimal? units = null, string notes = null, bool isBillable = true, long? ofUser = null)
        {
            var options = GetExpenseOptions(spentAt, projectId, expenseCategoryId, totalCost, units, notes, isBillable);

            return CreateExpense(options, ofUser);
        }

        /// <summary>
        /// Create a new expense for on the authenticated account. Makes both a POST and a GET request to the Expense resource.
        /// </summary>
        /// <param name="spentAt">The date of the expense</param>
        /// <param name="projectId">The project to bill</param>
        /// <param name="expenseCategoryId">The category of the expense</param>
        /// <param name="totalCost">The total expense price</param>
        /// <param name="units">integer value for use with an expense calculated by unit price (Example: Mileage)</param>
        /// <param name="notes">The notes on the expense</param>
        /// <param name="isBillable">Whether the expense is billable</param>
        public Task<Expense> CreateExpenseAsync(DateTime spentAt, long projectId, long expenseCategoryId, decimal? totalCost = null, decimal? units = null, string notes = null, bool isBillable = true, long? ofUser = null)
        {
            var options = GetExpenseOptions(spentAt, projectId, expenseCategoryId, totalCost, units, notes, isBillable);

            return CreateExpenseAsync(options, ofUser);
        }

        /// <summary>
        /// Creates a new expense under the authenticated account. Makes a POST and a GET request to the Expenses resource.
        /// </summary>
        /// <param name="options">The options for the new expense to be created</param>
        public Expense CreateExpense(ExpenseOptions options, long? ofUser = null)
        {
            var request = CreateRequest(EXPENSES_RESOURCE, options);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            return Execute<Expense>(request);
        }

        /// <summary>
        /// Creates a new expense under the authenticated account. Makes a POST and a GET request to the Expenses resource.
        /// </summary>
        /// <param name="options">The options for the new expense to be created</param>
        public Task<Expense> CreateExpenseAsync(ExpenseOptions options, long? ofUser = null)
        {
            var request = CreateRequest(EXPENSES_RESOURCE, options);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            return ExecuteAsync<Expense>(request);
        }

        /// <summary>
        /// Delete an expense from the authenticated account. Makes a DELETE request to the Expenses resource.
        /// </summary>
        /// <param name="expenseId">The ID of the expense to delete</param>
        public bool DeleteExpense(long expenseId, long? ofUser = null)
        {
            var request = Request(EXPENSES_RESOURCE, expenseId, Method.DELETE);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Delete an expense from the authenticated account. Makes a DELETE request to the Expenses resource.
        /// </summary>
        /// <param name="expenseId">The ID of the expense to delete</param>
        public async Task<bool> DeleteExpenseAsync(long expenseId, long? ofUser = null)
        {
            var request = Request(EXPENSES_RESOURCE, expenseId, Method.DELETE);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            var result = await ExecuteAsync(request).ConfigureAwait(false);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Update an existing expense on the authenticated account. Makes both a PUT and GET request to the Expenses resource.
        /// </summary>
        /// <param name="expenseId">The ID of the expense to update</param>
        /// <param name="spentAt">The new date of the expense</param>
        /// <param name="projectId">The new project ID of the expense</param>
        /// <param name="expenseCategoryId">The new expense category ID of the expense</param>
        /// <param name="totalCost">The new total cost of the expense</param>
        /// <param name="units">The new unit count of the expense</param>
        /// <param name="notes">The new notes of the expense</param>
        /// <param name="isBillable">The new billable status of the expense</param>
        public Expense UpdateExpense(long expenseId, DateTime? spentAt = null, long? projectId = null, long? expenseCategoryId = null, decimal? totalCost = null, decimal? units = null, string notes = null, bool? isBillable = null, long? ofUser = null)
        {
            var options = GetExpenseOptions(spentAt, projectId, expenseCategoryId, totalCost, units, notes, isBillable);

            return UpdateExpense(expenseId, options, ofUser);
        }

        /// <summary>
        /// Update an existing expense on the authenticated account. Makes both a PUT and GET request to the Expenses resource.
        /// </summary>
        /// <param name="expenseId">The ID of the expense to update</param>
        /// <param name="spentAt">The new date of the expense</param>
        /// <param name="projectId">The new project ID of the expense</param>
        /// <param name="expenseCategoryId">The new expense category ID of the expense</param>
        /// <param name="totalCost">The new total cost of the expense</param>
        /// <param name="units">The new unit count of the expense</param>
        /// <param name="notes">The new notes of the expense</param>
        /// <param name="isBillable">The new billable status of the expense</param>
        public Task<Expense> UpdateExpenseAsync(long expenseId, DateTime? spentAt = null, long? projectId = null, long? expenseCategoryId = null, decimal? totalCost = null, decimal? units = null, string notes = null, bool? isBillable = null, long? ofUser = null)
        {
            var options = GetExpenseOptions(spentAt, projectId, expenseCategoryId, totalCost, units, notes, isBillable);

            return UpdateExpenseAsync(expenseId, options, ofUser);
        }

        /// <summary>
        /// Update an existing expense on the authenticated account. Makes both a PUT and GET request to the Expenses resource.
        /// </summary>
        /// <param name="expenseId">The ID of the expense to update</param>
        /// <param name="options">The update options for the expense</param>
        public Expense UpdateExpense(long expenseId, ExpenseOptions options, long? ofUser = null)
        {
            var request = UpdateRequest(EXPENSES_RESOURCE, expenseId, options);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            return Execute<Expense>(request);
        }

        /// <summary>
        /// Update an existing expense on the authenticated account. Makes both a PUT and GET request to the Expenses resource.
        /// </summary>
        /// <param name="expenseId">The ID of the expense to update</param>
        /// <param name="options">The update options for the expense</param>
        public Task<Expense> UpdateExpenseAsync(long expenseId, ExpenseOptions options, long? ofUser = null)
        {
            var request = UpdateRequest(EXPENSES_RESOURCE, expenseId, options);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            return ExecuteAsync<Expense>(request);
        }

        private static readonly Dictionary<string, string> ALLOWED_RECEIPT_FILE_TYPES = new Dictionary<string, string>()
        {
            { "png", "image/png" },
            { "gif", "image/gif" },
            { "pdf", "application/pdf" },
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" }
        };

        public Expense AttachExpenseReceipt(long expenseId, byte[] bytes, string fileName, long? ofUser = null)
        {
            var request = AttachExpenseReceiptRequest(expenseId, bytes, fileName, ofUser);

            Execute(request);

            return Expense(expenseId);
        }

        public async Task<Expense> AttachExpenseReceiptAsync(long expenseId, byte[] bytes, string fileName, long? ofUser = null)
        {
            var request = AttachExpenseReceiptRequest(expenseId, bytes, fileName, ofUser);

            await ExecuteAsync(request).ConfigureAwait(false);

            return await ExpenseAsync(expenseId).ConfigureAwait(false);
        }

        private IRestRequest AttachExpenseReceiptRequest(long expenseId, byte[] bytes, string fileName, long? ofUser)
        {
            var extension = fileName.Split('.').Last();

            if (!ALLOWED_RECEIPT_FILE_TYPES.ContainsKey(extension))
                throw new ArgumentOutOfRangeException(nameof(fileName), "Receipt Allowed file types: " + string.Join(", ", ALLOWED_RECEIPT_FILE_TYPES.Values.ToArray()));

            var request = Request(EXPENSES_RESOURCE, expenseId, RECEIPT_ACTION, Method.POST);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            request.AddFile("expense[receipt]", bytes, fileName, ALLOWED_RECEIPT_FILE_TYPES[extension]);

            return request;
        }

        private static ExpenseOptions GetExpenseOptions(DateTime? spentAt, long? projectId, long? expenseCategoryId, decimal? totalCost, decimal? units, string notes, bool? isBillable)
        {
            if (totalCost != null && units != null)
                throw new ArgumentException("You may only set TotalCost OR Units. Not both.");

            if (totalCost == null && units == null)
                throw new ArgumentException("You must set either TotalCost OR Units.");

            return new ExpenseOptions
            {
                SpentAt = spentAt,
                ProjectId = projectId,
                ExpenseCategoryId = expenseCategoryId,
                Notes = notes,
                Billable = isBillable,
                TotalCost = totalCost,
                Units = units
            };
        }
    }
}

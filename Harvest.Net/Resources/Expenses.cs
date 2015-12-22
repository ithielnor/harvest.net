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
        // https://github.com/harvesthq/api/blob/master/Sections/Expense%20Tracking.md

        /// <summary>
        /// List all expenses for the authenticated account. Makes a GET request to the Expenses resource.
        /// </summary>
        public IList<Expense> ListExpenses(long? ofUser = null)
        {
            var request = Request("expenses");

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            return Execute<List<Expense>>(request);
        }

        /// <summary>
        /// Retrieve an expense on the authenticated account. Makes a GET request to the Expenses resource.
        /// </summary>
        /// <param name="expenseId">The Id of the expense to retrieve</param>
        public Expense Expense(long expenseId, long? ofUser = null)
        {
            var request = Request("expenses/" + expenseId);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            return Execute<Expense>(request);
        }

        /// <summary>
        /// Create a new expense for on the authenticated account. Makes both a POST and a GET request to the Expense resource.
        /// </summary>
        /// <param name="spentAt">The date of the expense</param>
        /// <param name="projectId">The project to bill</param>
        /// <param name="expenseCategoryId">The category of the expense</param>
        /// <param name="totalCost">The total expense price</param>
        /// <param name="notes">The notes on the expense</param>
        /// <param name="isBillable">Whether the expense is billable</param>
        public Expense CreateExpense(DateTime spentAt, long projectId, long expenseCategoryId, decimal? totalCost = null, decimal? units = null, string notes = null, bool isBillable = true, long? ofUser = null)
        {
            if (totalCost != null && units != null)
            {
                throw new ArgumentException("You may only set TotalCost OR Units. Not both.");
            }
            else if (totalCost == null && units == null)
            {
                throw new ArgumentException("You must set either TotalCost OR Units.");
            }

            var options = new ExpenseOptions()
            {
                SpentAt = spentAt,
                ProjectId = projectId,
                ExpenseCategoryId = expenseCategoryId,
                Notes = notes,
                Billable = isBillable,
                TotalCost = totalCost,
                Units = units
            };

            return CreateExpense(options, ofUser);
        }

        /// <summary>
        /// Creates a new expense under the authenticated account. Makes a POST and a GET request to the Expenses resource.
        /// </summary>
        /// <param name="options">The options for the new expense to be created</param>
        public Expense CreateExpense(ExpenseOptions options, long? ofUser = null)
        {
            var request = Request("expenses", RestSharp.Method.POST);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            request.AddBody(options);

            return Execute<Expense>(request);
        }

        /// <summary>
        /// Delete an expense from the authenticated account. Makes a DELETE request to the Expenses resource.
        /// </summary>
        /// <param name="expenseId">The ID of the expense to delete</param>
        public bool DeleteExpense(long expenseId, long? ofUser = null)
        {
            var request = Request("expenses/" + expenseId, RestSharp.Method.DELETE);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            var result = Execute(request);

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
            var options = new ExpenseOptions()
            {
                SpentAt = spentAt,
                ProjectId = projectId,
                ExpenseCategoryId = expenseCategoryId,
                Notes = notes,
                Billable = isBillable,
                TotalCost = totalCost,
                Units = units
            };

            return UpdateExpense(expenseId, options, ofUser);
        }

        /// <summary>
        /// Update an existing expense on the authenticated account. Makes both a PUT and GET request to the Expenses resource.
        /// </summary>
        /// <param name="expenseId">The ID of the expense to update</param>
        /// <param name="options">The update options for the expense</param>
        public Expense UpdateExpense(long expenseId, ExpenseOptions options, long? ofUser = null)
        {
            var request = Request("expenses/" + expenseId, RestSharp.Method.PUT);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            request.AddBody(options);

            return Execute<Expense>(request);
        }

        private static Dictionary<string, string> ALLOWED_RECEIPT_FILE_TYPES = new Dictionary<string, string>()
        {
            { "png", "image/png" },
            { "gif", "image/gif" },
            { "pdf", "application/pdf" },
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" }
        };

        public Expense AttachExpenseReceipt(long expenseId, byte[] bytes, string fileName, long? ofUser = null)
        {
            var extension = fileName.Split('.').Last();
            if (!ALLOWED_RECEIPT_FILE_TYPES.ContainsKey(extension))
                throw new ArgumentOutOfRangeException("fileName", "Receipt Allowed file types: " + string.Join(", ", ALLOWED_RECEIPT_FILE_TYPES.Values.ToArray()));

            var request = Request("expenses/" + expenseId + "/receipt", RestSharp.Method.POST);

            if (ofUser != null)
                request.AddParameter("of_user", ofUser.Value);

            request.AddFile("expense[receipt]", bytes, fileName, ALLOWED_RECEIPT_FILE_TYPES[extension]);

            Execute(request);

            return Expense(expenseId, ofUser);
        }
    }
}

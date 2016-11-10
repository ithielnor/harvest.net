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
       IList<Expense> ListExpenses(long? ofUser = null);

       Expense Expense(long expenseId, long? ofUser = null);

       Expense CreateExpense(DateTime spentAt, long projectId, long expenseCategoryId, decimal? totalCost = null, decimal? units = null, string notes = null, bool isBillable = true, long? ofUser = null);

       Expense CreateExpense(ExpenseOptions options, long? ofUser = null);

       bool DeleteExpense(long expenseId, long? ofUser = null);

       Expense UpdateExpense(long expenseId, DateTime? spentAt = null, long? projectId = null, long? expenseCategoryId = null, decimal? totalCost = null, decimal? units = null, string notes = null, bool? isBillable = null, long? ofUser = null);

       Expense UpdateExpense(long expenseId, ExpenseOptions options, long? ofUser = null);

       Expense AttachExpenseReceipt(long expenseId, byte[] bytes, string fileName, long? ofUser = null);
    }
}

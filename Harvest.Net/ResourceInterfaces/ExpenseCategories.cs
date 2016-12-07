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
        List<ExpenseCategory> ListExpenseCategories(DateTime? updatedSince = null);

        ExpenseCategory ExpenseCategory(long expenseCategoryId);

        ExpenseCategory CreateExpenseCategory(string name, string unitName = null, decimal? unitPrice = null);

        ExpenseCategory CreateExpenseCategory(ExpenseCategoryOptions options);

        bool DeleteExpenseCategory(long expenseCategoryId);

        ExpenseCategory UpdateExpenseCategory(long expenseCategoryId, string name = null, string unitName = null, decimal? unitPrice = null);

        ExpenseCategory UpdateExpenseCategory(long expenseCategoryId, ExpenseCategoryOptions options);
    }
}

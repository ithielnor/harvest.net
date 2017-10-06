using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        IList<ExpenseCategory> ListExpenseCategories(DateTime? updatedSince = null);

        Task<IList<ExpenseCategory>> ListExpenseCategoriesAsync(DateTime? updatedSince = null);

        ExpenseCategory ExpenseCategory(long expenseCategoryId);

        Task<ExpenseCategory> ExpenseCategoryAsync(long expenseCategoryId);

        ExpenseCategory CreateExpenseCategory(string name, string unitName = null, decimal? unitPrice = null);

        Task<ExpenseCategory> CreateExpenseCategoryAsync(string name, string unitName = null, decimal? unitPrice = null);

        ExpenseCategory CreateExpenseCategory(ExpenseCategoryOptions options);

        Task<ExpenseCategory> CreateExpenseCategoryAsync(ExpenseCategoryOptions options);

        bool DeleteExpenseCategory(long expenseCategoryId);

        Task<bool> DeleteExpenseCategoryAsync(long expenseCategoryId);

        ExpenseCategory UpdateExpenseCategory(long expenseCategoryId, string name = null, string unitName = null, decimal? unitPrice = null);

        Task<ExpenseCategory> UpdateExpenseCategoryAsync(long expenseCategoryId, string name = null, string unitName = null, decimal? unitPrice = null);

        ExpenseCategory UpdateExpenseCategory(long expenseCategoryId, ExpenseCategoryOptions options);

        Task<ExpenseCategory> UpdateExpenseCategoryAsync(long expenseCategoryId, ExpenseCategoryOptions options);
    }
}

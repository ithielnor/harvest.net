using Harvest.Net.Models;
using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class ExpenseFacts : FactBase, IDisposable
    {
        const long _testProjectId = 5787293;
        const long _testExpenseCategoryId = 2001551;
        const long _testExpenseId = 6371141;

        Expense _todelete = null;

        [Fact]
        public void ListExpenses_Returns()
        {
            var list = Api.ListExpenses();

            Assert.NotNull(list);
            Assert.NotEqual(0, list.First().Id);
        }
        
        [Fact]
        public void Expense_ReturnsExpense()
        {
            var Expense = Api.Expense(_testExpenseId); // Id of base Harvest.Net client Test Expense

            Assert.NotNull(Expense);
            Assert.Equal(_testProjectId, Expense.ProjectId);
            Assert.Equal(_testExpenseCategoryId, Expense.ExpenseCategoryId);
        }

        [Fact]
        public void DeleteExpense_ReturnsTrue()
        {
            var Expense = Api.CreateExpense(DateTime.Now, _testProjectId, _testExpenseCategoryId, totalCost: 1, notes: "Delete Test");

            var result = Api.DeleteExpense(Expense.Id);

            Assert.Equal(true, result);
        }

        [Fact]
        public void CreateExpense_ReturnsANewExpense()
        {
            var date = DateTime.Now.Date;
            _todelete = Api.CreateExpense(date, _testProjectId, _testExpenseCategoryId, totalCost: 1, notes: "Create Test");

            Assert.Equal(date, _todelete.SpentAt);
            Assert.Equal(_testProjectId, _todelete.ProjectId);
            Assert.Equal(_testExpenseCategoryId, _todelete.ExpenseCategoryId);
        }
        
        [Fact]
        public void UpdateExpense_UpdatesOnlyChangedValues()
        {
            var date = DateTime.Now.Date;
            _todelete = Api.CreateExpense(date, _testProjectId, _testExpenseCategoryId, totalCost: 1, notes: "Update Test");

            var updated = Api.UpdateExpense(_todelete.Id, spentAt: date.AddDays(1), totalCost: 2);

            // stuff changed
            Assert.NotEqual(_todelete.SpentAt, updated.SpentAt);
            Assert.Equal(date.AddDays(1), updated.SpentAt);
            Assert.NotEqual(_todelete.TotalCost, updated.TotalCost);
            Assert.Equal(2, updated.TotalCost);

            // stuff didn't change
            Assert.Equal(_todelete.ProjectId, updated.ProjectId);
            Assert.Equal(_todelete.Notes, updated.Notes);
        }
        
        public void Dispose()
        {
            if (_todelete != null)
                Api.DeleteExpense(_todelete.Id);
        }
    }
}

using Harvest.Net.Models;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class ExpenseFacts : FactBase, IDisposable
    {
        Expense _todelete = null;

        [Fact]
        public void ListExpenses_Returns()
        {
            // ListExpenses only lists the current week, so we must create an expense for today to ensure there is something in the list.
            _todelete = Api.CreateExpense(DateTime.Now.Date, GetTestId(TestId.ProjectId), GetTestId(TestId.ExpenseCategoryId), totalCost: 1, notes: "List Test");

            var list = Api.ListExpenses();

            Assert.NotNull(list);
            Assert.NotEqual(0, list.First().Id);
        }
        
        [Fact]
        public void Expense_ReturnsExpense()
        {
            var Expense = Api.Expense(GetTestId(TestId.ExpenseId));

            Assert.NotNull(Expense);
            Assert.Equal(GetTestId(TestId.ProjectId), Expense.ProjectId);
            Assert.Equal(GetTestId(TestId.ExpenseCategoryId), Expense.ExpenseCategoryId);
        }

        [Fact]
        public void DeleteExpense_ReturnsTrue()
        {
            var Expense = Api.CreateExpense(DateTime.Now, GetTestId(TestId.ProjectId), GetTestId(TestId.ExpenseCategoryId), totalCost: 1, notes: "Delete Test");

            var result = Api.DeleteExpense(Expense.Id);

            Assert.Equal(true, result);
        }

        [Fact]
        public void CreateExpense_ReturnsANewExpense()
        {
            var date = DateTime.Now.Date;
            _todelete = Api.CreateExpense(date, GetTestId(TestId.ProjectId), GetTestId(TestId.ExpenseCategoryId), totalCost: 1, notes: "Create Test");

            Assert.Equal(date, _todelete.SpentAt);
            Assert.Equal(GetTestId(TestId.ProjectId), _todelete.ProjectId);
            Assert.Equal(GetTestId(TestId.ExpenseCategoryId), _todelete.ExpenseCategoryId);
        }
        
        [Fact]
        public void UpdateExpense_UpdatesOnlyChangedValues()
        {
            var date = DateTime.Now.Date;
            _todelete = Api.CreateExpense(date, GetTestId(TestId.ProjectId), GetTestId(TestId.ExpenseCategoryId), totalCost: 1, notes: "Update Test");

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

        [Fact]
        public void AttachExpenseReceipt_AttachesFile()
        {
            _todelete = Api.CreateExpense(DateTime.Now.Date, GetTestId(TestId.ProjectId), GetTestId(TestId.ExpenseCategoryId), totalCost: 1, notes: "Upload Test");

            System.Reflection.Assembly factAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            byte[] fileBytes;
            using (Stream resourceFilestream = factAssembly.GetManifestResourceStream("Harvest.Net.Tests.receipt.jpg"))
            {
                fileBytes = new byte[resourceFilestream.Length];
                resourceFilestream.Read(fileBytes, 0, fileBytes.Length);
            }
            
            var attached = Api.AttachExpenseReceipt(_todelete.Id, fileBytes, "receipt.jpg");

            Assert.Equal(true, attached.HasReceipt);
            Assert.NotNull(attached.ReceiptUrl);
        }
        
        public void Dispose()
        {
            if (_todelete != null)
                Api.DeleteExpense(_todelete.Id);
        }
    }
}

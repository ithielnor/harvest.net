using Harvest.Net.Models;
using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class TaskFacts : FactBase, IDisposable
    {
        Task _todelete = null;

        [Fact]
        public void ListTasks_Returns()
        {
            var list = Api.ListTasks();

            Assert.True(list != null, "Result list is null.");
            Assert.NotEqual(0, list.First().Id);
        }
        
        [Fact]
        public void Task_ReturnsTask()
        {
            var task = Api.Task(GetTestId(TestId.TaskId));

            Assert.NotNull(task);
            Assert.Equal("Admin", task.Name);
        }
        
        [Fact]
        public void DeleteTask_ReturnsTrue()
        {
            var task = Api.CreateTask("Delete Task");

            var result = Api.DeleteTask(task.Id);

            Assert.Equal(true, result);
        }

        [Fact]
        public void CreateTask_ReturnsANewTask()
        {
            _todelete = Api.CreateTask("Create Task");

            Assert.Equal("Create Task", _todelete.Name);
        }
        
        [Fact]
        public void UpdateTask_UpdatesOnlyChangedValues()
        {
            _todelete = Api.CreateTask("Update Task", billableByDefault: true, isDefault: false);

            var updated = Api.UpdateTask(_todelete.Id, name: "Updated Task", isDefault: true);
            
            // stuff changed
            Assert.NotEqual(_todelete.Name, updated.Name);
            Assert.Equal("Updated Task", updated.Name);
            Assert.NotEqual(_todelete.IsDefault, updated.IsDefault);
            Assert.Equal(true, updated.IsDefault);

            // stuff didn't change
            Assert.Equal(_todelete.BillableByDefault, updated.BillableByDefault);
            Assert.Equal(_todelete.DefaultHourlyRate, updated.DefaultHourlyRate);
        }
        
        public void Dispose()
        {
            if (_todelete != null)
                Api.DeleteTask(_todelete.Id);
        }
    }
}

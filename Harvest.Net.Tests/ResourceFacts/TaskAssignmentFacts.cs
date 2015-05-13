using Harvest.Net.Models;
using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class TaskAssignmentFacts : FactBase, IDisposable
    {
        TaskAssignment _todelete = null;
        Task _todeletetask = null;

        [Fact]
        public void ListTaskAssignments_Returns()
        {
            var list = Api.ListTaskAssignments(GetTestId(TestId.ProjectId));

            Assert.True(list != null, "Result list is null.");
            Assert.NotEqual(0, list.First().Id);
        }
        
        [Fact]
        public void TaskAssignment_ReturnsTaskAssignment()
        {
            var taskAssignment = Api.TaskAssignment(GetTestId(TestId.ProjectId), GetTestId(TestId.TaskAssignmentId));

            Assert.NotNull(taskAssignment);
            Assert.Equal(GetTestId(TestId.TaskId), taskAssignment.TaskId);
            Assert.Equal(GetTestId(TestId.ProjectId), taskAssignment.ProjectId);
        }

        [Fact]
        public void CreateTaskAssignment_ReturnsANewTaskAssignment()
        {
            _todelete = Api.CreateTaskAssignment(GetTestId(TestId.ProjectId), GetTestId(TestId.TaskId2));

            Assert.NotNull(_todelete);
            Assert.Equal(GetTestId(TestId.ProjectId), _todelete.ProjectId);
            Assert.Equal(GetTestId(TestId.TaskId2), _todelete.TaskId);
        }

        [Fact]
        public void CreateNewTaskAndAssign_ReturnsANewTaskAssignment()
        {
            _todelete = Api.CreateNewTaskAndAssign(GetTestId(TestId.ProjectId), "Create New Task And Assign Test");
            _todeletetask = Api.Task(_todelete.TaskId);

            Assert.NotNull(_todelete);
            Assert.Equal(GetTestId(TestId.ProjectId), _todelete.ProjectId);
            Assert.Equal("Create New Task And Assign Test", _todeletetask.Name);
        }

        [Fact]
        public void DeleteTaskAssignment_ReturnsTrue()
        {
            var taskAssignment = Api.CreateTaskAssignment(GetTestId(TestId.ProjectId), GetTestId(TestId.TaskId2));

            var result = Api.DeleteTaskAssignment(taskAssignment.ProjectId, taskAssignment.Id);

            Assert.Equal(true, result);
        }
        
        [Fact]
        public void UpdateTaskAssignment_UpdatesOnlyChangedValues()
        {
            var projectId = GetTestId(TestId.ProjectId);

            _todelete = Api.CreateTaskAssignment(projectId, GetTestId(TestId.TaskId2));
            var updated = Api.UpdateTaskAssignment(projectId, _todelete.Id, billable: true, hourlyRate: 1);

            // stuff changed
            Assert.NotEqual(_todelete.Billable, updated.Billable);
            Assert.Equal(false, _todelete.Billable);
            Assert.NotEqual(_todelete.HourlyRate, updated.HourlyRate);
            Assert.Equal(0m, _todelete.HourlyRate);

            // stuff didn't change
            Assert.Equal(_todelete.Id, updated.Id);
            Assert.Equal(projectId, updated.ProjectId);
            Assert.Equal(_todelete.TaskId, updated.TaskId);
            Assert.Equal(null, updated.Budget);
            Assert.Equal(false, updated.Deactivated);
        }
        
        public void Dispose()
        {
            if (_todelete != null)
            {
                Api.DeleteTaskAssignment(_todelete.ProjectId, _todelete.Id);
            }

            if (_todeletetask != null)
            {
                Api.DeleteTask(_todeletetask.Id);
            }
        }
    }
}

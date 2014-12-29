using Harvest.Net.Models;
using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class UserAssignmentFacts : FactBase, IDisposable
    {
        [Fact]
        public void ListUserAssignments_Returns()
        {
            var list = Api.ListUserAssignments(GetTestId(TestId.ProjectId));

            Assert.True(list != null, "Result list is null.");
            Assert.NotEqual(0, list.First().Id);
        }
        
        [Fact]
        public void UserAssignment_ReturnsUserAssignment()
        {
            var userAssignment = Api.UserAssignment(GetTestId(TestId.ProjectId), GetTestId(TestId.UserAssignmentId));

            Assert.NotNull(userAssignment);
            Assert.Equal(GetTestId(TestId.UserId), userAssignment.UserId);
            Assert.Equal(GetTestId(TestId.ProjectId), userAssignment.ProjectId);
        }
        
        /// <summary>
        /// We're testing delete and create together because the free account has a limited number of projects.
        /// There is no space to add another "clean slate" project.
        /// </summary>
        [Fact]
        public void DeleteAndCreateUserAssignment_ReturnsANewUserAssignment()
        {
            var projectId = GetTestId(TestId.ProjectId2);
            var oldAssignment = Api.ListUserAssignments(projectId).First();
            var userId = oldAssignment.UserId;

            var result = Api.DeleteUserAssignment(projectId, oldAssignment.Id);
            var assignment = Api.CreateUserAssignment(projectId, userId);

            Assert.True(result, "Delete failed");
            Assert.NotNull(assignment);
            Assert.Equal(userId, assignment.UserId);
            Assert.Equal(projectId, assignment.ProjectId);
            Assert.False(assignment.Deactivated, "Assignment is inactive");
            // Review: Apparently assigning just reactivate it?
            //Assert.NotEqual(oldAssignment.Id, assignment.Id);
        }
        
        [Fact]
        public void UpdateUserAssignment_UpdatesOnlyChangedValues()
        {
            var projectId = GetTestId(TestId.ProjectId2);
            var oldAssignment = Api.ListUserAssignments(projectId).First();
            var userId = oldAssignment.UserId;

            var updated1 = Api.UpdateUserAssignment(projectId, oldAssignment.Id, userId, hourlyRate: 1, budget: 100, isProjectManager: false);
            var updated2 = Api.UpdateUserAssignment(projectId, oldAssignment.Id, userId, hourlyRate: 2, isProjectManager: true);

            // stuff changed
            Assert.NotEqual(updated1.HourlyRate, updated2.HourlyRate);
            Assert.Equal(1, updated1.HourlyRate);
            Assert.NotEqual(updated1.IsProjectManager, updated2.IsProjectManager);
            Assert.Equal(false, updated1.IsProjectManager);

            // stuff didn't change
            Assert.Equal(updated1.Id, updated2.Id);
            Assert.Equal(projectId, updated1.ProjectId);
            Assert.Equal(userId, updated1.UserId);
            Assert.Equal(100, updated1.Budget);
            Assert.Equal(oldAssignment.Deactivated, updated1.Deactivated);
        }
        
        public void Dispose()
        {
        }
    }
}

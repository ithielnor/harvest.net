using Harvest.Net.Models;
using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class PeopleFacts : FactBase, IDisposable
    {
        User _todelete = null;

        [Fact]
        public void ListUsers_Returns()
        {
            var list = Api.ListUsers();

            Assert.True(list != null, "Result list is null.");
            Assert.NotEqual(0, list.First().Id);
        }

        [Fact]
        public void User_ReturnsUser()
        {
            var User = Api.User(GetTestId(TestId.UserId));

            Assert.NotNull(User);
            Assert.Equal("Joel", User.FirstName);
        }

        [Fact(Skip = "Fails because the account has hit the max users limit")]
        public void DeleteUser_ReturnsTrue()
        {
            var User = Api.CreateUser("deletetest@example.com", "Test", "Delete User");

            var result = Api.DeleteUser(User.Id);

            Assert.Equal(true, result);
        }

        [Fact(Skip = "Fails because the account has hit the max users limit")]
        public void CreateUser_ReturnsANewUser()
        {
            _todelete = Api.CreateUser("createtest@example.com", "Test", "Create User");
            
            Assert.Equal("Test", _todelete.FirstName);
            Assert.Equal("Create User", _todelete.LastName);
        }

        [Fact(Skip = "Fails because the account has hit the max users limit")]
        public void ToggleUser_TogglesTheUserStatus()
        {
            _todelete = Api.CreateUser("toggletest@example.com", "Test", "Toggle User");

            Assert.Equal(true, _todelete.IsActive);

            _todelete = Api.ToggleUser(_todelete.Id);

            Assert.Equal(false, _todelete.IsActive);
        }

        [Fact(Skip="Fails because the account has hit the max users limit")]
        public void UpdateUser_UpdatesOnlyChangedValues()
        {
            _todelete = Api.CreateUser("updatetest@example.com", "Test", "Update User");

            var updated = Api.UpdateUser(_todelete.Id, lastName: "Updated User", department: "department");
            
            // stuff changed
            Assert.NotEqual(_todelete.LastName, updated.LastName);
            Assert.Equal("Updated User", updated.LastName);
            Assert.NotEqual(_todelete.Department, updated.Department);
            Assert.Equal("department", updated.Department);

            // stuff didn't change
            Assert.Equal(_todelete.IsActive, updated.IsActive);
            Assert.Equal(_todelete.DefaultHourlyRate, updated.DefaultHourlyRate);
            Assert.Equal(_todelete.FirstName, updated.FirstName);
            Assert.Equal(_todelete.Timezone, updated.Timezone);
        }

        public void Dispose()
        {
            if (_todelete != null)
                Api.DeleteUser(_todelete.Id);
        }
    }
}

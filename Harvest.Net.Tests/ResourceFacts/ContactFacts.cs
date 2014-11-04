using Harvest.Net.Models;
using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class ContactFacts : FactBase, IDisposable
    {
        Contact _todelete = null;

        [Fact]
        public void ListContacts_Returns()
        {
            var list = Api.ListContacts();

            Assert.NotNull(list);
            Assert.NotEqual(0, list.First().Id);
        }

        [Fact]
        public void ListClientContacts_Returns()
        {
            var list = Api.ListClientContacts(GetTestId(TestId.ClientId));

            Assert.NotNull(list);
            Assert.NotEqual(0, list.First().Id);
        }

        [Fact]
        public void Contact_ReturnsContact()
        {
            var contact = Api.Contact(GetTestId(TestId.ContactId));

            Assert.NotNull(contact);
            Assert.Equal("Test", contact.FirstName);
            Assert.Equal("Contact", contact.LastName);
        }

        [Fact]
        public void DeleteContact_ReturnsTrue()
        {
            var contact = Api.CreateContact(GetTestId(TestId.ClientId), "Delete", "Contact");

            var result = Api.DeleteContact(contact.Id);

            Assert.Equal(true, result);
        }

        [Fact]
        public void CreateContact_ReturnsANewContact()
        {
            _todelete = Api.CreateContact(GetTestId(TestId.ClientId), "Create", "Contact");

            Assert.Equal("Create", _todelete.FirstName);
            Assert.Equal("Contact", _todelete.LastName);
        }

        [Fact]
        public void UpdateContact_UpdatesOnlyChangedValues()
        {
            _todelete = Api.CreateContact(GetTestId(TestId.ClientId), "Update", "Contact");

            var updated = Api.UpdateContact(_todelete.Id, firstName: "Updated", title: "Title");

            // stuff changed
            Assert.NotEqual(_todelete.FirstName, updated.FirstName);
            Assert.Equal("Updated", updated.FirstName);
            Assert.NotEqual(_todelete.Title, updated.Title);
            Assert.Equal("Title", updated.Title);

            // stuff didn't change
            Assert.Equal(_todelete.LastName, updated.LastName);
            Assert.Equal(_todelete.ClientId, updated.ClientId);

        }

        public void Dispose()
        {
            if (_todelete != null)
                Api.DeleteContact(_todelete.Id);
        }
    }
}

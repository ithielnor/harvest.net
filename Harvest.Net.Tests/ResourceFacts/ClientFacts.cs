using Harvest.Net.Models;
using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class ClientFacts : FactBase, IDisposable
    {
        Client _todelete = null;

        [Fact]
        public void ListClients_Returns()
        {
            var list = Api.ListClients();

            Assert.True(list != null, "Result list is null.");
            Assert.NotEqual(0, list.First().Id);
        }

        [Fact]
        public void Client_ReturnsClient()
        {
            var client = Api.Client(GetTestId(TestId.ClientId));

            Assert.NotNull(client);
            Assert.Equal("Harvest.Net", client.Name);
        }

        [Fact(Skip = "Does not work on free account")]
        public void DeleteClient_ReturnsTrue()
        {
            var client = Api.CreateClient("Test Delete Client");

            var result = Api.DeleteClient(client.Id);

            Assert.Equal(true, result);
        }

        [Fact(Skip = "Does not work on free account")]
        public void CreateClient_ReturnsANewClient()
        {
            _todelete = Api.CreateClient("Test Create Client");
            
            Assert.Equal("Test Create Client", _todelete.Name);
        }

        [Fact(Skip = "Does not work on free account")]
        public void ToggleClient_TogglesTheClientStatus()
        {
            _todelete = Api.CreateClient("Test Toggle Client");

            Assert.Equal(true, _todelete.Active);

            var toggled = Api.ToggleClient(_todelete.Id);

            Assert.Equal(false, toggled.Active);
        }

        [Fact(Skip = "Does not work on free account")]
        public void UpdateClient_UpdatesOnlyChangedValues()
        {
            _todelete = Api.CreateClient("Test Update Client");

            var updated = Api.UpdateClient(_todelete.Id, "Updated Client", details: "details");
            
            // stuff changed
            Assert.NotEqual(_todelete.Name, updated.Name);
            Assert.Equal("Updated Client", updated.Name);
            Assert.NotEqual(_todelete.Details, updated.Details);
            Assert.Equal("details", updated.Details);

            // stuff didn't change
            Assert.Equal(_todelete.Active, updated.Active);
            Assert.Equal(_todelete.Currency, updated.Currency);
        }

        public void Dispose()
        {
            if (_todelete != null)
                Api.DeleteClient(_todelete.Id);
        }
    }
}

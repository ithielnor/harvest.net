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
            var client = Api.Client(2553669); // Id of base Harvest.Net client

            Assert.NotNull(client);
            Assert.Equal("Harvest.Net", client.Name);
        }

        [Fact]
        public void DeleteClient_ReturnsTrue()
        {
            var client = Api.CreateClient("Test Delete Client");

            var result = Api.DeleteClient(client.Id);

            Assert.Equal(true, result);
        }

        [Fact]
        public void CreateClient_ReturnsANewClient()
        {
            _todelete = Api.CreateClient("Test Create Client");
            
            Assert.Equal("Test Create Client", _todelete.Name);
        }

        [Fact]
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

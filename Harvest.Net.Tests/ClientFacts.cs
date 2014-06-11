using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class ClientFacts : FactBase
    {
        [Fact]
        public void ListClients_Returns()
        {
            var list = Api.ListClients();

            Assert.True(list != null, "Result list is null.");
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

            // cleanup
            var result = Api.DeleteClient(client.Id);

            Assert.Equal(true, result);
        }

        [Fact]
        public void CreateClient_ReturnsANewClient()
        {
            var client = Api.CreateClient("Test Create Client");

            // cleanup
            Api.DeleteClient(client.Id);

            Assert.Equal("Test Create Client", client.Name);
        }

        [Fact]
        public void UpdateClient_UpdatesOnlyChangedValues()
        {
            var client = Api.CreateClient("Test Update Client");

            var updated = Api.UpdateClient(client.Id, "Updated Client", details: "details");

            // cleanup
            Api.DeleteClient(client.Id);

            // stuff changed
            Assert.NotEqual(client.Name, updated.Name);
            Assert.Equal("Updated Client", updated.Name);
            Assert.NotEqual(client.Details, updated.Details);
            Assert.Equal("details", updated.Details);

            // stuff didn't change
            Assert.Equal(client.Active, updated.Active);
            Assert.Equal(client.Currency, updated.Currency);

        }
    }
}

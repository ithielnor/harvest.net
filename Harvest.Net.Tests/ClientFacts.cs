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
            var client = Api.CreateClient("Test Client");

            // cleanup
            var result = Api.DeleteClient(client.Id);

            Assert.Equal(true, result);
        }

        [Fact]
        public void CreateClient_ReturnsANewClient()
        {
            var client = Api.CreateClient("Test Client");

            // cleanup
            Api.DeleteClient(client.Id);

            Assert.NotNull(client);
            Assert.Equal("Test Client", client.Name);
        }
    }
}

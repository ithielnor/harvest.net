using Harvest.Net.Network;
using Harvest.Net.Utilities;
using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Harvest.Net.UnitTests
{
    public class HarvestRestClientTests
    {
        [Fact]
        public void HarvestRestClientWithBasicAuthCanBeCreatedWithNoErrors()
        {
            IHarvestRestClient client = new HarvestRestClient("subdomain", "username", "password");
        }

        [Fact]
        public void HarvestRestClientWithAccessTokenCanBeCreatedWithNoErrors()
        {
            IHarvestRestClient client = new HarvestRestClient("subdomain", "clientId", "clientSecret", "accessToken");
        }

        [Fact]
        public void HarvestRestClientCreatesClientUsingProperParameters()
        {
            var expectedBaseUrl = @"https://subdomain.harvestapp.com/";
            var expectedUserAgent = @"harvest.net/1.0.0 (.NET 4.5.2)";
            var username = "username";
            var password = "password";

            var assemblyInfo = new Mock<IAssemblyInformation>();
            var environmentInfo = new Mock<IEnvironmentInformation>();
            var restSharpFactory = new Mock<IRestSharpFactory>();

            var restSharpClient = new Mock<IRestClient>();

            assemblyInfo.SetupGet(s => s.Version).Returns(new Version(1, 0, 0));
            environmentInfo.SetupGet(s => s.Version).Returns(new Version(4, 5, 2));
            restSharpFactory.Setup(
                s => s.GetWebClient(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns(restSharpClient.Object);

            IHarvestRestClient client = new HarvestRestClient("subdomain", username, password, assemblyInfo.Object, environmentInfo.Object, restSharpFactory.Object);

            restSharpFactory.Verify(
                v => v.GetWebClient(
                    It.Is<string>(i => i == expectedBaseUrl),
                    It.Is<string>(i => i == expectedUserAgent),
                    It.Is<string>(i => i == username),
                    It.Is<string>(i => i == password)),
                Times.Once());
        }
    }
}

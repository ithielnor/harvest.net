using Harvest.Net.Models;
using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class AccountFacts : FactBase
    {
        [Fact]
        public void WhoAmI_ReturnsAccountDetails()
        {
            var account = Api.WhoAmI();

            Assert.NotNull(account.User);
            Assert.NotNull(account.Company);
            Assert.NotNull(account.Company.Modules);
            Assert.NotNull(account.User.ProjectManager);

            Assert.Equal(this.Username, account.User.Email);
            Assert.Equal(this.Subdomain + ".harvestapp.com", account.Company.FullDomain);
            Assert.Equal(true, account.User.Admin);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harvest.Net.Models;
using Xunit;
using Harvest.Net.Models.Interfaces;

namespace Harvest.Net.Tests
{
    public class OAuthFacts
    {
        [Fact]
        public void RefreshToken_Succeeds()
        {
            var client = new HarvestRestClient("harvestdotnet", "CuJ3af_hylkRp4NvDe20yg", "3_-0j6mRXPSjOmNcGn2q73BHexU11jxbbPiwBXnpX1oJ92Yj7Sb22UYuE4uKkc5zZYMtXg5s2BXZsfmWbFo0fg", null);

            IOAuth whatever = client.RefreshToken("Vjlz7xhW2p9HbzndrM0D1HnaGY7z0S1PKsXkHuQXD1xai4_GCe_fHLEqUgNfqy4Yeuize9KtBfZAo1g3TyMqmg");

            Assert.NotNull(whatever);
            Assert.NotNull(whatever.AccessToken);
        }

        [Fact]
        public void OAuth_Succeeds()
        {
            var client = new HarvestRestClient("harvestdotnet", "CuJ3af_hylkRp4NvDe20yg", "3_-0j6mRXPSjOmNcGn2q73BHexU11jxbbPiwBXnpX1oJ92Yj7Sb22UYuE4uKkc5zZYMtXg5s2BXZsfmWbFo0fg", 
                "PbAjhAeW--og-9FADcPm0GHSHuWEWFKYzCLLhi0SkeFYMzH61a1_DekV7ww8_5blaBTGctlhPu2znfD_RyCjPw");

            var list = client.ListClients();

            Assert.True(list != null, "Result list is null.");
            Assert.NotEqual(0, list.First().Id);
        }
    }
}

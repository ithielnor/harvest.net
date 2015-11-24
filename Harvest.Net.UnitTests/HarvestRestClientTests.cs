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
            IHarvestRestClient client = new HarvestRestClient("subdomain","username","password");
        }
    }
}

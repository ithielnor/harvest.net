using Harvest.Net.Models;
using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class TimeTrackingFacts : FactBase, IDisposable
    {
        [Fact]
        public void Daily_ReturnsResult()
        {
            var result = Api.Daily();

            Assert.NotNull(result);
            Assert.NotNull(result.DayEntries);
            Assert.NotNull(result.Projects);
            Assert.Equal(DateTime.Now.Date, result.ForDay);
        }
        
        public void Dispose()
        {
            
        }
    }
}

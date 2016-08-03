using Harvest.Net.Models;
using System;
using System.Linq;
using Xunit;

namespace Harvest.Net.Tests
{
    public class TimeTrackingFacts : FactBase, IDisposable
    {
        DayEntry _todelete = null;

        [Fact]
        public void Daily_ReturnsResult()
        {
            var result = Api.Daily();

            Assert.NotNull(result);
            Assert.NotNull(result.DayEntries);
            Assert.NotNull(result.Projects);

            // The test harvest account is in EST, but Travis CI runs in different timezones
            Assert.Equal(TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.Utc, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")).Date, result.ForDay);
        }

        [Fact]
        public void Daily_ReturnsCorrectResult()
        {
            var result = Api.Daily(286857409);

            Assert.NotNull(result);
            Assert.Equal(1m, result.DayEntry.Hours);
            Assert.Equal(new DateTime(2014, 12, 19), result.DayEntry.SpentAt);
        }

        [Fact]
        public void CreateDaily_CreatesAnEntry()
        {
            var result = Api.CreateDaily(DateTime.Now.Date, GetTestId(TestId.ProjectId), GetTestId(TestId.TaskId), 2);
            _todelete = result.DayEntry;

            Assert.Equal(2m, result.DayEntry.Hours);
            Assert.Equal(GetTestId(TestId.ProjectId), result.DayEntry.ProjectId);
            Assert.Equal(GetTestId(TestId.TaskId), result.DayEntry.TaskId);
        }
        
        public void Dispose()
        {
            if (_todelete != null)
                Api.DeleteDaily(_todelete.Id);
        }
    }
}

using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "timer")]
    public class Timer
    {
        public DayEntry DayEntry { get; set; }

        public float? HoursForPreviouslyRunningTimer { get; set; }
    }
}

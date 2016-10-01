using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Timer used by the harvest API.
    /// </summary>
    [SerializeAs(Name = "timer")]
    public class Timer
    {
        /// <summary>
        /// Entry of the day. For further reference lookup <see cref="DayEntry"/>.
        /// </summary>
        public DayEntry DayEntry { get; set; }

        /// <summary>
        /// Amount of hours of the previously started timer.
        /// </summary>
        public float? HoursForPreviouslyRunningTimer { get; set; }
    }
}

using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "timer")]
    public class Timer
    {
        public DayEntry DayEntry { get; set; }

        public float? HoursForPreviouslyRunningTimer { get; set; }
    }
}

using RestSharp.Serializers;
using System;
using System.Collections.Generic;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "daily")]
    public class Daily
    {
        public DateTime ForDay { get; set; }

        public List<DayEntry> DayEntries { get; set; }

        public List<Project> Projects { get; set; }
    }
}

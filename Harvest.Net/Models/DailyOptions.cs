using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "request")]
    internal class DailyOptions
    {
        public string Notes { get; set; }

        public DateTime? SpentAt { get; set; }

        public long? ProjectId { get; set; }

        public long? TaskId { get; set; }

        public string Hours { get; set; }

        public string StartedAt { get; set; }

        public string EndedAt { get; set; }
    }
}

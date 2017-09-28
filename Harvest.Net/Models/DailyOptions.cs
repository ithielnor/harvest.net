using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Options for sending requests to the API. It will filter the daily reports.
    /// </summary>
    [SerializeAs(Name = "request")]
    internal class DailyOptions
    {
        /// <summary>
        /// Notes about the options.
        /// Example:
        /// <example>""</example>
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Time where the the time is spent at this day.
        /// </summary>
        public DateTime? SpentAt { get; set; }

        /// <summary>
        /// Id of projects involved in daily report.
        /// </summary>
        public long? ProjectId { get; set; }

        /// <summary>
        /// Taks id involved in the daily report.
        /// </summary>
        public long? TaskId { get; set; }

        /// <summary>
        /// Hours used in the daily reports.
        /// </summary>
        public string Hours { get; set; }

        /// <summary>
        /// Time where the daily report started.
        /// Example:
        /// <example>
        /// 12:00pm
        /// </example>
        /// </summary>
        public string StartedAt { get; set; }

        /// <summary>
        /// End time of the daily report.
        /// Example:
        /// <example>
        /// 2:00pm
        /// </example>
        /// </summary>
        public string EndedAt { get; set; }
    }
}

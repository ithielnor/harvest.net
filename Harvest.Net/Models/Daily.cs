using RestSharp.Serializers;
using System;
using System.Collections.Generic;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for getting daily time entries.
    /// </summary>
    [SerializeAs(Name = "daily")]
    public class Daily
    {
        /// <summary>
        /// Date of the request.
        /// </summary>
        public DateTime ForDay { get; set; }

        /// <summary>
        /// List of daily entries in the daily report.
        /// For further information lookup <see cref="DayEntry"/>.
        /// </summary>
        public List<DayEntry> DayEntries { get; set; }

        /// <summary>
        /// List of projects in the daily report. For further information lookup <see cref="Project"/>.
        /// </summary>
        public List<Project> Projects { get; set; }
    }
}

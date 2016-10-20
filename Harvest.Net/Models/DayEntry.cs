using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Day entry given by the Harvest API. Some properties are not available in non-daily resources.
    /// </summary>
    [SerializeAs(Name = "day-entry")]
    public class DayEntry : IModel
    {
        /// <summary>
        /// Time Entry ID.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Time (UTC) and date that entry was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Time (UTC) and date that entry was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Time entry notes.
        /// </summary>
        public string Notes { get; set; }

        public DateTime SpentAt { get; set; }

        /// <summary>
        /// Number of (decimal time) hours tracked in this time entry.
        /// </summary>
        public decimal Hours { get; set; }

        /// <summary>
        /// User ID that tracked this time entry.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Project ID that is referenced this time entry.
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// Project ID that the time entry is associated with.
        /// </summary>
        public long TaskId { get; set; }

        public bool AdjustmentRecord { get; set; }

        /// <summary>
        /// True if the time entry has been marked as invoiced, false if uninvoiced.
        /// </summary>
        public bool IsBilled { get; set; }

        /// <summary>
        /// True if the time entry has been approved via Timesheet Approval (no API support), false if un-approved.
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Time (UTC) and date that timer was started (if tracking by duration).
        /// Only supplied by the Daily resource.
        /// </summary>
        public DateTime? TimerStartedAt { get; set; }

        /// <summary>
        /// Starting time of entry (if timestamps are enabled).
        /// Only supplied by the Daily resource.
        /// </summary>
        public DateTime? StartedAt { get; set; }

        /// <summary>
        /// Ending time of entry (if timestamps are enabled).
        /// Only supplied by the Daily resource.
        /// </summary>
        public DateTime? EndedAt { get; set; }

        /// <summary>
        /// Task which is provided by the day entry.
        /// Only supplied by the Daily resource.
        /// <example>
        /// "Backend Programming"
        /// </example>
        /// </summary>
        public string Task { get; set; }

        /// <summary>
        /// Project in the day entry.
        /// Only supplied by the Daily resource.
        /// </summary>
        public string Project { get; set; }
    }
}

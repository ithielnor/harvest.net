using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "day-entry")]
    public class DayEntry : Harvest.Net.Models.IModel
    {
        public long Id { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Notes { get; set; }

        public DateTime SpentAt { get; set; }

        public decimal Hours { get; set; }

        public decimal HoursWithoutTimer { get; set; }

        public long UserId { get; set; }

        public long ProjectId { get; set; }

        public long TaskId { get; set; }

        public bool AdjustmentRecord { get; set; }

        public bool IsBilled { get; set; }

        public bool IsClosed { get; set; }

        /// <summary>
        /// Only supplied by the Daily resource
        /// </summary>
        public DateTime? TimerStartedAt { get; set; }

        /// <summary>
        /// Only supplied by the Daily resource
        /// </summary>
        public DateTime? StartedAt { get; set; }

        /// <summary>
        /// Only supplied by the Daily resource
        /// </summary>
        public DateTime? EndedAt { get; set; }

        /// <summary>
        /// Only supplied by the Daily resource
        /// </summary>
        public string Task { get; set; }

        /// <summary>
        /// Only supplied by the Daily resource
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Only supplied by the Daily resource
        /// </summary>
        public string Client { get; set; }

        /// <summary>
        /// Experimental. Reference to integation resource.
        /// </summary>
        public ExternalReference ExternalRef { get; set; }
    }
}

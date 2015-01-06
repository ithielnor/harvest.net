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

        public int UserId { get; set; }

        public int ProjectId { get; set; }
        
        public int TaskId { get; set; }

        public bool AdjecustmentRecord { get; set; }

        public bool IsBilled { get; set; }

        public bool IsClosed { get; set; }

        // These fields are only present when loaded from the Daily resource

        public DateTime? TimerStartedAt { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? EndedAt { get; set; }

        public string Task { get; set; }

        public string Project { get; set; }
    }
}

using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "task-assignment")]
    public class TaskAssignment : IModel
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public long TaskId { get; set; }

        public long ProjectId { get; set; }

        public bool Billable { get; set; }

        public bool Deactivated { get; set; }

        public decimal HourlyRate { get; set; }

        public decimal? Budget { get; set; }

        public decimal? Estimate { get; set; }
    }
}

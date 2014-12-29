using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "user-assignment")]
    public class UserAssignmentOptions
    {
        public long UserId { get; set; }

        public long ProjectId { get; set; }

        public bool? IsProjectManager { get; set; }

        public bool? Deactivated { get; set; }

        public decimal? HourlyRate { get; set; }

        public decimal? Budget { get; set; }
    }
}

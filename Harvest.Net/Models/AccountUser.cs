using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "user")]
    public class AccountUser
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AvatarUrl { get; set; }

        public bool Admin { get; set; }

        public string Timezone { get; set; }

        public string TimezoneIdentifier { get; set; }

        public long? TimezoneUtcOffset { get; set; }

        public bool? TimestampTimers { get; set; }

        public ProjectManager ProjectManager { get; set; }
    }
}

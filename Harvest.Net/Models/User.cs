using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "user")]
    public class User : IModel
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AvatarUrl { get; set; }

        public string IdentityUrl { get; set; }

        public string OpensocialIdentifier { get; set; }

        public string Department { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsContractor { get; set; }

        public bool IsActive { get; set; }

        public bool HasAccessToAllFutureProjects { get; set; }

        public bool WantsNewsletter { get; set; }

        public bool WantsWeeklyDigest { get; set; }

        public DateTime? WeeklyDigestSentOn { get; set; }

        public decimal? DefaultHourlyRate { get; set; }

        public decimal? CostRate { get; set; }

        public string Timezone { get; set; }
    }
}

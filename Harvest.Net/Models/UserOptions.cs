using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "user")]
    public class UserOptions
    {
        public string Email { get; set; }

        public string Telephone { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public bool? IsAdmin { get; set; }

        public bool? IsContractor { get; set; }

        public bool? IsActive { get; set; }

        public bool? HasAccessToAllFutureProjects { get; set; }

        public bool? WantsNewsletter { get; set; }

        public bool? WantsWeeklyDigest { get; set; }

        public decimal? DefaultHourlyRate { get; set; }

        public decimal? CostRate { get; set; }

        public string Timezone { get; set; }
    }
}

using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "project-manager")]
    public class ProjectManager
    {
        public bool IsProjectManager { get; set; }

        public bool CanSeeRates { get; set; }

        public bool CanCreateProjects { get; set; }

        public bool CanCreateInvoices { get; set; }
    }
}

using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Class to show the project manager capabilities of a user.
    /// </summary>
    [SerializeAs(Name = "project-manager")]
    public class ProjectManager
    {
        /// <summary>
        /// Boolean which describes if the user is a project manager.
        /// </summary>
        public bool IsProjectManager { get; set; }

        /// <summary>
        /// Boolean which describes if the user can see rates.
        /// </summary>
        public bool CanSeeRates { get; set; }

        /// <summary>
        /// Boolean which describes if the user can create projects.
        /// </summary>
        public bool CanCreateProjects { get; set; }

        /// <summary>
        /// Boolean which describes if the user can create invoices.
        /// </summary>
        public bool CanCreateInvoices { get; set; }
    }
}

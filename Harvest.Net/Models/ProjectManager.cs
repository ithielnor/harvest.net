using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

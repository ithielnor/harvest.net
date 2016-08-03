using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "modules")]
    public class Modules
    {
        public bool Expenses { get; set; }

        public bool Invoices { get; set; }

        public bool Estimates { get; set; }

        public bool Approval { get; set; }
    }
}

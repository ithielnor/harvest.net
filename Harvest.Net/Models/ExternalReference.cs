using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "external_ref")]
    public class ExternalReference
    {
        public string Id { get; set; }

        public string Namespace { get; set; }

        public string Service { get; set; }

        public string ServiceIcon { get; set; }

        public string AccountId { get; set; }

        public string GroupId { get; set; }

        public long DayEntryId { get; set; }
    }
}

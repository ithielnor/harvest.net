using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "client")]
    internal class ClientUpdate
    {
        public string Name { get; set; }

        public long? HighriseId { get; set; }

        public Currency? Currency { get; set; }

        public string Details { get; set; }
    }
}

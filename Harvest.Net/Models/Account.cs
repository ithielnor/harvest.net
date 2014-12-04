using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "hash")]
    public class Account
    {
        public Company Company { get; set; }

        public AccountUser User { get; set; }
    }
}

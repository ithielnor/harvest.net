using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "contact")]
    public class ContactOptions
    {
        public long? ClientId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Title { get; set; }

        public string Email { get; set; }

        public string PhoneOffice { get; set; }

        public string PhoneMobile { get; set; }

        public string Fax { get; set; }
    }
}

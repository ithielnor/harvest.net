using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        /// <summary>
        /// List user and account information for the authenticated account. Makes a GET request to the Account/Who_Am_I resource.
        /// </summary>
        public Account WhoAmI()
        {
            var request = Request("account/who_am_i");
            
            return Execute<Account>(request);
        }

    }
}

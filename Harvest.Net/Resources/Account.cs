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
        /// List all clients for the authenticated account. Makes a GET request to the Clients resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the client updated-at property</param>
        public Account WhoAmI()
        {
            var request = Request("account/who_am_i");
            
            return Execute<Account>(request);
        }

    }
}

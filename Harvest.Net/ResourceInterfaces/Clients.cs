using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient 
    {
        IList<Client> ListClients(DateTime? updatedSince = null);

        Client Client(long clientId);

        Client CreateClient(string name, Currency? currency = null, bool active = true, string details = null, long? highriseId = null);

        Client CreateClient(ClientOptions options);

        bool DeleteClient(long clientId);

        Client ToggleClient(long clientId);

        Client UpdateClient(long clientId, string name = null, Currency? currency = null, bool? active = null, string details = null, long? highriseId = null);

        Client UpdateClient(long clientId, ClientOptions options);
    }
}

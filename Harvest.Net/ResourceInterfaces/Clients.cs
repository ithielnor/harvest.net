using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        IList<Client> ListClients(DateTime? updatedSince = null);

        Task<IList<Client>> ListClientsAsync(DateTime? updatedSince = null);

        Client Client(long clientId);

        Task<Client> ClientAsync(long clientId);

        Client CreateClient(string name, Currency? currency = null, bool active = true, string details = null, long? highriseId = null);

        Task<Client> CreateClientAsync(string name, Currency? currency = null, bool active = true, string details = null, long? highriseId = null);

        Client CreateClient(ClientOptions options);

        Task<Client> CreateClientAsync(ClientOptions options);

        bool DeleteClient(long clientId);

        Task<bool> DeleteClientAsync(long clientId);

        Client ToggleClient(long clientId);

        Task<Client> ToggleClientAsync(long clientId);

        Client UpdateClient(long clientId, string name = null, Currency? currency = null, bool? active = null, string details = null, long? highriseId = null);

        Task<Client> UpdateClientAsync(long clientId, string name = null, Currency? currency = null, bool? active = null, string details = null, long? highriseId = null);

        Client UpdateClient(long clientId, ClientOptions options);

        Task<Client> UpdateClientAsync(long clientId, ClientOptions options);
    }
}

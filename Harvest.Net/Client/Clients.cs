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
        public IList<Client> ListClients(DateTime? updatedSince = null)
        {
            var request = Request("clients");

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return Execute<List<Client>>(request);
        }

        /// <summary>
        /// Retrieve a client. Makes a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The Id of the client to retrieve</param>
        public Client Client(long clientId)
        {
            var request = Request("clients/" + clientId, rootElement: "client");

            return Execute<Client>(request);
        }

        /// <summary>
        /// Creates a new client under the authenticated account. Makes both a POST and a GET request to the Clients resource.
        /// </summary>
        /// <param name="name">The name of the client</param>
        /// <param name="currency">The currency for the client</param>
        /// <param name="active">That status of the client</param>
        /// <param name="details">The details (address, phone, etc.) of the client</param>
        /// <param name="highriseId">The related Highrise ID of the client</param>
        public Client CreateClient(string name, Currency? currency = null, bool active = true, string details = null, long? highriseId = null)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            var newClient = new Client()
            {
                Name = name,
                Active = active
            };

            if (currency != null)
                newClient.Currency = currency.Value;
            if (details != null)
                newClient.Details = details;
            if (highriseId != null)
                newClient.HighriseId = highriseId;

            return CreateClient(newClient);
        }

        /// <summary>
        /// Creates a new client under the authenticated account. Makes both a POST and a GET request to the Clients resource.
        /// </summary>
        /// <param name="newClient">The new client object to be created</param>
        public Client CreateClient(Client newClient)
        {
            var request = Request("clients", RestSharp.Method.POST, "client");

            request.AddBody(newClient);            

            return Execute<Client>(request);
        }

        /// <summary>
        /// Delete a client from the authenticated account. Makes a DELETE request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID of the client to delete</param>
        /// <returns></returns>
        public bool DeleteClient(long clientId)
        {
            var request = Request("clients/" + clientId, RestSharp.Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}

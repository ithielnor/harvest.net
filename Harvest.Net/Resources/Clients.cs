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
        // https://github.com/harvesthq/api/blob/master/Sections/Clients.md

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
        /// Retrieve a client on the authenticated account. Makes a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The Id of the client to retrieve</param>
        public Client Client(long clientId)
        {
            var request = Request("clients/" + clientId);

            return Execute<Client>(request);
        }

        /// <summary>
        /// Creates a new client under the authenticated account. Makes both a POST and a GET request to the Clients resource.
        /// </summary>
        /// <param name="name">The name of the client</param>
        /// <param name="currency">The currency for the client</param>
        /// <param name="active">The status of the client</param>
        /// <param name="details">The details (address, phone, etc.) of the client</param>
        /// <param name="highriseId">The related Highrise ID of the client</param>
        public Client CreateClient(string name, Currency? currency = null, bool active = true, string details = null, long? highriseId = null)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            var newClient = new ClientOptions()
            {
                Name = name,
                Active = active,
                Currency = currency,
                Details = details,
                HighriseId = highriseId
            };

            return CreateClient(newClient);
        }

        /// <summary>
        /// Creates a new client under the authenticated account. Makes a POST and a GET request to the Clients resource.
        /// </summary>
        /// <param name="options">The options for the new client to be created</param>
        public Client CreateClient(ClientOptions options)
        {
            var request = Request("clients", RestSharp.Method.POST);

            request.AddBody(options);

            return Execute<Client>(request);
        }

        /// <summary>
        /// Delete a client from the authenticated account. Makes a DELETE request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID of the client to delete</param>
        public bool DeleteClient(long clientId)
        {
            var request = Request("clients/" + clientId, RestSharp.Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Toggle the Active status of a client on the authenticated account. Makes a POST request to the Clients/Toggle resource and a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID of the client to toggle</param>
        public Client ToggleClient(long clientId)
        {
            var request = Request("clients/" + clientId + "/toggle", RestSharp.Method.POST);

            return Execute<Client>(request);
        }

        /// <summary>
        /// Update a client on the authenticated account. Makes a PUT and a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID of the client to update</param>
        /// <param name="name">The updated name</param>
        /// <param name="currency">The updated currency</param>
        /// <param name="details">The updated details</param>
        /// <param name="highriseId">The updated Highrise ID</param>
        /// <param name="active">The updated state</param>
        public Client UpdateClient(long clientId, string name = null, Currency? currency = null, bool? active = null, string details = null, long? highriseId = null)
        {
            var options = new ClientOptions()
            {
                Name = name,
                Details = details,
                HighriseId = highriseId,
                Currency = currency,
                Active = active
            };

            return UpdateClient(clientId, options);
        }

        /// <summary>
        /// Updates a client on the authenticated account. Makes a PUT and a GET request to the Clients resource.
        /// </summary>
        /// <param name="clientId">The ID for the client to update</param>
        /// <param name="options">The options to be updated</param>
        public Client UpdateClient(long clientId, ClientOptions options)
        {
            var request = Request("clients/" + clientId, RestSharp.Method.PUT);

            request.AddBody(options);

            return Execute<Client>(request);
        }
    }
}

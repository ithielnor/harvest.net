using Harvest.Net.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        /// <summary>
        /// Base URL of API (defaults to https://subdomain.harvestapp.com/)
        /// </summary>
        public string BaseUrl { get; private set; }

        private string Username { get; set; }
        private string Password { get; set; }

        private RestClient _client;

        /// <summary>
        /// Initializes a new client using basic HTTP authentication
        /// </summary>
        /// <param name="subdomain">The subdomain of the harvest account to connect to</param>
        /// <param name="username">The usernamen to authenticate with</param>
        /// <param name="password">The password to athenticate with</param>
        public HarvestRestClient(string subdomain, string username, string password)
        {
            BaseUrl = "https://" + subdomain + ".harvestapp.com/";
            Username = username;
            Password = password;

            var assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = new AssemblyName(assembly.FullName);
            var version = assemblyName.Version;

            _client = new RestClient();
            _client.UserAgent = "harvest.net/" + version + " (.NET " + Environment.Version.ToString() + ")";
            _client.Authenticator = new HttpBasicAuthenticator(username, password);

            _client.BaseUrl = BaseUrl;

            // Harvest API only responds in xml currently
            //_client.AddDefaultHeader("Accept", "application/xml");
            //_client.AddDefaultHeader("Content-Type", "application/xml");

            _client.AddHandler("application/json", new HarvestJsonDeserializer());
        }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <typeparam name="T">The type to create and return</typeparam>
        /// <param name="request">The request to send</param>
        public virtual T Execute<T>(RestRequest request) where T : new()
        {
            var response = _client.Execute<T>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created || response.StatusCode == System.Net.HttpStatusCode.Accepted
                || (response.StatusCode == System.Net.HttpStatusCode.OK && request.Method == Method.PUT))
            {
                string location = null;

                var header = response.Headers.FirstOrDefault(h => h.Type == ParameterType.HttpHeader && h.Name == "Location");
                if (header != null)
                {
                    location = (string)header.Value;
                }
                else
                {
                    // Location header is missing try to GET from the original resource instead
                    location = request.Resource;
                }

                var loadRequest = Request(location, rootElement: request.RootElement);
                response = _client.Execute<T>(loadRequest);
            }

            return response.Data;
        }

        public virtual IRestResponse Execute(RestRequest request)
        {
            return _client.Execute(request);
        }


        /// <summary>
        /// Initializes a new RestRequest object with a custom XmlSerializer and DateFormat to match Harvest's conventions.
        /// </summary>
        /// <param name="resource">Harvest resource request will hit</param>
        /// <param name="method">HTTP method to use</param>
        protected RestRequest Request(string resource, Method method = Method.GET, string rootElement = null)
        {
            var request = new RestRequest();
            request.Resource = resource;
            request.Method = method;
            request.RootElement = rootElement;

            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new HarvestXmlSerializer();
         
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            return request;
        }
    }
}

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

            // Harvest API only response in xml currently
            _client.AddDefaultHeader("Accept", "application/xml");
            _client.AddDefaultHeader("Content-Type", "application/xml");
        }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <typeparam name="T">The type to create and return</typeparam>
        /// <param name="request">The request to send</param>
        public virtual T Execute<T>(RestRequest request) where T : new()
        {
            request.OnBeforeDeserialization = (resp) =>
            {
                // for individual resources when there's an error to make
                // sure that RestException props are populated
                if (((int)resp.StatusCode) >= 400)
                {
                    // have to read the bytes so .Content doesn't get populated
                    string restException = "{{ \"RestException\" : {0} }}";
                    var content = System.Text.Encoding.Default.GetString(resp.RawBytes);
                    var newJson = string.Format(restException, content);

                    resp.Content = null;
                    resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
                }
            };

            request.DateFormat = @"yyyy-MM-dd\Thh:mm:ss\Z";

            var response = _client.Execute<T>(request);

            return response.Data;
        }
    }
}

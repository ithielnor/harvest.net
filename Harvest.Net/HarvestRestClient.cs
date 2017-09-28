using Harvest.Net.Models;
using Harvest.Net.Models.Interfaces;
using Harvest.Net.Network;
using Harvest.Net.Serialization;
using Harvest.Net.Utilities;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial class HarvestRestClient : IHarvestRestClient
    {
        /// <summary>
        /// Base URL of API
        /// </summary>
        public string BaseUrl { get; private set; }

        /// <summary>
        /// The date format configured in Harvest (default: yyyy-MM-dd)
        /// </summary>
        public string DateFormat { get; set; }

        #region Privates
        private string Username { get; set; }

        private string Password { get; set; }

        private string ClientId { get; set; }

        private string ClientSecret { get; set; }

        private string AccessToken { get; set; }

        private IRestClient _client;

        // This is a container for dependencies, until an IoC container can be brought in. It will help maintain the same interface for the user
        private static IDictionary<string, object> Dependencies =
            new Dictionary<string, object>
            {
                { IAssemblyInformation_Name, new AssemblyInformation() },
                { IEnvironmentInformation_Name, new EnvironmentInformation() },
                { IRestSharpFactory_Name, new RestSharpFactory() }
            };

        private const string IAssemblyInformation_Name = "IAssemblyInformation";
        private const string IEnvironmentInformation_Name = "IEnvironmentInformation";
        private const string IRestSharpFactory_Name = "IRestSharpFactory";

        /// <summary>
        /// Constructs a client for executing all api commands.
        /// </summary>
        /// <param name="subdomain">The harvest account subdomain</param>
        /// <param name="username">The harvest account username (optional for OAuth)</param>
        /// <param name="password">The harvest account password (optional for OAuth)</param>
        /// <param name="clientId">The harvest account client OAuth ID (optional for basic auth)</param>
        /// <param name="clientSecret">The harvest account client OAuth secret (optional for basic auth)</param>
        /// <param name="accessToken">The harvest account OAuth token (optional for basic auth)</param>
        /// <param name="dateFormat">The date format of the harvest account (default: yyyy-MM-dd)</param>
        private HarvestRestClient(string subdomain, string username, string password, string clientId, string clientSecret,
            string accessToken, string dateFormat, IAssemblyInformation assemblyInformation, IEnvironmentInformation environmentInformation,
            IRestSharpFactory restSharpFactory)
        {
            this.Username = username;
            this.Password = password;
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.AccessToken = accessToken;
            this.DateFormat = dateFormat ?? "yyyy-MM-dd";

            this.BaseUrl = "https://" + subdomain + ".harvestapp.com/";

            var assemblyVersion = assemblyInformation.Version;
            var environmentVersion = environmentInformation.Version;
            var userAgent = string.Format("harvest.net/{0} (.NET {1})", assemblyVersion, environmentVersion);

            if (username != null && password != null)
                _client = restSharpFactory.GetWebClient(BaseUrl, userAgent, username, password);
            else if (accessToken != null)
                _client = restSharpFactory.GetWebClient(BaseUrl, userAgent, accessToken);
            else
                _client = restSharpFactory.GetWebClient(BaseUrl, userAgent);
        }
        #endregion

        /// <summary>
        /// Initializes a new client using basic HTTP authentication and default depenedencies
        /// </summary>
        /// <param name="subdomain">The subdomain of the harvest account to connect to</param>
        /// <param name="username">The username to authenticate with</param>
        /// <param name="password">The password to athenticate with</param>
        public HarvestRestClient(string subdomain, string username, string password)
            : this(subdomain, username, password, null, null, null, null,
                  (IAssemblyInformation)Dependencies[IAssemblyInformation_Name],
                  (IEnvironmentInformation)Dependencies[IEnvironmentInformation_Name],
                  (IRestSharpFactory)Dependencies[IRestSharpFactory_Name])
        { }

        /// <summary>
        /// Initializes a new client using basic HTTP authentication and non-default dependencies
        /// </summary>
        /// <param name="subdomain">The subdomain of the harvest account to connect to</param>
        /// <param name="username">The username to authenticate with</param>
        /// <param name="password">The password to athenticate with</param>
        public HarvestRestClient(string subdomain, string username, string password, IAssemblyInformation assemblyInformation,
            IEnvironmentInformation environmentInformation, IRestSharpFactory restSharpFactory)
            : this(subdomain, username, password, null, null, null, null, assemblyInformation, environmentInformation, restSharpFactory)
        { }

        /// <summary>
        /// Initializes a new client using OAuth2 authentication
        /// </summary>
        /// <param name="subdomain">The subdomain of the harvest account to connect to</param>
        /// <param name="clientId">The OAuth client ID</param>
        /// <param name="clientSecret">The OAuth client secret</param>
        /// <param name="accessToken">The OAuth access token</param>
        public HarvestRestClient(string subdomain, string clientId, string clientSecret, string accessToken)
            : this(subdomain, null, null, clientId, clientSecret, accessToken, null,
                  (IAssemblyInformation)Dependencies[IAssemblyInformation_Name],
                  (IEnvironmentInformation)Dependencies[IEnvironmentInformation_Name],
                  (IRestSharpFactory)Dependencies[IRestSharpFactory_Name])
        { }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <typeparam name="T">The type to create and return</typeparam>
        /// <param name="request">The request to send</param>
        public virtual T Execute<T>(IRestRequest request)
            where T : new()
        {
            var response = _client.Execute<T>(request);

            response.ThrowIfBadRequest();

            if (ShouldRequestLocationData(request, response))
            {
                var loadRequest = GetLocationHeaderRequest(request, response);
                response = _client.Execute<T>(loadRequest);
            }

            return response.Data;
        }

        /// <summary>
        /// Execute a manual REST request asynchronously
        /// </summary>
        /// <typeparam name="T">The type to create and return</typeparam>
        /// <param name="request">The request to send</param>
        public virtual async Task<T> ExecuteAsync<T>(IRestRequest request)
            where T : new()
        {
            var response = await _client.ExecuteTaskAsync<T>(request).ConfigureAwait(false);

            response.ThrowIfBadRequest();

            if (ShouldRequestLocationData(request, response))
            {
                var loadRequest = GetLocationHeaderRequest(request, response);
                response = await _client.ExecuteTaskAsync<T>(loadRequest).ConfigureAwait(false);
            }

            return response.Data;
        }

        /// <summary>
        /// Execute a non-generic REST request
        /// </summary>
        /// <param name="request">The request to send</param>
        public virtual IRestResponse Execute(IRestRequest request)
        {
            return _client.Execute(request);
        }

        /// <summary>
        /// Execute a non-generic REST request asynchronously
        /// </summary>
        /// <param name="request">The request to send</param>
        public virtual Task<IRestResponse> ExecuteAsync(IRestRequest request)
        {
            return _client.ExecuteTaskAsync(request);
        }

        /// <summary>
        /// Request a new access token
        /// </summary>
        /// <param name="refreshToken">An unexpired refresh token provided to the authenticated client ID.</param>
        /// <returns></returns>
        public IOAuth RefreshToken(string refreshToken)
        {
            var r = GetOAuthRefreshRequest(refreshToken);

            return Execute<OAuth>(r);
        }

        /// <summary>
        /// Request a new access token asynchronously
        /// </summary>
        /// <param name="refreshToken">An unexpired refresh token provided to the authenticated client ID.</param>
        /// <returns></returns>
        public Task<OAuth> RefreshTokenAsync(string refreshToken)
        {
            var r = GetOAuthRefreshRequest(refreshToken);

            return ExecuteAsync<OAuth>(r);
        }

        /// <summary>
        /// Initializes a new RestRequest object with a custom XmlSerializer and DateFormat to match Harvest's conventions.
        /// </summary>
        /// <param name="resource">Harvest resource request will hit</param>
        /// <param name="method">HTTP method to use</param>
        protected IRestRequest Request(string resource, Method method = Method.GET)
        {
            var request = new RestRequest
            {
                Resource = resource,
                Method = method,
                RequestFormat = DataFormat.Xml,
                XmlSerializer = new HarvestXmlSerializer
                {
                    DateFormat = this.DateFormat
                },
                OnBeforeDeserialization = resp =>
                {
                    // remove the first ByteOrderMark
                    // see: http://stackoverflow.com/questions/19663100/restsharp-has-problems-deserializing-xml-including-byte-order-mark
                    string byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
                    if (resp.Content.StartsWith(byteOrderMarkUtf8))
                        resp.Content = resp.Content.TrimStart(byteOrderMarkUtf8.ToArray());
                }
            };

            return request;
        }

        private static bool ShouldRequestLocationData<T>(IRestRequest request, IRestResponse<T> response)
        {
            return response.Data == null
                && (response.StatusCode == System.Net.HttpStatusCode.Created
                || response.StatusCode == System.Net.HttpStatusCode.Accepted
                || (response.StatusCode == System.Net.HttpStatusCode.OK && (request.Method == Method.PUT || request.Method == Method.POST)));
        }

        private IRestRequest GetLocationHeaderRequest(IRestRequest request, IRestResponse response)
        {
            string location;

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

            return Request(location);
        }

        private IRestRequest GetOAuthRefreshRequest(string refreshToken)
        {
            var r = new RestRequest
            {
                Method = Method.POST,
                Resource = "oauth2/token"
            };

            r.AddParameter("refresh_token", refreshToken);
            r.AddParameter("client_id", ClientId);
            r.AddParameter("client_secret", ClientSecret);
            r.AddParameter("grant_type", "refresh_token");
            r.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            return r;
        }
    }
}

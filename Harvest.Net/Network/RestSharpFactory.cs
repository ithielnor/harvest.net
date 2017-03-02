using Harvest.Net.Serialization;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Network
{
    public class RestSharpFactory : IRestSharpFactory
    {
        public IRestClient GetWebClient(string baseUrl, string userAgent, string accessToken)
        {
            var client = GetBasicClient(baseUrl, userAgent);
            client.AddDefaultParameter("access_token", accessToken, ParameterType.QueryString);
            return client;
        }

        public IRestClient GetWebClient(string baseUrl, string userAgent, string username, string password)
        {
            var client = GetBasicClient(baseUrl, userAgent);
            client.Authenticator = new HttpBasicAuthenticator(username, password);
            return client;
        }

        public IRestClient GetWebClient(string baseUrl, string userAgent)
        {
            var client = GetBasicClient(baseUrl, userAgent);
            return client;
        }

        private IRestClient GetBasicClient(string baseUrl, string userAgent)
        {
            var client = new RestClient(baseUrl);
            client.UserAgent = userAgent;

            // Harvest API is inconsistent in JSON responses so we'll stick to XML
            client.ClearHandlers();
            client.AddHandler("application/xml", new HarvestXmlDeserializer());
            client.AddHandler("text/xml", new HarvestXmlDeserializer());

            return client;
        }
    }
}

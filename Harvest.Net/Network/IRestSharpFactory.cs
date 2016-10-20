using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Network
{
    public interface IRestSharpFactory
    {
        IRestClient GetWebClient(string baseUrl, string userAgent, string username, string password);

        IRestClient GetWebClient(string baseUrl, string userAgent, string accessToken);

        IRestClient GetWebClient(string baseUrl, string userAgent);
    }
}

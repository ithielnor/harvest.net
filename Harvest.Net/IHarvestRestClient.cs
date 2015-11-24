using Harvest.Net.Models.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public interface IHarvestRestClient
    {
        string BaseUrl { get; }
        string DateFormat { get; set; }
        T Execute<T>(IRestRequest request) where T : new();
        IRestResponse Execute(IRestRequest request);
        IOAuth RefreshToken(string refreshToken);
    }
}

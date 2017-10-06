using Harvest.Net.Models.Interfaces;
using RestSharp;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        string BaseUrl { get; }

        string DateFormat { get; set; }

        T Execute<T>(IRestRequest request)
            where T : new();

        IRestResponse Execute(IRestRequest request);

        IOAuth RefreshToken(string refreshToken);
    }
}

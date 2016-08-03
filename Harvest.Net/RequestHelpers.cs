using System;
using Harvest.Net.Models;
using RestSharp;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        private IRestRequest ListRequest(string resource, DateTime? updatedSince)
        {
            var request = Request(resource);

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return request;
        }

        private IRestRequest Request(string resource, long resourceId, string action, Method method)
        {
            if (string.IsNullOrWhiteSpace(action))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(action));
            
            string resourceUrl = $"{resource}/{resourceId}/{action}";
            
            return Request(resourceUrl, method);
        }

        private IRestRequest Request(string resource, long resourceId, Method method)
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(resource));

            string resourceUrl = $"{resource}/{resourceId}";

            return Request(resourceUrl, method);
        }
        
        private IRestRequest CreateRequest<TOptions>(string resource, TOptions options)
            where TOptions : class, new()
        {
            return Request(resource, Method.POST).AddBody(options);
        }

        private IRestRequest UpdateRequest<TOptions>(string resource, long resourceId, TOptions options)
            where TOptions : class, new()
        {
            return Request(resource, resourceId, Method.PUT).AddBody(options);
        }
    }
}

using Harvest.Net.Models;
using RestSharp;
using RestSharp.Deserializers;
using System;

namespace Harvest.Net
{
    public class HarvestException : Exception
    {
        public HarvestException(IRestResponse response)
        {
            Response = response;

            try
            {
                IDeserializer deserializer = new XmlDeserializer();
                Result = deserializer.Deserialize<ErrorResult>(response);
            }
            catch
            {
                // could not deserialize the response... eat it
            }
        }

        public IRestResponse Response { get; private set; }

        public ErrorResult Result { get; private set; }

        public override string Message
        {
            get
            {
                if (Result != null)
                    return Result.Message;
                else
                    return "An error occurred, but could not deserialize the error response";
            }
        }
    }
}

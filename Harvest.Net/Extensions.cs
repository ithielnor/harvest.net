using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Harvest.Net
{
    internal static class Extensions
    {
        internal static long? ParseNullableLong(this string input)
        {
            long output;
            if (long.TryParse(input, out output))
                return output;
            return null;
        }

        internal static string ToYesNo(this bool input)
        {
            return input ? "yes" : "no";
        }

        internal static void ThrowIfBadRequest(this IRestResponse response)
        {
            if ((int)response.StatusCode >= 400)
                throw new HarvestException(response);
        }

        internal static bool IsSuccessfulDelete(this IRestResponse response)
        {
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}

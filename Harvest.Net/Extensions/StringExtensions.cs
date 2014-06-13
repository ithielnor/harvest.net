using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Extensions
{
    public static class StringExtensions
    {
        public static long? ParseNullableLong(this string input)
        {
            long output;
            if (long.TryParse(input, out output))
                return output;
            return null;
        }
    }
}

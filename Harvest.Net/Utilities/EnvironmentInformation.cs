using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Utilities
{
    public class EnvironmentInformation : IEnvironmentInformation
    {
        public Version Version
        {
            get
            {
                return Environment.Version;
            }
        }
    }
}

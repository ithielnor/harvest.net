using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Utilities
{
    public class AssemblyInformation : IAssemblyInformation
    {
        public Version Version
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                AssemblyName assemblyName = new AssemblyName(assembly.FullName);
                return assemblyName.Version;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Serialization
{
    public class HarvestSerializeAttribute : Attribute
    {
        public bool DateOnly { get; set; }
    }
}

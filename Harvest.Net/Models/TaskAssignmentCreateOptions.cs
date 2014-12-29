using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "task")]
    internal class TaskAssignmentCreateOptions
    {
        public long Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    public interface IModel
    {
        long Id { get; set; }

        DateTime UpdatedAt { get; set; }

        DateTime CreatedAt { get; set; }
    }
}

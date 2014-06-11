using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    public class Client : IModel
    {
        public long Id { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public long? HighriseId { get; set; }

        public long CacheVersion { get; set; }

        public Currency Currency { get; set; }

        public bool Active { get; set; }

        public string CurrencySymbol { get; set; }

        public string Details { get; set; }
    }
}

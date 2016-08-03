using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "expense-category")]
    public class ExpenseCategory : IModel
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string Name { get; set; }

        public string UnitName { get; set; }

        public decimal? UnitPrice { get; set; }

        public bool Deactivated { get; set; }
    }
}

using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "expense-category")]
    public class ExpenseCategoryOptions
    {
        public string Name { get; set; }

        public string UnitName { get; set; }

        public decimal? UnitPrice { get; set; }
    }
}

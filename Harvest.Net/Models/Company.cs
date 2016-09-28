using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "company")]
    public class Company
    {
        public string BaseUri { get; set; }

        public string FullDomain { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public WeekDay WeekStartDay { get; set; }

        public string TimeFormat { get; set; }

        public string Clock { get; set; }

        public char DecimalSymbol { get; set; }

        public char ThousandsSeparator { get; set; }

        public string ColorScheme { get; set; }

        public string PlanType { get; set; }

        public Modules Modules { get; set; }
    }
}

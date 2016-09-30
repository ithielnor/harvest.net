using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Simple Company object returned by the API.
    /// </summary>
    [SerializeAs(Name = "company")]
    public class Company
    {
        /// <summary>
        /// Base URI of the company.
        /// <example>
        /// https://youraccount.harvestapp.com
        /// </example>
        /// </summary>
        public string BaseUri { get; set; }

        /// <summary>
        /// The full domain of the company.
        /// <example>
        /// youraccount.harvestapp.com
        /// </example>
        /// </summary>
        public string FullDomain { get; set; }

        /// <summary>
        /// Name of the Harvest account.
        /// <example>
        /// Your Harvest Account
        /// </example>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Boolean Value to check if the company is active in harvest.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Day where the work week is starting for the company. Further information can be found in <see cref="WeekDay"/>.
        /// </summary>
        public WeekDay WeekStartDay { get; set; }

        /// <summary>
        /// Time format given by the API.
        /// <example>
        /// decimal
        /// </example>
        /// </summary>
        public string TimeFormat { get; set; }

        /// <summary>
        /// Format which is used for the clock.
        /// <example>
        /// 12h
        /// </example>
        /// </summary>
        public string Clock { get; set; }

        /// <summary>
        /// Symbol which is used for decimal numbers.
        /// <example>
        /// .
        /// </example>
        /// <example>
        /// ,
        /// </example>
        /// </summary>
        public char DecimalSymbol { get; set; }

        /// <summary>
        /// Seperator which should be used for dividing big numbers.
        /// <example>
        /// ,
        /// </example>
        /// <example>
        /// .
        /// </example>
        /// </summary>
        public char ThousandsSeparator { get; set; }

        /// <summary>
        /// Color scheme which is used in the app.
        /// </summary>
        public string ColorScheme { get; set; }

        /// <summary>
        /// Plan type of the company.
        /// </summary>
        public string PlanType { get; set; }

        /// <summary>
        /// Modules which are used by the company. For further information lookup <see cref="Modules"/>.
        /// </summary>
        public Modules Modules { get; set; }
    }
}

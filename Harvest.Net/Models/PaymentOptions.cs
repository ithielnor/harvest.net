using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for creating or updating Payment Models in the harvest API.
    /// </summary>
    [SerializeAs(Name = "payment")]
    public class PaymentOptions
    {
        /// <summary>
        /// Amount of the payment.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Date where the payment was done.
        /// </summary>
        public DateTime? PaidAt { get; set; }

        /// <summary>
        /// Additional notes of the payment.
        /// </summary>
        public string Notes { get; set; }
    }
}

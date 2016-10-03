using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Payment model which is used to show payments.
    /// </summary>
    [SerializeAs(Name = "payment")]
    public class Payment : IModel
    {
        /// <summary>
        /// Identifier of the payment.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Time when the payment was updated last.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Time when the payment was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Amount of the payment.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Id of the invoice which is referenced.
        /// </summary>
        public long InvoiceId { get; set; }

        /// <summary>
        /// Date where the payment was done.
        /// </summary>
        public DateTime PaidAt { get; set; }

        /// <summary>
        /// Additional notes of the payment.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Name of the person who recorded the payment.
        /// Example:
        /// <example>
        /// Jane Example
        /// </example>
        /// </summary>
        public string RecordedBy { get; set; }

        /// <summary>
        /// E-Mail of the person who recorded the payment.
        /// <example>
        /// support@harvestapp.com
        /// </example>
        /// </summary>
        public string RecordedByEmail { get; set; }

        /// <summary>
        /// Id of the paypal transaction.
        /// Can be null.
        /// </summary>
        public string PayPalTransactionId { get; set; }

        /// <summary>
        /// Authorization of the payment.
        /// </summary>
        public string Authorization { get; set; }

        /// <summary>
        /// Payment gateway id.
        /// </summary>
        public long? PaymentGatewayId { get; set; }
    }
}

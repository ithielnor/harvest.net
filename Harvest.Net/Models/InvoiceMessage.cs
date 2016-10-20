using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Invoice message model of the harvest API which is used to show invoice messages.
    /// </summary>
    [SerializeAs(Name = "invoice-message")]
    public class InvoiceMessage : IModel
    {
        /// <summary>
        /// Identifier of the invoice message.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Time when the invoice message was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Time when the invoice message was updated last.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Id to the referenced invoice.
        /// </summary>
        public long InvoiceId { get; set; }

        /// <summary>
        /// Value which describes if the owner of the invoice is getting a copy of this invoice message.
        /// </summary>
        public bool SendMeACopy { get; set; }

        /// <summary>
        /// Username who sent the invoice.
        /// </summary>
        public string SentBy { get; set; }

        /// <summary>
        /// E-Mail which the invoice was created by.
        /// </summary>
        public string SentByEmail { get; set; }

        /// <summary>
        /// A list of recipients.
        /// </summary>
        public string FullRecipientList { get; set; }

        /// <summary>
        /// Main Text of the invoice message.
        /// </summary>
        public string Body { get; set; }
    }
}

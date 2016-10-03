using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for creating and updating invoice messages.
    /// </summary>
    [SerializeAs(Name = "invoice-message")]
    public class InvoiceMessageOptions
    {
        /// <summary>
        /// Text body of the invoice message.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Value which describes if an pdf is attached to the invoice message.
        /// </summary>
        public bool AttachPdf { get; set; }

        /// <summary>
        /// Include a payment link in the message body.
        /// </summary>
        public bool IncludePayPalLink { get; set; }

        /// <summary>
        /// Send a copy to the current user.
        /// </summary>
        public bool SendMeACopy { get; set; }

        /// <summary>
        /// Comma delimited list of recipient emails.
        /// </summary>
        public string Recipients { get; set; }
    }
}

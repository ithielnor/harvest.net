using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Options which are used for interacting with contacts in the harvest API.
    /// </summary>
    [SerializeAs(Name = "contact")]
    public class ContactOptions
    {
        /// <summary>
        /// Identifier of the client.
        /// <example>
        /// 3398386
        /// </example>
        /// </summary>
        public long? ClientId { get; set; }

        /// <summary>
        /// First name of the contact.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the contact.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Title of the contact.
        /// Example: 
        /// <example>
        /// Mrs
        /// </example>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// E-Mail of the contact.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number to the office of the contact.
        /// </summary>
        public string PhoneOffice { get; set; }

        /// <summary>
        /// Phone number of the mobile phone of the contact.
        /// </summary>
        public string PhoneMobile { get; set; }

        /// <summary>
        /// Fax of the contact.
        /// </summary>
        public string Fax { get; set; }
    }
}

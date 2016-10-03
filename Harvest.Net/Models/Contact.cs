using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for a contact in the harvest system.
    /// It is used to add or update contacts.
    /// </summary>
    [SerializeAs(Name = "contact")]
    public class Contact : IModel
    {
        /// <summary>
        /// Identifier of the contact.
        /// Example:
        /// <example>
        /// 2937808
        /// </example>
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Time when the contact entry was updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Time when the contact entry was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Identifier of the client.
        /// <example>
        /// 3398386
        /// </example>
        /// </summary>
        public long ClientId { get; set; }

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

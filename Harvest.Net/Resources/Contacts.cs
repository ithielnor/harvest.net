using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        // https://github.com/harvesthq/api/blob/master/Sections/Client%20Contacts.md

        /// <summary>
        /// List all contacts for the authenticated account. Makes a GET request to the Contacts resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the contact updated-at property</param>
        public IList<Contact> ListContacts(DateTime? updatedSince = null)
        {
            var request = Request("contacts");

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return Execute<List<Contact>>(request);
        }

        /// <summary>
        /// List all contacts for a client for the authenticated account. Makes a GET request to the Clients/Contacts resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the contact updated-at property</param>
        public IList<Contact> ListClientContacts(long clientId, DateTime? updatedSince = null)
        {
            var request = Request("clients/" + clientId + "/contacts");

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return Execute<List<Contact>>(request);
        }

        /// <summary>
        /// Retrieve a contact on the authenticated account. Makes a GET request to the Contacts resource.
        /// </summary>
        /// <param name="contactId">The Id of the contact to retrieve</param>
        public Contact Contact(long contactId)
        {
            var request = Request("contacts/" + contactId);

            return Execute<Contact>(request);
        }

        /// <summary>
        /// Create a new contact for a client on the authenticated account. Makes both a POST and a GET request to the Contacts resource.
        /// </summary>
        /// <param name="clientId">The ID of the client this contact is for</param>
        /// <param name="firstName">The first name of the contact</param>
        /// <param name="lastName">The last name of the contact</param>
        /// <param name="title">The contact's title</param>
        /// <param name="email">The contact's email</param>
        /// <param name="phoneOffice">The contact's office phone number</param>
        /// <param name="phoneMobile">The contact's mobile phone number</param>
        /// <param name="fax">The contact's fax number</param>
        public Contact CreateContact(long clientId, string firstName, string lastName, string title = null, string email = null, string phoneOffice = null, string phoneMobile = null, string fax = null)
        {
            if (firstName == null)
                throw new ArgumentNullException("firstName");

            if (lastName == null)
                throw new ArgumentNullException("lastName");

            var newContact = new ContactOptions()
            {
                ClientId = clientId,
                FirstName = firstName,
                LastName = lastName,
                Title = title,
                Email = email,
                PhoneOffice = phoneOffice,
                PhoneMobile = phoneMobile,
                Fax = fax
            };

            return CreateContact(newContact);
        }

        /// <summary>
        /// Creates a new contact under the authenticated account. Makes a POST and a GET request to the Contacts resource.
        /// </summary>
        /// <param name="options">The options for the new contact to be created</param>
        public Contact CreateContact(ContactOptions options)
        {
            var request = Request("contacts", RestSharp.Method.POST);

            request.AddBody(options);

            return Execute<Contact>(request);
        }

        /// <summary>
        /// Delete a contact from the authenticated account. Makes a DELETE request to the Contacts resource.
        /// </summary>
        /// <param name="contactId">The ID of the contact to delete</param>
        public bool DeleteContact(long contactId)
        {
            var request = Request("contacts/" + contactId, RestSharp.Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Update an existing contact on the authenticated account. Makes both a PUT and GET request to the Contacts resource.
        /// </summary>
        /// <param name="contactId">The ID of the contact to update</param>
        /// <param name="clientId">The ID of the client this contact is for</param>
        /// <param name="firstName">The first name of the contact</param>
        /// <param name="lastName">The last name of the contact</param>
        /// <param name="title">The contact's title</param>
        /// <param name="email">The contact's email</param>
        /// <param name="phoneOffice">The contact's office phone number</param>
        /// <param name="phoneMobile">The contact's mobile phone number</param>
        /// <param name="fax">The contact's fax number</param>
        public Contact UpdateContact(long contactId, long? clientId = null, string firstName = null, string lastName = null, string title = null, string email = null, string phoneOffice = null, string phoneMobile = null, string fax = null)
        {
            var options = new ContactOptions()
            {
                ClientId = clientId,
                FirstName = firstName,
                LastName = lastName,
                Title = title,
                Email = email,
                PhoneOffice = phoneOffice,
                PhoneMobile = phoneMobile,
                Fax = fax
            };

            return UpdateContact(contactId, options);
        }

        /// <summary>
        /// Update an existing contact on the authenticated account. Makes both a PUT and GET request to the Contacts resource.
        /// </summary>
        /// <param name="contactId">The ID of the contact to update</param>
        /// <param name="options">The update options for the contact</param>
        public Contact UpdateContact(long contactId, ContactOptions options)
        {
            var request = Request("contacts/" + contactId, RestSharp.Method.PUT);

            request.AddBody(options);

            return Execute<Contact>(request);
        }
    }
}

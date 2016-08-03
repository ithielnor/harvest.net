using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        private const string CONTACTS_RESOURCE = "contacts";

        // https://github.com/harvesthq/api/blob/master/Sections/Client%20Contacts.md

        /// <summary>
        /// List all contacts for the authenticated account. Makes a GET request to the Contacts resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the contact updated-at property</param>
        public IList<Contact> ListContacts(DateTime? updatedSince = null)
        {
            var request = ListRequest(CONTACTS_RESOURCE, updatedSince);

            return Execute<List<Contact>>(request);
        }

        /// <summary>
        /// List all contacts for the authenticated account. Makes a GET request to the Contacts resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the contact updated-at property</param>
        public async Task<IList<Contact>> ListContactsAsync(DateTime? updatedSince = null)
        {
            var request = ListRequest(CONTACTS_RESOURCE, updatedSince);

            return await ExecuteAsync<List<Contact>>(request);
        }

        /// <summary>
        /// List all contacts for a client for the authenticated account. Makes a GET request to the Clients/Contacts resource.
        /// </summary>
        /// <param name="clientId">The client ID for which to list contacts.</param>
        /// <param name="updatedSince">An optional filter on the contact updated-at property</param>
        public IList<Contact> ListClientContacts(long clientId, DateTime? updatedSince = null)
        {
            var request = ListClientContactsRequest(clientId, updatedSince);

            return Execute<List<Contact>>(request);
        }

        /// <summary>
        /// List all contacts for a client for the authenticated account. Makes a GET request to the Clients/Contacts resource.
        /// </summary>
        /// <param name="clientId">The client ID for which to list contacts.</param>
        /// <param name="updatedSince">An optional filter on the contact updated-at property</param>
        public async Task<IList<Contact>> ListClientContactsAsync(long clientId, DateTime? updatedSince = null)
        {
            var request = ListClientContactsRequest(clientId, updatedSince);

            return await ExecuteAsync<List<Contact>>(request);
        }

        /// <summary>
        /// Retrieve a contact on the authenticated account. Makes a GET request to the Contacts resource.
        /// </summary>
        /// <param name="contactId">The Id of the contact to retrieve</param>
        public Contact Contact(long contactId)
        {
            var request = Request(CONTACTS_RESOURCE, contactId, Method.GET);

            return Execute<Contact>(request);
        }

        /// <summary>
        /// Retrieve a contact on the authenticated account. Makes a GET request to the Contacts resource.
        /// </summary>
        /// <param name="contactId">The Id of the contact to retrieve</param>
        public Task<Contact> ContactAsync(long contactId)
        {
            var request = Request(CONTACTS_RESOURCE, contactId, Method.GET);

            return ExecuteAsync<Contact>(request);
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
            var newContact = GetContactOptions(clientId, firstName, lastName, title, email, phoneOffice, phoneMobile, fax);

            return CreateContact(newContact);
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
        public Task<Contact> CreateContactAsync(long clientId, string firstName, string lastName, string title = null, string email = null, string phoneOffice = null, string phoneMobile = null, string fax = null)
        {
            var newContact = GetContactOptions(clientId, firstName, lastName, title, email, phoneOffice, phoneMobile, fax);

            return CreateContactAsync(newContact);
        }

        /// <summary>
        /// Creates a new contact under the authenticated account. Makes a POST and a GET request to the Contacts resource.
        /// </summary>
        /// <param name="options">The options for the new contact to be created</param>
        public Contact CreateContact(ContactOptions options)
        {
            var request = CreateRequest(CONTACTS_RESOURCE, options);

            return Execute<Contact>(request);
        }

        /// <summary>
        /// Creates a new contact under the authenticated account. Makes a POST and a GET request to the Contacts resource.
        /// </summary>
        /// <param name="options">The options for the new contact to be created</param>
        public Task<Contact> CreateContactAsync(ContactOptions options)
        {
            var request = CreateRequest(CONTACTS_RESOURCE, options);

            return ExecuteAsync<Contact>(request);
        }

        /// <summary>
        /// Delete a contact from the authenticated account. Makes a DELETE request to the Contacts resource.
        /// </summary>
        /// <param name="contactId">The ID of the contact to delete</param>
        public bool DeleteContact(long contactId)
        {
            var request = Request(CONTACTS_RESOURCE, contactId, Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Delete a contact from the authenticated account. Makes a DELETE request to the Contacts resource.
        /// </summary>
        /// <param name="contactId">The ID of the contact to delete</param>
        public async Task<bool> DeleteContactAsync(long contactId)
        {
            var request = Request(CONTACTS_RESOURCE, contactId, Method.DELETE);

            var result = await ExecuteAsync(request);

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
            var options = GetContactOptions(clientId, firstName, lastName, title, email, phoneOffice, phoneMobile, fax);

            return UpdateContact(contactId, options);
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
        public Task<Contact> UpdateContactAsync(long contactId, long? clientId = null, string firstName = null, string lastName = null, string title = null, string email = null, string phoneOffice = null, string phoneMobile = null, string fax = null)
        {
            var options = GetContactOptions(clientId, firstName, lastName, title, email, phoneOffice, phoneMobile, fax);

            return UpdateContactAsync(contactId, options);
        }

        /// <summary>
        /// Update an existing contact on the authenticated account. Makes both a PUT and GET request to the Contacts resource.
        /// </summary>
        /// <param name="contactId">The ID of the contact to update</param>
        /// <param name="options">The update options for the contact</param>
        public Contact UpdateContact(long contactId, ContactOptions options)
        {
            var request = UpdateRequest(CONTACTS_RESOURCE, contactId, options);

            return Execute<Contact>(request);
        }

        /// <summary>
        /// Update an existing contact on the authenticated account. Makes both a PUT and GET request to the Contacts resource.
        /// </summary>
        /// <param name="contactId">The ID of the contact to update</param>
        /// <param name="options">The update options for the contact</param>
        public Task<Contact> UpdateContactAsync(long contactId, ContactOptions options)
        {
            var request = UpdateRequest(CONTACTS_RESOURCE, contactId, options);

            return ExecuteAsync<Contact>(request);
        }
        
        private static ContactOptions GetContactOptions(long? clientId, string firstName, string lastName, string title, string email, string phoneOffice, string phoneMobile, string fax)
        {
            if (firstName == null)
                throw new ArgumentNullException(nameof(firstName));

            if (lastName == null)
                throw new ArgumentNullException(nameof(lastName));

            var newContact = new ContactOptions
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

            return newContact;
        }

        private IRestRequest ListClientContactsRequest(long clientId, DateTime? updatedSince) 
            => ListRequest($"{CLIENTS_RESOURCE}/{clientId}/{CONTACTS_RESOURCE}", updatedSince);
    }
}

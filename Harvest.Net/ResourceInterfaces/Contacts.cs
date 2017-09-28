using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        IList<Contact> ListContacts(DateTime? updatedSince = null);

        Task<IList<Contact>> ListContactsAsync(DateTime? updatedSince = null);

        IList<Contact> ListClientContacts(long clientId, DateTime? updatedSince = null);

        Task<IList<Contact>> ListClientContactsAsync(long clientId, DateTime? updatedSince = null);

        Contact Contact(long contactId);

        Task<Contact> ContactAsync(long contactId);

        Contact CreateContact(long clientId, string firstName, string lastName, string title = null, string email = null, string phoneOffice = null, string phoneMobile = null, string fax = null);

        Task<Contact> CreateContactAsync(long clientId, string firstName, string lastName, string title = null, string email = null, string phoneOffice = null, string phoneMobile = null, string fax = null);

        Contact CreateContact(ContactOptions options);

        Task<Contact> CreateContactAsync(ContactOptions options);

        bool DeleteContact(long contactId);

        Task<bool> DeleteContactAsync(long contactId);

        Contact UpdateContact(long contactId, long? clientId = null, string firstName = null, string lastName = null, string title = null, string email = null, string phoneOffice = null, string phoneMobile = null, string fax = null);

        Task<Contact> UpdateContactAsync(long contactId, long? clientId = null, string firstName = null, string lastName = null, string title = null, string email = null, string phoneOffice = null, string phoneMobile = null, string fax = null);

        Contact UpdateContact(long contactId, ContactOptions options);

        Task<Contact> UpdateContactAsync(long contactId, ContactOptions options);
    }
}

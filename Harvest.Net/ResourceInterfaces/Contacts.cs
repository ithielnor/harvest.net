using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient 
    {
        IList<Contact> ListContacts(DateTime? updatedSince = null);

      IList<Contact> ListClientContacts(long clientId, DateTime? updatedSince = null);

       Contact Contact(long contactId);

       Contact CreateContact(long clientId, string firstName, string lastName, string title = null, string email = null, string phoneOffice = null, string phoneMobile = null, string fax = null);

       Contact CreateContact(ContactOptions options);

       bool DeleteContact(long contactId);

       Contact UpdateContact(long contactId, long? clientId = null, string firstName = null, string lastName = null, string title = null, string email = null, string phoneOffice = null, string phoneMobile = null, string fax = null);

       Contact UpdateContact(long contactId, ContactOptions options);
    }
}

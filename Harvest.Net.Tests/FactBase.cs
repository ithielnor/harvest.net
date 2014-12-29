using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Harvest.Net.Tests
{
    public abstract class FactBase
    {
        protected HarvestRestClient Api { get; set; }
        protected string Username { get; private set; }
        protected string Subdomain { get; private set; }

        protected long GetTestId(TestId key)
        {
            return long.Parse(ConfigurationManager.AppSettings["Test_" + key.ToString()]);
        }

        public FactBase()
        {
            Username = ConfigurationManager.AppSettings["auth_username"];
            Subdomain = ConfigurationManager.AppSettings["auth_subdomain"];
            
            string password = ConfigurationManager.AppSettings["auth_password"];

            Api = new HarvestRestClient(Subdomain, Username, password);

            Initialize();
        }

        /// <summary>
        /// Initialize any necessary test items
        /// </summary>
        protected virtual void Initialize() { }

        protected enum TestId
        {
            ClientId,
            ContactId,
            ExpenseCategoryId,
            ExpenseId,
            InvoiceCategoryId,
            InvoiceId,
            PaymentId,
            ProjectId,
            ProjectId2,
            TaskAssignmentId,
            TaskId,
            TaskId2,
            UserAssignmentId,
            UserId,
        }
    }
}

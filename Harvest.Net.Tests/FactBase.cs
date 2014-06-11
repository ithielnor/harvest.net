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

        protected IList<Func<bool>> TearDownEvents { get; set; }

        public FactBase()
        {
            string subdomain = ConfigurationManager.AppSettings["auth_subdomain"];
            string username = ConfigurationManager.AppSettings["auth_username"];
            string password = ConfigurationManager.AppSettings["auth_password"];

            Api = new HarvestRestClient(subdomain, username, password);

            Initialize();
        }

        /// <summary>
        /// Initialize any necessary test items
        /// </summary>
        protected virtual void Initialize() { }
    }
}

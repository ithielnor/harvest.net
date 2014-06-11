using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Harvest.Net.Tests
{
    [TestClass]
    public class InvoiceFacts
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new HarvestRestClient("", "", "");

            var list = client.ListInvoices();

            Assert.IsTrue(list != null);
        }
    }
}

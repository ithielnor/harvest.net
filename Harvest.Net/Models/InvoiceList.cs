using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    public class InvoiceList : ListBase
    {
        /// <summary>
        /// List of invoices returned by the API
        /// </summary>
        public IEnumerable<Invoice> Invoices { get; set; }
    }
}

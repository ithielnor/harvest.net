using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    public enum Currency
    {
        [Description("United States Dollars - USD")]
        USD,
    }

    public enum InvoiceState
    {
        Open,
        Partial,
        Draft,
        Paid,
        Unpaid,
        PastDue,
    }
}

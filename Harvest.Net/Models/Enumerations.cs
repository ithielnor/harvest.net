using RestSharp.Serializers;
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
        Closed,
    }

    public enum InvoiceKind
    {
        Project,
        Task,
        People,
        Detailed,
        FreeForm,
    }

    public enum InvoiceDateAtFormat
    {
        [Description("upon receipt")]
        UponReceipt,
        [Description("net 15")]
        Net15,
        [Description("net 30")]
        Net30,
        [Description("net 45")]
        Net45,
        [Description("net 60")]
        Net60,
        [Description("custom")]
        Custom,
    }

    public enum WeekDay
    {
        Sunday,
        Monday,
        Saturday
    }
}

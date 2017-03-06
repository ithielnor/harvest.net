using System.ComponentModel;

namespace Harvest.Net.Models
{
    public enum Currency
    {
        [Description("United States Dollar - USD")]USD,
        [Description("Euro - EUR")]EUR,
        [Description("British Pound - GBP")]GBP,
        [Description("Canadian Dollar - CAD")]CAD,
        [Description("Australia Dollar - AUD")]AUD,
        [Description("New Zealand Dollar - NZD")]NZD,
        [Description("Swedish krona - SEK")]SEK,
        [Description("Danish Krone - DKK")]DKK,
        [Description("Norwegian Krone - NOK")]NOK,
        [Description("Swiss Franc - CHF")]CHF,
        [Description("South Africa Rand - ZAR")]ZAR,
        [Description("Afghanistan Afghani - AFN")]AFN,
        [Description("Albania Lek - ALL")]ALL,
        [Description("Algeria Dinar - DZD")]DZD,
        [Description("Angolan Kwanza - AOA")]AOA,
        [Description("Argentina Peso - ARS")]ARS,
        [Description("Aruban Florin - AWG")]AWG,
        [Description("Bahamas Dollar - BSD")]BSD,
        [Description("Bahrain Dinar - BHD")]BHD,
        [Description("Bangladesh Taka - BDT")]BDT,
        [Description("Barbados Dollar - BBD")]BBD,
        [Description("Belize Dollar - BZD")]BZD,
        [Description("Bermuda Dollar - BMD")]BMD,
        [Description("Bolivian Boliviano - BOB")]BOB,
        [Description("Botswana Pula - BWP")]BWP,
        [Description("Brazil Real - BRL")]BRL,
        [Description("Brunei Dollar - BND")]BND,
        [Description("Bulgaria Leva - BGN")]BGN,
        [Description("Cayman Islands Dollar - KYD")]KYD,
        [Description("Central African CFA Franc - XAF")]XAF,
        [Description("CFP Franc - XPF")]XPF,
        [Description("Chile Peso - CLP")]CLP,
        [Description("Chile Unidad de Fomento - CLF")]CLF,
        [Description("China Yuan Renminbi - CNY")]CNY,
        [Description("Colombia Peso - COP")]COP,
        [Description("Costa Rica Colon - CRC")]CRC,
        [Description("Croatia Kuna - HRK")]HRK,
        [Description("Cyprus Pound - CYP")]CYP,
        [Description("Czech Republic Koruny - CZK")]CZK,
        [Description("Dominican Republic Peso - DOP")]DOP,
        [Description("Eastern Caribbean Dollar - XCD")]XCD,
        [Description("Egypt Pound - EGP")]EGP,
        [Description("Estonia Krooni - EEK")]EEK,
        [Description("Fiji Dollar - FJD")]FJD,
        [Description("Ghana Cedis - GHS")]GHS,
        [Description("Guatemalan quetzal - GTQ")]GTQ,
        [Description("Hong Kong Dollar - HKD")]HKD,
        [Description("Hungary Forint - HUF")]HUF,
        [Description("Iceland Kronur - ISK")]ISK,
        [Description("Indian Rupee - INR")]INR,
        [Description("Indonesia Rupiah - IDR")]IDR,
        [Description("Iran Rial - IRR")]IRR,
        [Description("Iraq Dinar - IQD")]IQD,
        [Description("Israel New Shekel - ILS")]ILS,
        [Description("Jamaica Dollar - JMD")]JMD,
        [Description("Japan Yen - JPY")]JPY,
        [Description("Jordan Dinar - JOD")]JOD,
        [Description("Kazakhstan Tenge - KZT")]KZT,
        [Description("Kenya Shilling - KES")]KES,
        [Description("Kuwait Dinar - KWD")]KWD,
        [Description("Latvian Lat - LVL")]LVL,
        [Description("Lebanon Pound - LBP")]LBP,
        [Description("Libyan Dinar - LYD")]LYD,
        [Description("Lithuanian Litas - LTL")]LTL,
        [Description("Macanese Pataca - MOP")]MOP,
        [Description("Macdeonian Denar - MKD")]MKD,
        [Description("Malaysia Ringgit - MYR")]MYR,
        [Description("Malta Liri - MTL")]MTL,
        [Description("Mauritius Rupee - MUR")]MUR,
        [Description("Mexico Peso - MXN")]MXN,
        [Description("Morocco Dirham - MAD")]MAD,
        [Description("Mozambican Metical - MZN")]MZN,
        [Description("Namibian Dollar - NAD")]NAD,
        [Description("Nepal Rupee - NPR")]NPR,
        [Description("Netherlands Antillean Guilder - ANG")]ANG,
        [Description("Nigerian Naira - NGN")]NGN,
        [Description("Oman Rial - OMR")]OMR,
        [Description("Pakistan Rupee - PKR")]PKR,
        [Description("Papua New Guinea Kina - PGK")]PGK,
        [Description("Paraguayan Guarani - PYG")]PYG,
        [Description("Peru Nuevos Soles - PEN")]PEN,
        [Description("Philippines Peso - PHP")]PHP,
        [Description("Poland Zlotych - PLN")]PLN,
        [Description("Qatar Riyal - QAR")]QAR,
        [Description("Romania New Lei - RON")]RON,
        [Description("Russia Rubles - RUB")]RUB,
        [Description("Saudi Arabia Riyal - SAR")]SAR,
        [Description("Serbia Dinar - RSD")]RSD,
        [Description("Seychelles Rupee - SCR")]SCR,
        [Description("Singapore Dollar - SGD")]SGD,
        [Description("Slovakia Koruny - SKK")]SKK,
        [Description("South Korea Won - KRW")]KRW,
        [Description("Sri Lanka Rupee - LKR")]LKR,
        [Description("Sudan Pound - SDG")]SDG,
        [Description("Taiwan New Dollar - TWD")]TWD,
        [Description("Tanzanian Shilling - TZS")]TZS,
        [Description("Thailand Baht - THB")]THB,
        [Description("Trinidad and Tobago Dollar - TTD")]TTD,
        [Description("Tunisia Dinar - TND")]TND,
        [Description("Turkey Lira - TRY")]TRY,
        [Description("Ugandan shilling - UGX")]UGX,
        [Description("Ukrainian hryvnia - UAH")]UAH,
        [Description("United Arab Emirates Dirham - AED")]AED,
        [Description("Uruguayan peso - UYU")]UYU,
        [Description("Vanuatu Vatu - VUV")]VUV,
        [Description("Venezuela Bolivares - VEB")]VEB,
        [Description("Venezuela Bolivares Fuertes - VEF")]VEF,
        [Description("Vietnam Dong - VND")]VND,
        [Description("West African CFA Franc - XOF")]XOF,
        [Description("Zambia Kwacha - ZMK")]ZMK,
    }

    /// <summary>
    /// A state attribute which specifies invoices.
    /// </summary>
    public enum InvoiceState
    {
        /// <summary>
        /// Unpaid Invoices.
        /// </summary>
        Open,

        /// <summary>
        /// Partial paid invoice.
        /// </summary>
        Partial,

        /// <summary>
        /// Drafted invoices.
        /// </summary>
        Draft,

        /// <summary>
        /// Paid in full invoices.
        /// </summary>
        Paid,

        /// <summary>
        /// Unpaid invoices.
        /// </summary>
        Unpaid,

        /// <summary>
        /// State which is reached when the invoice is not paid til the due date.
        /// </summary>
        PastDue,

        /// <summary>
        /// State which is reached when the invoice is closed.
        /// </summary>
        Closed,
    }

    /// <summary>
    /// Invoice type.
    /// </summary>
    public enum InvoiceKind
    {
        /// <summary>
        /// Gathers hours & expenses from Harvest grouped by projects.
        /// </summary>
        [Description("project")]
        Project,

        /// <summary>
        /// Gathers hours & expenses from Harvest grouped by task.
        /// </summary>
        [Description("task")]
        Task,

        /// <summary>
        /// Gathers hours & expenses from Harvest grouped by person.
        /// </summary>
        [Description("people")]
        People,

        /// <summary>
        /// Uses a line item for each hour & expense entry, including detailed notes.
        /// </summary>
        [Description("detailed")]
        Detailed,

        /// <summary>
        /// Creates free form invoice. Line items added with csv-line-items
        /// </summary>
        [Description("free-form")]
        FreeForm,
    }

    /// <summary>
    /// Formats which are describing the type of hours to import.
    /// </summary>
    public enum InvoiceImportHours
    {
        /// <summary>
        /// Import all hours
        /// </summary>
        [Description("all")]
        All,

        /// <summary>
        /// Import hours using period start and period end
        /// </summary>
        [Description("yes")]
        Yes,

        /// <summary>
        /// Do not import hours
        /// </summary>
        [Description("no")]
        No
    }

    /// <summary>
    /// Formats which are describing the date the invoice is scheduled.
    /// </summary>
    public enum InvoiceDateAtFormat
    {
        /// <summary>
        /// Time is specified after the time the invoice is dued.
        /// </summary>
        [Description("upon receipt")]
        UponReceipt,

        /// <summary>
        /// 15 days until the invoice is due.
        /// </summary>
        [Description("net 15")]
        Net15,

        /// <summary>
        /// 30 days until the invoice is due.
        /// </summary>
        [Description("net 30")]
        Net30,

        /// <summary>
        /// 45 days until the invoice is due.
        /// </summary>
        [Description("net 45")]
        Net45,

        /// <summary>
        /// 60 days until the invoice is due.
        /// </summary>
        [Description("net 60")]
        Net60,

        /// <summary>
        /// Custom amount of days until the invoice is due.
        /// </summary>
        [Description("custom")]
        Custom,
    }

    /// <summary>
    /// Week day which is used for the starting day of companies.
    /// </summary>
    public enum WeekDay
    {
        /// <summary>
        /// Sunday.
        /// </summary>
        Sunday,

        /// <summary>
        /// Monday.
        /// </summary>
        Monday,

        /// <summary>
        /// Saturday.
        /// </summary>
        Saturday
    }

    /// <summary>
    /// The method by which the project is invoiced.
    /// </summary>
    public enum BillingMethod
    {
        /// <summary>
        /// No method given.
        /// </summary>
        [Description("none")]
        None,

        /// <summary>
        /// Invoiced by people.
        /// </summary>
        People,

        /// <summary>
        /// Invoiced by projects.
        /// </summary>
        Project,

        /// <summary>
        /// Invoiced by tasks.
        /// </summary>
        Tasks
    }

    /// <summary>
    /// The method by which the project is budgeted.
    /// </summary>
    public enum BudgetMethod
    {
        /// <summary>
        /// No budget.
        /// </summary>
        [Description("none")]
        None,

        /// <summary>
        /// Budgeted by hours per person.
        /// </summary>
        [Description("person")]
        Person,

        /// <summary>
        /// Budgeted by hours per project.
        /// </summary>
        [Description("project")]
        Project,

        /// <summary>
        /// Budgeted by total project fees.
        /// </summary>
        [Description("project_cost")]
        ProjectCost,

        /// <summary>
        /// Budgeted by hours per task.
        /// </summary>
        [Description("task")]
        Task,

        /// <summary>
        /// Budgeted by task fees.
        /// </summary>
        [Description("task_fees")]
        TaskFees
    }

    /// <summary>
    /// The method by which the project is estimated.
    /// </summary>
    public enum EstimateMethod
    {
        /// <summary>
        /// Estimated by none.
        /// </summary>
        [Description("none")]
        None,

        /// <summary>
        /// Estimated by hours per person.
        /// </summary>
        [Description("person")]
        Person,

        /// <summary>
        /// Estimated by hours per project.
        /// </summary>
        [Description("project")]
        Project,

        /// <summary>
        /// Estimated by total project fees.
        /// </summary>
        [Description("project_cost")]
        ProjectCost,

        /// <summary>
        /// Estimated by hours per task.
        /// </summary>
        [Description("task")]
        Task,

        /// <summary>
        /// Estimated by task fees.
        /// </summary>
        [Description("task_fees")]
        TaskFees
    }
}

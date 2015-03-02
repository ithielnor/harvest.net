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
        [Description("United States Dollar - USD")]USD,
        [Description("Euro - EUR")]EUR,
        [Description("United Kingdom Pound - GBP")]GBP,
        [Description("Canada Dollar - CAD")]CAD,
        [Description("Australia Dollar - AUD")]AUD,
        [Description("New Zealand Dollar - NZD")]NZD,
        [Description("Swedish krona - SEK")]SEK,
        [Description("Danish Krone - DKK")]DKK,
        [Description("Norway Kroner - NOK")]NOK,
        [Description("Switzerland Franc - CHF")]CHF,
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
        [Description("India Rupee - INR")]INR,
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

    public enum BillingMethod
    {
        [Description("none")]
        None,
        People,
        Project,
        Task
    }

    public enum BudgetMethod
    {
        [Description("none")]
        None,
        Person,
        Project,
        ProjectCost,
        Task
    }

    public enum EstimateMethod
    {
        [Description("none")]
        None,
    }
}

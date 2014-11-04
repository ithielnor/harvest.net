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
        [Description("United States Dollars - USD")]USD,
        [Description("Euro - EUR")]EUR,
        [Description("United Kingdom Pounds - GBP")]GBP,
        [Description("Canada Dollars - CAD")]CAD,
        [Description("Australia Dollars - AUD")]AUD,
        [Description("New Zealand Dollars - NZD")]NZD,
        [Description("Swedish krona - SEK")]SEK,
        [Description("Danish Krone - DKK")]DKK,
        [Description("Norway Kroner - NOK")]NOK,
        [Description("Switzerland Francs - CHF")]CHF,
        [Description("South Africa Rand - ZAR")]ZAR,
        [Description("Afghanistan Afghanis - AFN")]AFN,
        [Description("Albania Lekë - ALL")]ALL,
        [Description("Algeria Dinars - DZD")]DZD,
        [Description("Angolan Kwanza - AOA")]AOA,
        [Description("Argentina Pesos - ARS")]ARS,
        [Description("Aruban Florin - AWG")]AWG,
        [Description("Bahamas Dollars - BSD")]BSD,
        [Description("Bahrain Dinars - BHD")]BHD,
        [Description("Bangladesh Taka - BDT")]BDT,
        [Description("Barbados Dollars - BBD")]BBD,
        [Description("Belize Dollar - BZD")]BZD,
        [Description("Bermuda Dollars - BMD")]BMD,
        [Description("Bolivian Boliviano - BOB")]BOB,
        [Description("Botswana Pula - BWP")]BWP,
        [Description("Brazil Reals - BRL")]BRL,
        [Description("Brunei Dollar - BND")]BND,
        [Description("Bulgaria Leva - BGN")]BGN,
        [Description("Cayman Islands Dollar - KYD")]KYD,
        [Description("Central African CFA Franc - XAF")]XAF,
        [Description("CFP Franc - XPF")]XPF,
        [Description("Chile Pesos - CLP")]CLP,
        [Description("Chile Unidad de Fomento - CLF")]CLF,
        [Description("China Yuan Renminbi - CNY")]CNY,
        [Description("Colombia Pesos - COP")]COP,
        [Description("Costa Rica Colones - CRC")]CRC,
        [Description("Croatia Kuna - HRK")]HRK,
        [Description("Cyprus Pounds - CYP")]CYP,
        [Description("Czech Republic Koruny - CZK")]CZK,
        [Description("Dominican Republic Pesos - DOP")]DOP,
        [Description("Eastern Caribbean Dollars - XCD")]XCD,
        [Description("Egypt Pounds - EGP")]EGP,
        [Description("Estonia Krooni - EEK")]EEK,
        [Description("Fiji Dollars - FJD")]FJD,
        [Description("Ghana Cedis - GHS")]GHS,
        [Description("Guatemalan quetzal - GTQ")]GTQ,
        [Description("Hong Kong Dollars - HKD")]HKD,
        [Description("Hungary Forint - HUF")]HUF,
        [Description("Iceland Kronur - ISK")]ISK,
        [Description("India Rupees - INR")]INR,
        [Description("Indonesia Rupiahs - IDR")]IDR,
        [Description("Iran Rials - IRR")]IRR,
        [Description("Iraq Dinars - IQD")]IQD,
        [Description("Israel New Shekels - ILS")]ILS,
        [Description("Jamaica Dollars - JMD")]JMD,
        [Description("Japan Yen - JPY")]JPY,
        [Description("Jordan Dinars - JOD")]JOD,
        [Description("Kazakhstan Tenge - KZT")]KZT,
        [Description("Kenya Shillings - KES")]KES,
        [Description("Kuwait Dinars - KWD")]KWD,
        [Description("Latvian Lat - LVL")]LVL,
        [Description("Lebanon Pounds - LBP")]LBP,
        [Description("Libyan Dinar - LYD")]LYD,
        [Description("Lithuanian Litas - LTL")]LTL,
        [Description("Macanese Patacas - MOP")]MOP,
        [Description("Macdeonian Denari - MKD")]MKD,
        [Description("Malaysia Ringgits - MYR")]MYR,
        [Description("Malta Liri - MTL")]MTL,
        [Description("Mauritius Rupees - MUR")]MUR,
        [Description("Mexico Pesos - MXN")]MXN,
        [Description("Morocco Dirhams - MAD")]MAD,
        [Description("Mozambican Metical - MZN")]MZN,
        [Description("Namibian Dollars - NAD")]NAD,
        [Description("Nepal Rupees - NPR")]NPR,
        [Description("Netherlands Antillean Guilder - ANG")]ANG,
        [Description("Nigerian Naira - NGN")]NGN,
        [Description("Oman Rials - OMR")]OMR,
        [Description("Pakistan Rupees - PKR")]PKR,
        [Description("Papua New Guinea Kina - PGK")]PGK,
        [Description("Paraguayan Guarani - PYG")]PYG,
        [Description("Peru Nuevos Soles - PEN")]PEN,
        [Description("Philippines Pesos - PHP")]PHP,
        [Description("Poland Zlotych - PLN")]PLN,
        [Description("Qatar Riyals - QAR")]QAR,
        [Description("Romania New Lei - RON")]RON,
        [Description("Russia Rubles - RUB")]RUB,
        [Description("Saudi Arabia Riyals - SAR")]SAR,
        [Description("Serbia Dinar - RSD")]RSD,
        [Description("Seychelles Rupees - SCR")]SCR,
        [Description("Singapore Dollars - SGD")]SGD,
        [Description("Slovakia Koruny - SKK")]SKK,
        [Description("South Korea Won - KRW")]KRW,
        [Description("Sri Lanka Rupees - LKR")]LKR,
        [Description("Sudan Pounds - SDG")]SDG,
        [Description("Taiwan New Dollars - TWD")]TWD,
        [Description("Tanzanian Shillings - TZS")]TZS,
        [Description("Thailand Baht - THB")]THB,
        [Description("Trinidad and Tobago Dollars - TTD")]TTD,
        [Description("Tunisia Dinars - TND")]TND,
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
}

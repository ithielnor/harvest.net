namespace Harvest.Net.Models
{
    /// <summary>
    /// Item of an invoice.
    /// </summary>
    public class InvoiceItem
    {
        /// <summary>
        /// Kind of the invoice item.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Text which describes the invoice item more specificially.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Quantity of the item.
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Price of one Unit.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Amounts of the invoice item in the invoice.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Bool which describes if the first tax is billed.
        /// </summary>
        public bool Taxed { get; set; }

        /// <summary>
        /// Bool which describes if the second tax is billed.
        /// </summary>
        public bool Taxed2 { get; set; }

        /// <summary>
        /// Identifier for the project.
        /// </summary>
        public long? ProjectId { get; set; }

        /// <summary>
        /// Method to convert the object to a string by comma seperation.
        /// </summary>
        /// <returns>The invoice item as comma seperated string.</returns>
        public override string ToString()
        {
            var items = new string[]
            {
                "\"" + Kind + "\"",
                "\"" + Description + "\"", 
                Quantity.ToString(),
                UnitPrice.ToString(),
                Amount.ToString(),
                Taxed.ToString().ToLower(),
                Taxed2.ToString().ToLower(),
                string.Empty + ProjectId
            };
            return string.Join(",", items);
        }

        /// <summary>
        /// Method to get the default headers of the invoice item.
        /// </summary>
        /// <returns>The string describing the default headers.</returns>
        public static string GetHeaders()
        {
            return "kind,description,quantity,unit_price,amount,taxed,taxed2,project_id";
        }
    }
}

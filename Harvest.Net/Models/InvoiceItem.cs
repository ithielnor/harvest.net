namespace Harvest.Net.Models
{
    public class InvoiceItem
    {
        public string Kind { get; set; }

        public string Description { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

        public bool Taxed { get; set; }

        public bool Taxed2 { get; set; }

        public long? ProjectId { get; set; }

        public override string ToString()
        {
            var items = new string[]
            {
                Kind,
                Description,
                Quantity.ToString(),
                UnitPrice.ToString(),
                Amount.ToString(),
                Taxed.ToString().ToLower(),
                Taxed2.ToString().ToLower(),
                string.Empty + ProjectId
            };
            return string.Join(",", items);
        }

        public static string GetHeaders()
        {
            return "kind,description,quantity,unit_price,amount,taxed,taxed2,project_id";
        }
    }
}

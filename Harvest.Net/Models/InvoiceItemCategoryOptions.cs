using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for creating and updating invoice item categories.
    /// </summary>
    [SerializeAs(Name = "invoice-item-category")]
    public class InvoiceItemCategoryOptions
    {
        /// <summary>
        /// Name of the invoice item category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value which describes if the invoice category is used as expense.
        /// </summary>
        public bool? UseAsExpense { get; set; }

        /// <summary>
        /// Value which describes if the invoice category is used as service.
        /// </summary>
        public bool? UseAsService { get; set; }
    }
}

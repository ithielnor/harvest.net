using RestSharp.Serializers;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model for creating and updating expense categories.
    /// </summary>
    [SerializeAs(Name = "expense-category")]
    public class ExpenseCategoryOptions
    {
        /// <summary>
        /// Name of the category.
        /// Example:
        /// <example>
        /// New Category
        /// </example>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the unit.
        /// Example:
        /// <example>
        /// Bananas
        /// </example>
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Price per Unit.
        /// Example:
        /// <example>
        /// 12.51
        /// </example>
        /// </summary>
        public decimal? UnitPrice { get; set; }
    }
}

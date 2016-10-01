using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// MOdel for expense categories used in the harvest API.
    /// </summary>
    [SerializeAs(Name = "expense-category")]
    public class ExpenseCategory : IModel
    {
        /// <summary>
        /// Identifier of the expense category.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Time when the expense category was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Time when the expense category was updated last.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Name of the expense category.
        /// Example:
        /// <example>
        /// Entertainment
        /// </example>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the unit.
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Price per Unit.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Value which describes if the expense is deactivated.
        /// </summary>
        public bool Deactivated { get; set; }
    }
}

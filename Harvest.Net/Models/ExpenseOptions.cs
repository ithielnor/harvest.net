using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model which is used for creating and updating Expenses in the harvest API.
    /// </summary>
    [SerializeAs(Name = "expense")]
    public class ExpenseOptions
    {
        /// <summary>
        /// Value for the expense entry.
        /// </summary>
        public decimal? TotalCost { get; set; }

        /// <summary>
        /// Value for use with an expense calculated by unit price.
        /// Example:
        /// <example>
        /// Mileage
        /// </example>
        /// </summary>
        public decimal? Units { get; set; }

        /// <summary>
        /// Valid and existing project ID.
        /// </summary>
        public long? ProjectId { get; set; }

        /// <summary>
        /// Valid and existing expense category ID.
        /// </summary>
        public long? ExpenseCategoryId { get; set; }

        /// <summary>
        /// Date for expense entry.
        /// </summary>
        public DateTime? SpentAt { get; set; }

        /// <summary>
        /// Expense entry notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Value which describes if the expense is billable.
        /// </summary>
        public bool? Billable { get; set; }
    }
}

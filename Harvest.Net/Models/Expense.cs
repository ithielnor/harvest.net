using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Expenses in the harves API.
    /// </summary>
    [SerializeAs(Name = "expense")]
    public class Expense : IModel
    {
        /// <summary>
        /// Identifier of the Expense.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Time when the expense is updated last.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Time when the expense was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Value for the expense entry.
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Value for use with an expense calculated by unit price.
        /// Example:
        /// <example>
        /// Mileage
        /// </example>
        /// </summary>
        public decimal Units { get; set; }

        /// <summary>
        /// Valid and existing project ID.
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// Valid and existing expense category ID.
        /// </summary>
        public long ExpenseCategoryId { get; set; }
        
        /// <summary>
        /// Id of the user.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Date for expense entry.
        /// </summary>
        public DateTime SpentAt { get; set; }

        /// <summary>
        /// Value which describes if the expense is already closed.
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Expense entry notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Invoice referenced by the expense.
        /// </summary>
        public long InvoiceId { get; set; }

        /// <summary>
        /// Company referenced to the expense.
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// Value which describes if the expense is billable.
        /// </summary>
        public bool Billable { get; set; }

        /// <summary>
        /// Value which describes if the expense has a receipt.
        /// </summary>
        public bool HasReceipt { get; set; }

        /// <summary>
        /// Url to the receipt of the expense.
        /// </summary>
        public string ReceiptUrl { get; set; }

        /// <summary>
        /// Value which describes if the expense is locked.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// If <see cref="IsLocked"/> is true this is the reason for it.
        /// </summary>
        public string LockedReason { get; set; }
    }
}

using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model to show invoice item categories of the harvest API.
    /// </summary>
    [SerializeAs(Name = "invoice-item-category")]
    public class InvoiceItemCategory : IModel
    {
        /// <summary>
        /// Identifier of the invoice item category.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name of the invoice item category.
        /// Examples:
        /// <example>
        /// Service
        /// </example>,
        /// <example>
        /// Product
        /// </example>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Time when the invoice item category was updated last.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Time when the invoice item category was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Value which describes if the invoice category is used as expense.
        /// </summary>
        public bool UseAsExpense { get; set; }

        /// <summary>
        /// Value which describes if the invoice category is used as service.
        /// </summary>
        public bool UseAsService { get; set; }
    }
}

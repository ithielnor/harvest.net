using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Standard interface for models used in the harvest API.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Identifier of the model.
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// Time when the model is updated last.
        /// </summary>
        DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Time when the model was created.
        /// </summary>
        DateTime CreatedAt { get; set; }
    }
}

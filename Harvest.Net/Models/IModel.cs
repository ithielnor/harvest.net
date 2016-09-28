using System;

namespace Harvest.Net.Models
{
    public interface IModel
    {
        long Id { get; set; }

        DateTime UpdatedAt { get; set; }

        DateTime CreatedAt { get; set; }
    }
}

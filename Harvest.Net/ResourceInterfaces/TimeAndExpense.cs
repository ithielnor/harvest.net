using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        IList<DayEntry> ListUserEntries(long userId, DateTime beginTime, DateTime endTime, long? projectId = null, bool? isBillable = null, bool? isBilled = null, bool? isClosed = null, DateTime? updatedSince = null);

        Task<IList<DayEntry>> ListUserEntriesAsync(long userId, DateTime beginTime, DateTime endTime, long? projectId = null, bool? isBillable = null, bool? isBilled = null, bool? isClosed = null, DateTime? updatedSince = null);

        IList<DayEntry> ListProjectEntries(long projectId, DateTime beginTime, DateTime endTime, long? userId = null, bool? isBillable = null, bool? isBilled = null, bool? isClosed = null, DateTime? updatedSince = null);

        Task<IList<DayEntry>> ListProjectEntriesAsync(long projectId, DateTime beginTime, DateTime endTime, long? userId = null, bool? isBillable = null, bool? isBilled = null, bool? isClosed = null, DateTime? updatedSince = null);

        IList<Expense> ListUserExpenses(long userId, DateTime beginTime, DateTime endTime, bool? isClosed = null, DateTime? updatedSince = null);

        Task<IList<Expense>> ListUserExpensesAsync(long userId, DateTime beginTime, DateTime endTime, bool? isClosed = null, DateTime? updatedSince = null);

        IList<Expense> ListProjectExpenses(long projectId, DateTime beginTime, DateTime endTime, bool? isClosed = null, bool? isBilled = null, DateTime? updatedSince = null);

        Task<IList<Expense>> ListProjectExpensesAsync(long projectId, DateTime beginTime, DateTime endTime, bool? isClosed = null, bool? isBilled = null, DateTime? updatedSince = null);
    }
}

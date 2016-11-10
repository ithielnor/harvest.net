using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        IList<DayEntry> ListUserEntries(long userId, DateTime beginTime, DateTime endTime, long? projectId = null, bool? isBillable = null, bool? isBilled = null, bool? isClosed = null, DateTime? updatedSince = null);

        IList<DayEntry> ListProjectEntries(long projectId, DateTime beginTime, DateTime endTime, long? userId = null, bool? isBillable = null, bool? isBilled = null, bool? isClosed = null, DateTime? updatedSince = null);

        IList<Expense> ListUserExpenses(long userId, DateTime beginTime, DateTime endTime, bool? isClosed = null, DateTime? updatedSince = null);
        
        IList<Expense> ListProjectExpenses(long projectId, DateTime beginTime, DateTime endTime, bool? isClosed = null, bool? isBilled = null, DateTime? updatedSince = null);
    }
}

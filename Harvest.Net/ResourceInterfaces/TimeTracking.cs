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
        Daily Daily(short? dayOfTheYear = null, short? year = null, long? ofUser = null);

        Timer Daily(long dayEntryId, long? ofUser = null);
        
        Timer ToggleDaily(long dayEntryId, long? ofUser = null);

        Timer CreateDaily(DateTime spentAt, long projectId, long taskId, decimal hours, string notes = null, long? ofUser = null);

        Timer CreateDaily(DateTime spentAt, long projectId, long taskId, TimeSpan startedAt, TimeSpan endedAt, string notes = null, long? ofUser = null);

        Timer StartTimer(DateTime spentAt, long projectId, long taskId, string notes = null, long? ofUser = null);
        
        bool DeleteDaily(long dayEntryId, long? ofUser = null);

        Timer UpdateDaily(long dayEntryId, DateTime? spentAt = null, long? projectId = null, long? taskId = null, decimal? hours = null, TimeSpan? startedAt = null, TimeSpan? endedAt = null, string notes = null, long? ofUser = null);
    }
}

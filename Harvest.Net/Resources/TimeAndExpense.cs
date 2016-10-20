using Harvest.Net;
using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        // All reporting API endpoints are only available to administrator users.
        // https://github.com/harvesthq/api/blob/master/Sections/Time%20and%20Expense%20Reporting.md

        /// <summary>
        /// List all time entries logged by a user for a given timeframe with optional filters. Makes a GET request to the People/Entries resource.
        /// </summary>
        /// <param name="userId">The userId</param>
        /// <param name="beginTime">The start of the timeframe</param>
        /// <param name="endTime">The end of the timeframe</param>
        /// <param name="projectId">Optional. Gets all project entries for the given timeframe for the user</param>
        /// <param name="isBillable">Optional. If the returned day entries are billable</param>
        /// <param name="isBilled">Optional. If the returned day entries are billed</param>
        /// <param name="isClosed">Optional. If the returned day entries are closed</param>
        public IList<DayEntry> ListUserEntries(long userId, DateTime beginTime, DateTime endTime, long? projectId = null, bool? isBillable = null, bool? isBilled = null, bool? isClosed = null, DateTime? updatedSince = null)
        {
            var request = Request("people/" + userId + "/entries");

            request.AddParameter("from", beginTime.ToString("yyyyMMdd"));

            request.AddParameter("to", endTime.ToString("yyyyMMdd"));

            if (projectId != null)
                request.AddParameter("project_id", projectId.ToString());

            if (isBillable != null)
                request.AddParameter("billable", isBillable.Value.ToYesNo());

            if (isBilled != null)
            {
                if (isBilled == true)
                    request.AddParameter("only_billed", "yes");
                else
                    request.AddParameter("only_unbilled", "yes");
            }

            if (isClosed != null)
                request.AddParameter("is_closed", isClosed.Value.ToYesNo());

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return Execute<List<DayEntry>>(request);
        }

        /// <summary>
        /// Get all time entries logged to a project for a given timeframe with optional filters. Makes a GET request to the Projects/Entries resource.
        /// </summary>
        /// <param name="projectId">The projectId</param>
        /// <param name="beginTime">The start of the timeframe</param>
        /// <param name="endTime">The end of the timeframe</param>
        /// <param name="userId">The optional userId, can be used on your own entries only</param>
        /// <param name="isBillable">Optional. If the returned day entries are billable</param>
        /// <param name="isBilled">Optional. If the returned day entries are billed</param>
        /// <param name="isClosed">Optional. If the returned day entries are closed</param>
        public IList<DayEntry> ListProjectEntries(long projectId, DateTime beginTime, DateTime endTime, long? userId = null, bool? isBillable = null, bool? isBilled = null, bool? isClosed = null, DateTime? updatedSince = null)
        {
            var request = Request("projects/" + projectId + "/entries");

            request.AddParameter("from", beginTime.ToString("yyyyMMdd"));

            request.AddParameter("to", endTime.ToString("yyyyMMdd"));

            if (userId != null)
                request.AddParameter("user_id", userId.ToString());

            if (isBillable != null)
                request.AddParameter("billable", isBillable.Value.ToYesNo());

            if (isBilled != null)
            {
                if (isBilled == true)
                    request.AddParameter("only_billed", "yes");
                else
                    request.AddParameter("only_unbilled", "yes");
            }

            if (isClosed != null)
                request.AddParameter("is_closed", isClosed.Value.ToYesNo());

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return Execute<List<DayEntry>>(request);
        }

        /// <summary>
        /// List all expenses logged by a user for a given timeframe with optional filters. Makes a GET request to the People/Expenses resource.
        /// </summary>
        /// <param name="userId">The userId</param>
        /// <param name="beginTime">The start of the timeframe</param>
        /// <param name="endTime">The end of the timeframe</param>
        /// <param name="isClosed">Optional. If the returned expenses are closed</param>
        /// <param name="updatedSince">Optional. Returns expenses update since</param>
        public IList<Expense> ListUserExpenses(long userId, DateTime beginTime, DateTime endTime, bool? isClosed = null, DateTime? updatedSince = null)
        {
            var request = Request("people/" + userId + "/expenses");

            request.AddParameter("from", beginTime.ToString("yyyyMMdd"));

            request.AddParameter("to", endTime.ToString("yyyyMMdd"));

            if (isClosed != null)
                request.AddParameter("is_closed", isClosed.Value.ToYesNo());

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return Execute<List<Expense>>(request);
        }

        /// <summary>
        /// List all expense entries logged to a project for a given timeframe with optional filters. Makes a GET request to the Projects/Expenses resource.
        /// </summary>
        /// <param name="projectId">The projectId</param>
        /// <param name="beginTime">The start of the timeframe</param>
        /// <param name="endTime">The end of the timeframe</param>
        /// <param name="isClosed">Optional. If the returned expenses are closed</param>
        /// <param name="isBilled">Optional. If the returned expenses are billed</param>
        /// <param name="updatedSince">Optional. Returns expenses update since</param>
        public IList<Expense> ListProjectExpenses(long projectId, DateTime beginTime, DateTime endTime, bool? isClosed = null, bool? isBilled = null, DateTime? updatedSince = null)
        {
            var request = Request("projects/" + projectId + "/expenses");

            request.AddParameter("from", beginTime.ToString("yyyyMMdd"));

            request.AddParameter("to", endTime.ToString("yyyyMMdd"));

            if (isClosed != null)
                request.AddParameter("is_closed", isClosed.Value.ToYesNo());

            if (isBilled != null)
            {
                if (isBilled == true)
                    request.AddParameter("only_billed", "yes");
                else
                    request.AddParameter("only_unbilled", "yes");
            }

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return Execute<List<Expense>>(request);
        }
    }
}

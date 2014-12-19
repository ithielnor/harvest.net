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
        /// List time for all projects for the authenticated account by user for a given timeframe. Makes a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The userId</param>
        /// <param name="beginTime">The start of the timeframe</param>
        /// <param name="endTime">The end of the timeframe</param>
        /// <param name="projectId">The optional projectId, gets all project entries for the given timeframe</param>
        public IList<DayEntry> ListUserTime(long userId, DateTime? beginTime, DateTime? endTime, int? projectId = null)
        {
            var request = Request("people/" + userId + "/entries");
            
            request.AddParameter("from", beginTime.Value.ToString("yyyyMMdd"));
            
            request.AddParameter("to", endTime.Value.ToString("yyyyMMdd"));

            if (projectId != null)
                request.AddParameter("project_id", projectId.ToString());

            return Execute<List<DayEntry>>(request);
        }

        /// <summary>
        /// List time for all projects for the authenticated account by user for a given timeframe with optional filters. Makes a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The userId</param>
        /// <param name="beginTime">The start of the timeframe</param>
        /// <param name="endTime">The end of the timeframe</param>
        /// <param name="projectId">Optional. Gets all project entries for the given timeframe for the user</param>
        /// <param name="billable">Optional. If the returned day entries are billable</param>
        /// <param name="isBilled">Optional. If the returned day entries are billed</param>
        /// <param name="isBilled">Optional. If the returned day entries are closed</param>
        public IList<DayEntry> ListUserTime(long userId, DateTime? beginTime, DateTime? endTime, int? projectId = null, bool? billable = null, bool? isBilled = null, bool? closed = null, DateTime? updatedSince = null)
        {
            var request = Request("people/" + userId + "/entries");

            request.AddParameter("from", beginTime.Value.ToString("yyyyMMdd"));

            request.AddParameter("to", endTime.Value.ToString("yyyyMMdd"));

            if (projectId != null)
                request.AddParameter("project_id", projectId.ToString());

            if (billable != null) {
                if (billable == true)
                    request.AddParameter("billable", "yes");
                else
                    request.AddParameter("billable", "no");
            }

            if (isBilled != null) {
                if (isBilled == true)
                    request.AddParameter("only_billed", "yes");
                else
                    request.AddParameter("only_unbilled", "yes");
            }

            if (closed != null) {
                if (closed == true)
                    request.AddParameter("is_closed", "yes");
                else
                    request.AddParameter("is_closed", "no");
            }

            if (updatedSince != null) {
                string date = updatedSince.HasValue ? updatedSince.Value.ToString("yyyy'-'MM'-'dd'+'HH'%3A'mm") : string.Empty;
                request.AddParameter("updated_since", date);
            }

            return Execute<List<DayEntry>>(request);
        }

        /// <summary>
        /// Get all time entries logged to a project for a given timeframe. Makes a GET request to the Projects resource. 
        /// </summary>
        /// <param name="projectId">The projectId</param>
        /// <param name="beginTime">The start of the timeframe</param>
        /// <param name="endTime">The end of the timeframe</param>
        /// <param name="userId">The optional userId, can be used on your own entries only</param>
        public IList<DayEntry> ListProjectTime(long projectId, DateTime? beginTime, DateTime? endTime, int? userId = null)
        {
            var request = Request("projects/" + projectId + "/entries");

            request.AddParameter("from", beginTime.Value.ToString("yyyyMMdd"));

            request.AddParameter("to", endTime.Value.ToString("yyyyMMdd"));

            if (userId != null)
                request.AddParameter("user_id", userId.ToString());

            return Execute<List<DayEntry>>(request);
        }

        /// <summary>
        /// Get all time entries logged to a project for a given timeframe with optional filters. Makes a GET request to the Projects resource. 
        /// </summary>
        /// <param name="projectId">The projectId</param>
        /// <param name="beginTime">The start of the timeframe</param>
        /// <param name="endTime">The end of the timeframe</param>
        /// <param name="userId">The optional userId, can be used on your own entries only</param>
        /// <param name="billable">Optional. If the returned day entries are billable</param>
        /// <param name="isBilled">Optional. If the returned day entries are billed</param>
        /// <param name="closed">Optional. If the returned day entries are closed</param>
        /// <param name="closed">Optional. Returns entries update since</param>
        public IList<DayEntry> ListProjectTime(long projectId, DateTime? beginTime, DateTime? endTime, int? userId = null, bool? billable = null, bool? isBilled = null, bool? closed = null, DateTime? updatedSince = null)
        {
            var request = Request("projects/" + projectId + "/entries");

            request.AddParameter("from", beginTime.Value.ToString("yyyyMMdd"));

            request.AddParameter("to", endTime.Value.ToString("yyyyMMdd"));

            if (userId != null)
                request.AddParameter("user_id", userId.ToString());

            if (billable != null) {
                if (billable == true)
                    request.AddParameter("billable", "yes");
                else
                    request.AddParameter("billable", "no"); 
            }

            if (isBilled != null) {
                if (isBilled == true)
                    request.AddParameter("only_billed", "yes");
                else
                    request.AddParameter("only_unbilled", "yes");
            }

            if (closed != null) {
                if (closed == true)
                    request.AddParameter("is_closed", "yes");
                else
                    request.AddParameter("is_closed", "no");
            }

            if (updatedSince != null) {
                string date = updatedSince.HasValue ? updatedSince.Value.ToString("yyyy'-'MM'-'dd'+'HH'%3A'mm") : string.Empty;
                request.AddParameter("updated_since", date);
            }

            return Execute<List<DayEntry>>(request);
        }

        /// <summary>
        /// List expenses for all projects for the authenticated account for a given timeframe. Makes a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The userId</param>
        /// <param name="beginTime">The start of the timeframe</param>
        /// <param name="endTime">The end of the timeframe</param>
        /// <param name="projectId">Optional. Gets all project expense entries by the user for the given timeframe</param>
        public IList<Expense> ListUserExpenses(long userId, DateTime? beginTime, DateTime? endTime, int? projectId = null)
        {
            var request = Request("people/" + userId + "/expenses");

            request.AddParameter("from", beginTime.Value.ToString("yyyyMMdd"));

            request.AddParameter("to", endTime.Value.ToString("yyyyMMdd"));

            if (projectId != null)
                request.AddParameter("project_id", projectId.ToString());

            return Execute<List<Expense>>(request);
        }

        /// <summary>
        /// List expenses for all projects for the authenticated account for a given timeframe with optional filters. Makes a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The userId</param>
        /// <param name="beginTime">The start of the timeframe</param>
        /// <param name="endTime">The end of the timeframe</param>
        /// <param name="projectId">Optional. Gets all project expense entries for the given timeframe</param>
        /// <param name="isApproved">Optional. Filters expenses for either approved or not approved for all expense entries for the given timeframe</param>
        /// <param name="updatedSince">Optional. Returns expenses update since</param>
        public IList<Expense> ListUserExpenses(long userId, DateTime? beginTime, DateTime? endTime, int? projectId = null, bool? isApproved = null, DateTime? updatedSince = null)
        {
            var request = Request("people/" + userId + "/expenses");

            request.AddParameter("from", beginTime.Value.ToString("yyyyMMdd"));

            request.AddParameter("to", endTime.Value.ToString("yyyyMMdd"));

            if (projectId != null)
                request.AddParameter("project_id", projectId.ToString());

            if (isApproved != null) {
                if (isApproved == true)
                    request.AddParameter("is_closed", "yes");
                else
                    request.AddParameter("is_closed", "no");
            }

            if (updatedSince != null) {
                string date = updatedSince.HasValue ? updatedSince.Value.ToString("yyyy'-'MM'-'dd'+'HH'%3A'mm") : string.Empty;
                request.AddParameter("updated_since", date);
            }

            return Execute<List<Expense>>(request);
        }

        /// <summary>
        /// List expense entries logged to a project for a given timeframe by a user. Makes a GET request to the Projects resource. 
        /// </summary>
        /// <param name="projectId">The projectId</param>
        /// <param name="beginTime">The start of the timeframe</param>
        /// <param name="endTime">The end of the timeframe</param>
        /// <param name="userId">Optional. Returns expenses from user</param>
        public IList<Expense> ListProjectExpenses(long projectId, DateTime? beginTime, DateTime? endTime, int? userId = null)
        {
            var request = Request("projects/" + projectId + "/expenses");

            request.AddParameter("from", beginTime.Value.ToString("yyyyMMdd"));

            request.AddParameter("to", endTime.Value.ToString("yyyyMMdd"));

            if (userId != null)
                request.AddParameter("user_id", userId.ToString());

            return Execute<List<Expense>>(request);
        }

        /// <summary>
        /// List expense entries logged to a project for a given timeframe by a user with optional filters. Makes a GET request to the Projects resource. 
        /// </summary>
        /// <param name="projectId">The projectId</param>
        /// <param name="beginTime">The start of the timeframe</param>
        /// <param name="endTime">The end of the timeframe</param>
        /// <param name="userId">Optional. Returns expenses from user</param>
        /// <param name="isApproved">Optional. Filters expenses for either approved or not approved for project expense entries for the given timeframe</param>
        /// <param name="isBilled">Optional. If the returned expenses are billed</param>
        /// <param name="updatedSince">Optional. Returns expenses update since</param>
        public IList<Expense> ListProjectExpenses(long projectId, DateTime? beginTime, DateTime? endTime, int? userId = null, bool? isApproved = null, bool? isBilled = null, DateTime? updatedSince = null)
        {
            var request = Request("projects/" + projectId + "/expenses");

            request.AddParameter("from", beginTime.Value.ToString("yyyyMMdd"));

            request.AddParameter("to", endTime.Value.ToString("yyyyMMdd"));

            if (userId != null)
                request.AddParameter("user_id", userId.ToString());

            if (isApproved != null) {
                if (isApproved == true)
                    request.AddParameter("is_closed", "yes");
                else
                    request.AddParameter("is_closed", "no");
            }

            if (isBilled != null) {
                if (isBilled == true)
                    request.AddParameter("only_billed", "yes");
                else
                    request.AddParameter("only_unbilled", "yes");
            }

            if (updatedSince != null) {
                string date = updatedSince.HasValue ? updatedSince.Value.ToString("yyyy'-'MM'-'dd'+'HH'%3A'mm") : string.Empty;
                request.AddParameter("updated_since", date);
            }

            return Execute<List<Expense>>(request);
        }



    }
}

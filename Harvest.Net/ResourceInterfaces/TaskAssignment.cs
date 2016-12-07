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
        IList<TaskAssignment> ListTaskAssignments(long projectId, DateTime? updatedSince = null);

        TaskAssignment TaskAssignment(long projectId, long taskAssignmentId);

        TaskAssignment CreateTaskAssignment(long projectId, long taskId);

        TaskAssignment CreateNewTaskAndAssign(long projectId, string name);

        bool DeleteTaskAssignment(long projectId, long taskAssignmentId);

        TaskAssignment UpdateTaskAssignment(long projectId, long taskAssignmentId, bool? billable = null, bool? deactivated = null, decimal? hourlyRate = null, decimal? budget = null);

        TaskAssignment UpdateTaskAssignment(long projectId, long taskAssignmentId, TaskAssignmentOptions options);
    }
}

using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        IList<TaskAssignment> ListTaskAssignments(long projectId, DateTime? updatedSince = null);

        Task<IList<TaskAssignment>> ListTaskAssignmentsAsync(long projectId, DateTime? updatedSince = null);

        TaskAssignment TaskAssignment(long projectId, long taskAssignmentId);

        Task<TaskAssignment> TaskAssignmentAsync(long projectId, long taskAssignmentId);

        TaskAssignment CreateTaskAssignment(long projectId, long taskId);

        Task<TaskAssignment> CreateTaskAssignmentAsync(long projectId, long taskId);

        TaskAssignment CreateNewTaskAndAssign(long projectId, string name);

        Task<TaskAssignment> CreateNewTaskAndAssignAsync(long projectId, string name);

        bool DeleteTaskAssignment(long projectId, long taskAssignmentId);

        Task<bool> DeleteTaskAssignmentAsync(long projectId, long taskAssignmentId);

        TaskAssignment UpdateTaskAssignment(long projectId, long taskAssignmentId, bool? billable = null, bool? deactivated = null, decimal? hourlyRate = null, decimal? budget = null);

        Task<TaskAssignment> UpdateTaskAssignmentAsync(long projectId, long taskAssignmentId, bool? billable = null, bool? deactivated = null, decimal? hourlyRate = null, decimal? budget = null);

        TaskAssignment UpdateTaskAssignment(long projectId, long taskAssignmentId, TaskAssignmentOptions options);

        Task<TaskAssignment> UpdateTaskAssignmentAsync(long projectId, long taskAssignmentId, TaskAssignmentOptions options);
    }
}

using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        // https://github.com/harvesthq/api/blob/master/Sections/Task%20Assignment.md

        /// <summary>
        /// List all task assignments on a project. Makes a GET request to the Projects/Task_Assignments resource.
        /// </summary>
        /// <param name="projectId">The Id of the project for which to retrieve assignemnts</param>
        /// <param name="updatedSince">An optional filter on the updated-at property</param>
        public IList<TaskAssignment> ListTaskAssignments(long projectId, DateTime? updatedSince = null)
        {
            var request = Request("projects/" + projectId + "/task_assignments");

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return Execute<List<TaskAssignment>>(request);
        }

        /// <summary>
        /// Retrieve a task assignment on a project. Makes a GET request to the Projects/Task_Assignments resource.
        /// </summary>
        /// <param name="projectId">The Id of the project for which to retrieve an assignemnt</param>
        /// <param name="taskAssignmentId">The Id of the assignment to retrieve</param>
        public TaskAssignment TaskAssignment(long projectId, long taskAssignmentId)
        {
            var request = Request("projects/" + projectId + "/task_assignments/" + taskAssignmentId);

            return Execute<TaskAssignment>(request);
        }

        /// <summary>
        /// Assign a task to a project. Makes both a POST and a GET request to the Projects/Task_Assignments resource.
        /// </summary>
        /// <param name="projectId">The Id of the project to which to add the task</param>
        /// <param name="taskId">The Id of the task to add</param>
        public TaskAssignment CreateTaskAssignment(long projectId, long taskId)
        {
            var request = Request("projects/" + projectId + "/task_assignments", RestSharp.Method.POST);

            request.AddBody(new TaskAssignmentCreateOptions()
            {
                Id = taskId
            });

            return Execute<TaskAssignment>(request);
        }

        /// <summary>
        /// Create a new task and assign it to a project. Makes a POST request to the Projects/Task_Assignments/Add_With_Create_New_Task resource, and a GET request to the Projects/Task_Assignments resource.
        /// </summary>
        /// <param name="projectId">The ID of th project to which to add the new task</param>
        /// <param name="name">The name of the new task</param>
        public TaskAssignment CreateNewTaskAndAssign(long projectId, string name)
        {
            var request = Request("projects/" + projectId + "/task_assignments/add_with_create_new_task", RestSharp.Method.POST);

            request.AddBody(new TaskOptions()
            {
                Name = name
            });

            return Execute<TaskAssignment>(request);
        }

        /// <summary>
        /// Remove a task from a project. Makes a DELETE request to the Projects/Task_Assignments resource.
        /// </summary>
        /// <param name="projectId">The Id of the project from which to remove the task</param>
        /// <param name="taskAssignmentId">The Id of the task assignment to remove</param>
        public bool DeleteTaskAssignment(long projectId, long taskAssignmentId)
        {
            var request = Request("projects/" + projectId + "/task_assignments/" + taskAssignmentId, RestSharp.Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Update a task assignment on a project. Makes a PUT and a GET request to the Projects/Task_Assignments resource.
        /// </summary>
        /// <param name="projectId">The ID of the project to update</param>
        /// <param name="taskAssignmentId">The ID of the task assignment to update</param>
        /// <param name="billable">Whether the task assignment is billable</param>
        /// <param name="deactivated">Whether the task assignment is inactive</param>
        /// <param name="hourlyRate">The hourly rate</param>
        /// <param name="budget">The budget</param>
        public TaskAssignment UpdateTaskAssignment(long projectId, long taskAssignmentId, bool? billable = null, bool? deactivated = null, decimal? hourlyRate = null, decimal? budget = null)
        {
            var options = new TaskAssignmentOptions()
            {
                Billable = billable,
                Deactivated = deactivated,
                HourlyRate = hourlyRate,
                Budget = budget,
            };

            return UpdateTaskAssignment(projectId, taskAssignmentId, options);
        }

        /// <summary>
        /// Update a task assignment on a project. Makes a PUT and a GET request to the Projects/Task_Assignments resource.
        /// </summary>
        /// <param name="projectId">The ID of the project to update</param>
        /// <param name="taskAssignmentId">The ID of the task assignment to update</param>
        /// <param name="options">The options to be updated</param>
        public TaskAssignment UpdateTaskAssignment(long projectId, long taskAssignmentId, TaskAssignmentOptions options)
        {
            var request = Request("projects/" + projectId + "/task_assignments/" + taskAssignmentId, RestSharp.Method.PUT);

            request.AddBody(options);

            return Execute<TaskAssignment>(request);
        }
    }
}

using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        // https://github.com/harvesthq/api/blob/master/Sections/Tasks.md

        /// <summary>
        /// List all tasks for the authenticated account. Makes a GET request to the Tasks resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the task updated-at property</param>
        public IList<Models.Task> ListTasks(DateTime? updatedSince = null)
        {
            var request = ListTasksRequest(updatedSince);

            return Execute<List<Models.Task>>(request);
        }

        /// <summary>
        /// List all tasks for the authenticated account. Makes a GET request to the Tasks resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the task updated-at property</param>
        public async Task<IList<Models.Task>> ListTasksAsync(DateTime? updatedSince = null)
        {
            var request = ListTasksRequest(updatedSince);

            // ReSharper disable once AsyncConverter.AsyncAwaitMayBeElidedHighlighting
            return await ExecuteAsync<List<Models.Task>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve a task on the authenticated account. Makes a GET request to the Tasks resource.
        /// </summary>
        /// <param name="taskId">The Id of the task to retrieve</param>
        public Models.Task Task(long taskId)
        {
            var request = Request("tasks/" + taskId);

            return Execute<Models.Task>(request);
        }

        /// <summary>
        /// Retrieve a task on the authenticated account. Makes a GET request to the Tasks resource.
        /// </summary>
        /// <param name="taskId">The Id of the task to retrieve</param>
        public Task<Models.Task> TaskAsync(long taskId)
        {
            var request = Request("tasks/" + taskId);

            return ExecuteAsync<Models.Task>(request);
        }

        /// <summary>
        /// Creates a new task under the authenticated account. Makes both a POST and a GET request to the Tasks resource.
        /// </summary>
        /// <param name="name">The name of the task</param>
        /// <param name="billableByDefault">Whether the task should be billable when added to a project</param>
        /// <param name="isDefault">Whether the task should be added to new projects</param>
        /// <param name="defaultHourlyRate">The default hourly rate</param>
        public Models.Task CreateTask(string name, bool billableByDefault = false, bool isDefault = false, decimal? defaultHourlyRate = null)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var options = GetTaskOptions(name, billableByDefault, isDefault, defaultHourlyRate);

            return CreateTask(options);
        }

        /// <summary>
        /// Creates a new task under the authenticated account. Makes both a POST and a GET request to the Tasks resource.
        /// </summary>
        /// <param name="name">The name of the task</param>
        /// <param name="billableByDefault">Whether the task should be billable when added to a project</param>
        /// <param name="isDefault">Whether the task should be added to new projects</param>
        /// <param name="defaultHourlyRate">The default hourly rate</param>
        public Task<Models.Task> CreateTaskAsync(string name, bool billableByDefault = false, bool isDefault = false, decimal? defaultHourlyRate = null)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var options = GetTaskOptions(name, billableByDefault, isDefault, defaultHourlyRate);

            return CreateTaskAsync(options);
        }

        /// <summary>
        /// Creates a new task under the authenticated account. Makes a POST and a GET request to the Tasks resource.
        /// </summary>
        /// <param name="options">The options for the new task to be created</param>
        public Models.Task CreateTask(TaskOptions options)
        {
            var request = Request("tasks", Method.POST);

            request.AddBody(options);

            return Execute<Models.Task>(request);
        }

        /// <summary>
        /// Creates a new task under the authenticated account. Makes a POST and a GET request to the Tasks resource.
        /// </summary>
        /// <param name="options">The options for the new task to be created</param>
        public Task<Models.Task> CreateTaskAsync(TaskOptions options)
        {
            var request = Request("tasks", Method.POST);

            request.AddBody(options);

            return ExecuteAsync<Models.Task>(request);
        }

        /// <summary>
        /// Delete a task from the authenticated account. Makes a DELETE request to the Tasks resource.
        /// </summary>
        /// <param name="taskId">The ID of the task to delete</param>
        public bool DeleteTask(long taskId)
        {
            var request = Request("tasks/" + taskId, Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Delete a task from the authenticated account. Makes a DELETE request to the Tasks resource.
        /// </summary>
        /// <param name="taskId">The ID of the task to delete</param>
        public async Task<bool> DeleteTaskAsync(long taskId)
        {
            var request = Request("tasks/" + taskId, Method.DELETE);

            var result = await ExecuteAsync(request).ConfigureAwait(false);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Activate a task on the authenticated account. Makes a POST request to the Tasks/Activate resource and a GET request to the Tasks resource.
        /// </summary>
        /// <param name="taskId">The ID of the task to activate</param>
        public Models.Task ActivateTask(long taskId)
        {
            var request = Request("tasks/" + taskId + "/activate", Method.POST);

            return Execute<Models.Task>(request);
        }

        /// <summary>
        /// Activate a task on the authenticated account. Makes a POST request to the Tasks/Activate resource and a GET request to the Tasks resource.
        /// </summary>
        /// <param name="taskId">The ID of the task to activate</param>
        public Task<Models.Task> ActivateTaskAsync(long taskId)
        {
            var request = Request("tasks/" + taskId + "/activate", Method.POST);

            return ExecuteAsync<Models.Task>(request);
        }

        /// <summary>
        /// Update a task on the authenticated account. Makes a PUT and a GET request to the Tasks resource.
        /// </summary>
        /// <param name="taskId">The Id of the task</param>
        /// <param name="name">The name of the task</param>
        /// <param name="billableByDefault">Whether the task should be billable when added to a project</param>
        /// <param name="isDefault">Whether the task should be added to new projects</param>
        /// <param name="defaultHourlyRate">The default hourly rate</param>
        public Models.Task UpdateTask(long taskId, string name = null, bool? billableByDefault = null, bool? isDefault = null, decimal? defaultHourlyRate = null)
        {
            var options = GetTaskOptions(name, billableByDefault, isDefault, defaultHourlyRate);

            return UpdateTask(taskId, options);
        }

        /// <summary>
        /// Update a task on the authenticated account. Makes a PUT and a GET request to the Tasks resource.
        /// </summary>
        /// <param name="taskId">The Id of the task</param>
        /// <param name="name">The name of the task</param>
        /// <param name="billableByDefault">Whether the task should be billable when added to a project</param>
        /// <param name="isDefault">Whether the task should be added to new projects</param>
        /// <param name="defaultHourlyRate">The default hourly rate</param>
        public Task<Models.Task> UpdateTaskAsync(long taskId, string name = null, bool? billableByDefault = null, bool? isDefault = null, decimal? defaultHourlyRate = null)
        {
            var options = GetTaskOptions(name, billableByDefault, isDefault, defaultHourlyRate);

            return UpdateTaskAsync(taskId, options);
        }

        /// <summary>
        /// Updates a task on the authenticated account. Makes a PUT and a GET request to the Tasks resource.
        /// </summary>
        /// <param name="taskId">The ID for the task to update</param>
        /// <param name="options">The options to be updated</param>
        public Models.Task UpdateTask(long taskId, TaskOptions options)
        {
            var request = Request("tasks/" + taskId, Method.PUT);

            request.AddBody(options);

            return Execute<Models.Task>(request);
        }

        /// <summary>
        /// Updates a task on the authenticated account. Makes a PUT and a GET request to the Tasks resource.
        /// </summary>
        /// <param name="taskId">The ID for the task to update</param>
        /// <param name="options">The options to be updated</param>
        public Task<Models.Task> UpdateTaskAsync(long taskId, TaskOptions options)
        {
            var request = Request("tasks/" + taskId, Method.PUT);

            request.AddBody(options);

            return ExecuteAsync<Models.Task>(request);
        }

        private IRestRequest ListTasksRequest(DateTime? updatedSince)
        {
            var request = Request("tasks");

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return request;
        }

        private static TaskOptions GetTaskOptions(string name, bool? billableByDefault, bool? isDefault, decimal? defaultHourlyRate)
        {
            var options = new TaskOptions
            {
                Name = name,
                BillableByDefault = billableByDefault,
                IsDefault = isDefault,
                DefaultHourlyRate = defaultHourlyRate
            };

            return options;
        }
    }
}

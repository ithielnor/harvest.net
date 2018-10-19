using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        IList<Models.Task> ListTasks(DateTime? updatedSince = null);

        Task<IList<Models.Task>> ListTasksAsync(DateTime? updatedSince = null);

        Models.Task Task(long taskId);

        Task<Models.Task> TaskAsync(long taskId);

        Models.Task CreateTask(string name, bool billableByDefault = false, bool isDefault = false, decimal? defaultHourlyRate = null);

        Task<Models.Task> CreateTaskAsync(string name, bool billableByDefault = false, bool isDefault = false, decimal? defaultHourlyRate = null);

        Models.Task CreateTask(TaskOptions options);

        Task<Models.Task> CreateTaskAsync(TaskOptions options);

        bool DeleteTask(long taskId);

        Task<bool> DeleteTaskAsync(long taskId);

        Models.Task ActivateTask(long taskId);

        Task<Models.Task> ActivateTaskAsync(long taskId);

        Models.Task UpdateTask(long taskId, string name = null, bool? billableByDefault = null, bool? isDefault = null, decimal? defaultHourlyRate = null);

        Task<Models.Task> UpdateTaskAsync(long taskId, string name = null, bool? billableByDefault = null, bool? isDefault = null, decimal? defaultHourlyRate = null);

        Models.Task UpdateTask(long taskId, TaskOptions options);

        Task<Models.Task> UpdateTaskAsync(long taskId, TaskOptions options);
    }
}

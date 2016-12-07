using Harvest.Net.Models;
using System;
using System.Collections.Generic;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        IList<Models.Task> ListTasks(DateTime? updatedSince = null);

        Models.Task Task(long taskId);

        Models.Task CreateTask(string name, bool billableByDefault = false, bool isDefault = false, decimal? defaultHourlyRate = null);

        Models.Task CreateTask(TaskOptions options);
        
        bool DeleteTask(long taskId);

        Models.Task ActivateTask(long taskId);

        Models.Task UpdateTask(long taskId, string name = null, bool? billableByDefault = null, bool? isDefault = null, decimal? defaultHourlyRate = null);

        Models.Task UpdateTask(long taskId, TaskOptions options);
    }
}

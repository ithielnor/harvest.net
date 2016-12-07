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
        IList<Project> ListProjects(long? clientId = null, DateTime? updatedSince = null);

        Project Project(long projectId);

        Project CreateProject(string name, long clientId, bool active = true, BillingMethod billBy = BillingMethod.None, string code = null, string notes = null, BudgetMethod budgetBy = BudgetMethod.None, decimal? budget = null);

        Project CreateProject(ProjectOptions options);

        bool DeleteProject(long projectId);

        bool ToggleProject(long projectId);

        Project UpdateProject(long projectId, long clientId, string name = null, bool? billable = null, BillingMethod? billBy = null, string code = null, string notes = null, BudgetMethod? budgetBy = null, decimal? budget = null, bool? notifyWhenOverBudget = null, decimal? overBudgetNotificationPercentage = null, bool? showBudgetToAll = null, EstimateMethod? estimateBy = null, decimal? estimate = null, decimal? hourlyRate = null, decimal? costBudget = null, bool? costBudgetIncludeExpenses = null);

        Project UpdateProject(long projectId, ProjectOptions options);
      }
}

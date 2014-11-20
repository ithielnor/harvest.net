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
        // https://github.com/harvesthq/api/blob/master/Sections/Projects.md

        /// <summary>
        /// List all projects for the authenticated account. Makes a GET request to the Projects resource.
        /// </summary>
        public IList<Project> ListProjects(long? clientId = null, DateTime? updatedSince = null)
        {
            var request = Request("projects");

            if (clientId != null)
                request.AddParameter("client", clientId);

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));
            
            return Execute<List<Project>>(request);
        }

        /// <summary>
        /// Retrieve a project on the authenticated account. Makes a GET request to the Projects resource.
        /// </summary>
        /// <param name="projectId">The Id of the Project to retrieve</param>
        public Project Project(long projectId)
        {
            var request = Request("projects/" + projectId);

            return Execute<Project>(request);
        }
        
        /// <summary>
        /// Creates a new project under the authenticated account. Makes both a POST and a GET request to the Projects resource.
        /// </summary>
        /// <param name="name">The project name</param>
        /// <param name="clientId">The client to whom the project belongs</param>
        /// <param name="active">The status of the project</param>
        /// <param name="billBy">The invoicing method for the project</param>
        /// <param name="code">The project code</param>
        /// <param name="notes">Notes about the project</param>
        /// <param name="budgetBy">The budgeting method for the project</param>
        /// <param name="budget">The budget of the project</param>
        public Project CreateProject(string name, long clientId, bool active = true, BillingMethod billBy = BillingMethod.None, string code = null, string notes = null, BudgetMethod budgetBy = BudgetMethod.None, decimal? budget = null)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            
            var options = new ProjectOptions()
            {
                ClientId = clientId,
                Name = name,
                Code = code,                
                Active = active,
                BillBy = billBy,
                Notes = notes,
                BudgetBy = budgetBy,
                Budget = budget
            };

            return CreateProject(options);
        }

        /// <summary>
        /// Creates a new project under the authenticated account. Makes a POST and a GET request to the Projects resource.
        /// </summary>
        /// <param name="options">The options for the new Project to be created</param>
        public Project CreateProject(ProjectOptions options)
        {
            var request = Request("projects", RestSharp.Method.POST);

            request.AddBody(options);            

            return Execute<Project>(request);
        }
        
        /// <summary>
        /// Delete a project from the authenticated account. Makes a DELETE request to the Projects resource.
        /// </summary>
        /// <param name="projectId">The ID of the Project to delete</param>
        public bool DeleteProject(long projectId)
        {
            var request = Request("projects/" + projectId, RestSharp.Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Toggle the Active status of a project on the authenticated account. Makes a POST request to the Projects/Toggle resource and a GET request to the Projects resource.
        /// </summary>
        /// <param name="projectId">The ID of the Project to toggle</param>
        public bool ToggleProject(long projectId)
        {
            var request = Request("projects/" + projectId + "/toggle", RestSharp.Method.PUT);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }
        
        /// <summary>
        /// Update a project on the authenticated account. Makes a PUT and a GET request to the Projects resource.
        /// </summary>
        /// <param name="projectId">The ID of the project to update</param>
        /// <param name="name">The project name</param>
        /// <param name="clientId">The client to whom the project belongs</param>
        /// <param name="active">The status of the project</param>
        /// <param name="billBy">The invoicing method for the project</param>
        /// <param name="code">The project code</param>
        /// <param name="notes">Notes about the project</param>
        /// <param name="budgetBy">The budgeting method for the project</param>
        /// <param name="budget">The budget of the project</param>
        /// <param name="notifyWhenOverBudget">Whether to send a notification when project is over budget</param>
        /// <param name="overBudgetNotificationPercentage">Percentage at which to send over-budget notification</param>
        /// <param name="showBudgetToAll">Whether budget is visible to all users</param>
        /// <param name="estimateBy">The project estimating method</param>
        /// <param name="estimate">The project estimate</param>
        /// <param name="hourlyRate">The project hourly rate</param>
        /// <param name="costBudget">The project cost budget</param>
        /// <param name="costBudgetIncludeExpenses">Whether the cost budget includes expenses</param>
        public Project UpdateProject(long projectId, string name = null, long? clientId = null, bool? billable = null, BillingMethod? billBy = null, string code = null, string notes = null, BudgetMethod? budgetBy = null, decimal? budget = null, bool? notifyWhenOverBudget = null, decimal? overBudgetNotificationPercentage = null, bool? showBudgetToAll = null, EstimateMethod? estimateBy = null, decimal? estimate = null, decimal? hourlyRate = null, decimal? costBudget = null, bool? costBudgetIncludeExpenses = null)
        {
            var options = new ProjectOptions()
            {
                ClientId = clientId,
                Name = name,
                Code = code,
                Notes = notes,
                BillBy = billBy,
                Billable = billable,
                BudgetBy = budgetBy,
                Budget = budget,                
                NotifyWhenOverBudget = notifyWhenOverBudget,
                OverBudgetNotificationPercentage = overBudgetNotificationPercentage,
                ShowBudgetToAll = showBudgetToAll,
                EstimateBy = estimateBy,
                Estimate = estimate,
                HourlyRate = hourlyRate,
                CostBudget = costBudget,
                CostBudgetIncludeExpenses = costBudgetIncludeExpenses
            };
            
            return UpdateProject(projectId, options);
        }

        /// <summary>
        /// Updates a project on the authenticated account. Makes a PUT and a GET request to the Projects resource.
        /// </summary>
        /// <param name="projectId">The ID for the project to update</param>
        /// <param name="options">The options to be updated</param>
        public Project UpdateProject(long projectId, ProjectOptions options)
        {
            var request = Request("projects/" + projectId, RestSharp.Method.PUT);

            request.AddBody(options);

            return Execute<Project>(request);
        }
    }
}

using RestSharp.Serializers;
using System;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Model to create or update 
    /// </summary>
    [SerializeAs(Name = "project")]
    public class ProjectOptions
    {
        /// <summary>
        /// Client ID for project.
        /// </summary>
        public long? ClientId { get; set; }

        /// <summary>
        /// Project name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Project code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Whether the project is active or archived. Options: 
        /// <list type="bullet">
        /// <item>
        /// <description>true</description>
        /// </item>
        /// <item>
        /// <description>false</description>
        /// </item>
        /// </list>.
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// Whether the project is billable or not billable. Options: 
        /// <list type="bullet">
        /// <item>
        /// <description>true</description>
        /// </item>
        /// <item>
        /// <description>false</description>
        /// </item>
        /// </list>.
        /// </summary>
        public bool? Billable { get; set; }

        /// <summary>
        /// The method by which the project is invoiced. For further information lookup <see cref="BillingMethod"/>.
        /// </summary>
        public BillingMethod? BillBy { get; set; }

        /// <summary>
        /// Rate for projects billed by Project Hourly Rate.
        /// </summary>
        public decimal? HourlyRate { get; set; }

        /// <summary>
        /// Budget value for the project.
        /// </summary>
        public decimal? Budget { get; set; }

        /// <summary>
        /// The method by which the project is budgeted. For further information lookup <see cref="BudgetMethod"/>.
        /// </summary>
        public BudgetMethod? BudgetBy { get; set; }

        /// <summary>
        /// Option to send notification emails when a project reaches the budget threshold set in Over-Budget-Notification-Percentage Options: 
        /// <list type="bullet">
        /// <item>
        /// <description>true</description>
        /// </item>
        /// <item>
        /// <description>false</description>
        /// </item>
        /// </list>.
        /// </summary>
        public bool? NotifyWhenOverBudget { get; set; }

        /// <summary>
        /// Percentage value to trigger over budget email alerts.
        /// </summary>
        public decimal? OverBudgetNotificationPercentage { get; set; }

        /// <summary>
        /// Option to show project budget to all employees. Does not apply to Total Project Fee projects. Options: 
        /// <list type="bullet">
        /// <item>
        /// <description>true</description>
        /// </item>
        /// <item>
        /// <description>false</description>
        /// </item>
        /// </list>.
        /// </summary>
        public bool? ShowBudgetToAll { get; set; }

        /// <summary>
        /// Estimated amount.
        /// </summary>
        public decimal? Estimate { get; set; }

        /// <summary>
        /// The method by which the project is estimated. For further information lookup <see cref="EstimateMethod"/>.
        /// </summary>
        public EstimateMethod? EstimateBy { get; set; }

        /// <summary>
        /// Project notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Budget value for Total Project Fees projects.
        /// </summary>
        public decimal? CostBudget { get; set; }

        /// <summary>
        /// Option for budget of Total Project Fees projects to include tracked expenses.
        /// </summary>
        public bool? CostBudgetIncludeExpenses { get; set; }

        /// <summary>
        /// Start date of project.
        /// </summary>
        public DateTime? StartsOn { get; set; }

        /// <summary>
        /// End date of project.
        /// </summary>
        public DateTime? EndsOn { get; set; }
    }
}

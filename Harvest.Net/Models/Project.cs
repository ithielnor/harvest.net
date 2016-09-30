using RestSharp.Serializers;
using System;
using System.Collections.Generic;

namespace Harvest.Net.Models
{
    /// <summary>
    /// Project model which is used for the daily and the project API interfaces.
    /// This will represent a project in some specific context.
    /// </summary>
    [SerializeAs(Name = "project")]
    public class Project : IModel
    {
        /// <summary>
        /// Project ID.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Date project was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Date project was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Client ID for project.
        /// </summary>
        public long ClientId { get; set; }

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
        public bool Active { get; set; }

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
        public bool Billable { get; set; }

        /// <summary>
        /// The method by which the project is invoiced. For further information lookup <see cref="BillingMethod"/>.
        /// </summary>
        public BillingMethod BillBy { get; set; }

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
        public BudgetMethod BudgetBy { get; set; }

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
        public bool NotifyWhenOverBudget { get; set; }

        /// <summary>
        /// Percentage value to trigger over budget email alerts.
        /// </summary>
        public decimal? OverBudgetNotificationPercentage { get; set; }

        /// <summary>
        /// Date of last over budget notification. If none have been sent, this will be nil.
        /// </summary>
        public DateTime? OverBudgetNotifiedAt { get; set; }

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
        public bool ShowBudgetToAll { get; set; }

        /// <summary>
        /// Estimated amount.
        /// </summary>
        public decimal? Estimate { get; set; }

        /// <summary>
        /// The method by which the project is estimated. For further information lookup <see cref="EstimateMethod"/>.
        /// </summary>
        public EstimateMethod EstimateBy { get; set; }

        /// <summary>
        /// Project notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Date of earliest record for this project. Updated every 24 hours.
        /// </summary>
        public DateTime? HintEarliestRecordAt { get; set; }

        /// <summary>
        /// Date of most recent record for this project. Updated every 24 hours.
        /// </summary>
        public DateTime? HintLatestRecordAt { get; set; }

        /// <summary>
        /// Budget value for Total Project Fees projects.
        /// </summary>
        public decimal? CostBudget { get; set; }

        /// <summary>
        /// Option for budget of Total Project Fees projects to include tracked expenses.
        /// </summary>
        public bool CostBudgetIncludeExpenses { get; set; }

        /// <summary>
        /// Start date of project.
        /// </summary>
        public DateTime? StartsOn { get; set; }

        /// <summary>
        /// End date of project.
        /// </summary>
        public DateTime? EndsOn { get; set; }
        
        /// <summary>
        /// Name of the client.
        /// Only present on the Daily resource.
        /// </summary>
        public string Client { get; set; }

        /// <summary>
        /// List of tasks assigned to the project.
        /// Only present on the Daily resource.
        /// </summary>
        public List<Task> Tasks { get; set; }
    }
}

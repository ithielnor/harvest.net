using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Models
{
    [SerializeAs(Name = "project")]
    public class Project : IModel
    {
        public long Id { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public long ClientId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public bool Active { get; set; }

        public bool Billable { get; set; }

        public BillingMethod BillBy { get; set; }

        public decimal? HourlyRate { get; set; }

        public decimal? Budget { get; set; }

        public BudgetMethod BudgetBy { get; set; }

        public bool NotifyWhenOverBudget { get; set; }

        public decimal? OverBudgetNotificationPercentage { get; set; }

        public DateTime? OverBudgetNotifiedAt { get; set; }

        public bool ShowBudgetToAll { get; set; }

        public decimal? Estimate { get; set; }

        public EstimateMethod EstimateBy { get; set; }

        public string Notes { get; set; }

        public DateTime? HintEarliestRecordAt { get; set; }

        public DateTime? HintLatestRecordAt { get; set; }

        public decimal? CostBudget { get; set; }

        public bool CostBudgetIncludeExpenses { get; set; }

        // These fields are only present on the Daily resource.
        public string Client { get; set; }

        public List<Task> Tasks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace RiskApplication.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class RiskApplicationController : Controller
    {

        [HttpGet("[action]")]
        public IEnumerable<TacReview> TacReviews()
        {
            var data = System.IO.File.ReadAllText("Data/tac-review.json");
            return JsonConvert.DeserializeObject<TacReview[]>(data);
        }

        [HttpGet("[action]")]
        public AuditReport TacReviewDetails()
        {
            var data = System.IO.File.ReadAllText("Data/tac-review.json");
            var reviews = JsonConvert.DeserializeObject<TacReview[]>(data);

            return new AuditReport() { AuditIssues = GetAuditIssues(reviews) };
        }

        private IEnumerable<Issue> GetAuditIssues(IEnumerable<TacReview> tacReviews)
        {
            List<Issue> auditIssues = new List<Issue>();
            auditIssues.Add(new Issue { Count = tacReviews.Count(t => t.Metric == "Audit Issue past its due date"), Type = ValueType.Expired, Reviews = tacReviews.Where(t => t.Metric == "Audit Issue past its due date") });
            auditIssues.Add(new Issue { Count = tacReviews.Count(t => t.Metric == "Audit Issue with no due date"), Type = ValueType.NoDataSet, Reviews = tacReviews.Where(t => t.Metric == "Audit Issue with no due date") });
            auditIssues.Add(new Issue { Count = tacReviews.Count(t => t.Metric == "Audit Issue expiring in next 7 days"), Type = ValueType.Pendingin7Days, Reviews = tacReviews.Where(t => t.Metric == "Audit Issue expiring in next 7 days") });
            auditIssues.Add(new Issue { Count = tacReviews.Count(t => t.Metric == "Audit Issue expiring in next 30 days"), Type = ValueType.Pendingin30Days, Reviews = tacReviews.Where(t => t.Metric == "Audit Issue expiring in next 30 days") });
            auditIssues.Add(new Issue { Count = tacReviews.Count(t => t.Metric == "Audit Issue expiring in next 60 days"), Type = ValueType.Pendingin60Days, Reviews = tacReviews.Where(t => t.Metric == "Audit Issue expiring in next 60 days") });
            auditIssues.Add(new Issue { Count = tacReviews.Count(t => t.Metric == "Audit Issue expiring in next 90 days"), Type = ValueType.Pendingin90Days, Reviews = tacReviews.Where(t => t.Metric == "Audit Issue expiring in next 90 days") });
            auditIssues.Add(new Issue { Count = tacReviews.Count(t => t.Metric == "Audit Issue expiring in next 120 days"), Type = ValueType.Pendingin120Days, Reviews = tacReviews.Where(t => t.Metric == "Audit Issue expiring in next 120 days") });
            auditIssues.Add(new Issue { Count = tacReviews.Count(t => t.Metric == "Audit Issue expiring in next 150 days"), Type = ValueType.Pendingin150Days, Reviews = tacReviews.Where(t => t.Metric == "Audit Issue expiring in next 150 days") });
            auditIssues.Add(new Issue { Count = tacReviews.Count(t => t.Metric == "Audit Issue expiring in next 180 days"), Type = ValueType.Pendingin180Days, Reviews = tacReviews.Where(t => t.Metric == "Audit Issue expiring in next 180 days") });
            auditIssues.Add(new Issue { Count = tacReviews.Count(t => t.Metric == "Audit Issue expiring in more than 180 days"), Type = ValueType.PendinginMoreThan180Days, Reviews = tacReviews.Where(t => t.Metric == "Audit Issue expiring in more than 180 days") });
            return auditIssues;
        }

        public class TacReview
        {
            public string Division { get; set; }
            public string SuperDept { get; set; }
            public string Department { get; set; }
            public string Metric { get; set; }
            public string IdentifierType { get; set; }
            public string Identifier { get; set; }
            public string Rating { get; set; }
            public string Owner { get; set; }
            public string Title { get; set; }
            public string DueOccured { get; set; }
            public string Source { get; set; }
            public string Link { get; set; }
            public string AsOf { get; set; }
            public string Comments { get; set; }
        }

        public class Issue
        {
            public int Count { get; set; }

            public ValueType Type { get; set; }

            public IEnumerable<TacReview> Reviews { get; set; }

        }

        public class AuditReport
        {
            public IEnumerable<Issue> AuditIssues { get; set; }
            public List<Issue> CreticalHighIssues { get; set; }
            public List<Issue> ModerateLowIssues { get; set; }
            public List<Issue> AuditActions { get; set; }
            public List<Issue> CreticalHighActions { get; set; }
            public List<Issue> ModerateLowActions { get; set; }
            public List<Issue> HighRisks { get; set; }
            public List<Issue> ModerateRisks { get; set; }
            public List<Issue> LowRisks { get; set; }
            public List<Issue> SevereIncidents { get; set; }
            public List<Issue> MajorIncidents { get; set; }
            public List<Issue> MinorIncidents { get; set; }
            public List<Issue> NoImpactIncidents { get; set; }

            public List<Issue> WIRMActions { get; set; }
            public List<Issue> Documentation { get; set; }
            public List<Issue> Hygiene { get; set; }
            public List<Issue> Training { get; set; }
            public List<Issue> RecoveryResilicency { get; set; }
            public List<Issue> Entitlements { get; set; }
            public List<Issue> T30Alerts { get; set; }
        }
        public enum ValueType
        {
            Expired,
            NoDataSet,
            Pendingin7Days,
            Pendingin30Days,
            Pendingin60Days,
            Pendingin90Days,
            Pendingin120Days,
            Pendingin150Days,
            Pendingin180Days,
            PendinginMoreThan180Days,
        }
    }
}

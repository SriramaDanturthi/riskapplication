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
    public partial class RiskApplicationController : Controller
    {

        [HttpGet("[action]")]
        public IEnumerable<TacReview> TacReviews()
        {
            var data = System.IO.File.ReadAllText("Data/tac-review.json");
            return JsonConvert.DeserializeObject<TacReview[]>(data);
        }

        [HttpGet("[action]")]
        public IEnumerable<AuditReportSummary> GetAuditReportSummary()
        {
            var data = System.IO.File.ReadAllText("Data/tac-review.json");
            var reviews = JsonConvert.DeserializeObject<TacReview[]>(data);
            var list = new List<AuditReportSummary>() {
                GetAuditReportSummary(reviews,"Audit Issue ",IdType.AuditIssues),
                GetAuditReportSummaryWithRatings(reviews,"Issue ",  IdType.CriticalHighIssues,new []{ "Critical","High" }),
                GetAuditReportSummaryWithRatings(reviews,"Issue ",  IdType.ModerateLowIssues,new []{ "Low","Moderate","" }),
                GetAuditReportSummary(reviews,"Audit Action Plan ",IdType.AuditActions),
                GetAuditReportSummaryWithRatings(reviews,"Action Plan ",  IdType.CriticalHighIssues,new []{ "Critical","High" }),
                GetAuditReportSummaryWithRatings(reviews,"Action Plan ",  IdType.ModerateLowIssues,new []{ "Low","Moderate","" }),
                GetExpiredRiskMetrics(reviews,"Risk ", IdType.HighRisks,"High"),
                GetExpiredRiskMetrics(reviews,"Risk ", IdType.ModerateRisks,"Moderate"),
                GetExpiredRiskMetrics(reviews,"Risk ", IdType.LowRisks,"Low"),
                GetCloseIncidentSummaryWithRatings(reviews, IdType.SevereIncidents,new []{ "Severe" }),
                GetCloseIncidentSummaryWithRatings(reviews, IdType.MajorIncidents,new []{ "Major" }),
                GetCloseIncidentSummaryWithRatings(reviews, IdType.MinorIncidents,new []{ "Minor" }),
                GetCloseIncidentSummaryWithRatings(reviews, IdType.NoImpactIncidents,new []{ "None" })
            };
            return list;
        }

        [HttpGet("[action]")]
        public IEnumerable<TacReview> GetAuditReportDetails(string metric, string rating)
        {
            var data = System.IO.File.ReadAllText("Data/tac-review.json");
            var reviews = JsonConvert.DeserializeObject<TacReview[]>(data);
            if (!string.IsNullOrEmpty(rating))
                return reviews.Where(t => t.Metric == metric && t.Rating.Contains(rating));
            return reviews.Where(t => t.Metric == metric);
        }

        private AuditReportSummary GetAuditReportSummaryExpiring(IEnumerable<TacReview> tacReviews, string prefix, IdType idType) => new AuditReportSummary
        {
            Type = idType,
            Pendingin7Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 7 days"),
            Pendingin30Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 30 days"),
            Pendingin60Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 60 days"),
            Pendingin90Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 90 days"),
            Pendingin120Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 120 days"),
            Pendingin150Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 150 days"),
            Pendingin180Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 180 days"),
            PendinginMoreThan180Days = tacReviews.Count(t => t.Metric == prefix + "expiring in more than 180 days"),
            ReviewList = tacReviews.Where(t => t.Metric.StartsWith(prefix))
        };

        private AuditReportSummary GetAuditReportSummaryWithRatingsExpiring(IEnumerable<TacReview> tacReviews, string prefix, IdType idType, IEnumerable<string> ratings) => new AuditReportSummary
        {
            Type = idType,
            Pendingin7Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 7 days" && ratings.Contains(t.Rating)),
            Pendingin30Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 30 days" && ratings.Contains(t.Rating)),
            Pendingin60Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 60 days" && ratings.Contains(t.Rating)),
            Pendingin90Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 90 days" && ratings.Contains(t.Rating)),
            Pendingin120Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 120 days" && ratings.Contains(t.Rating)),
            Pendingin150Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 150 days" && ratings.Contains(t.Rating)),
            Pendingin180Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 180 days" && ratings.Contains(t.Rating)),
            PendinginMoreThan180Days = tacReviews.Count(t => t.Metric == prefix + "expiring in more than 180 days" && ratings.Contains(t.Rating)),
            ReviewList = tacReviews.Where(t => t.Metric.StartsWith(prefix))
        };
        private AuditReportSummary GetAuditReportSummaryWithRatingExpiring(IEnumerable<TacReview> tacReviews, string prefix, IdType idType, string rating) => new AuditReportSummary
        {
            Type = idType,
            Pendingin7Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 7 days" && t.Rating == rating),
            Pendingin30Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 30 days" && t.Rating == rating),
            Pendingin60Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 60 days" && t.Rating == rating),
            Pendingin90Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 90 days" && t.Rating == rating),
            Pendingin120Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 120 days" && t.Rating == rating),
            Pendingin150Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 150 days" && t.Rating == rating),
            Pendingin180Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 180 days" && t.Rating == rating),
            PendinginMoreThan180Days = tacReviews.Count(t => t.Metric == prefix + "expiring in more than 180 days" && t.Rating == rating),
            ReviewList = tacReviews.Where(t => t.Metric.StartsWith(prefix))
        };

        private AuditReportSummary GetAuditReportSummary(IEnumerable<TacReview> tacReviews, string prefix, IdType idType) => new AuditReportSummary
        {
            Type = idType,
            Expired = tacReviews.Count(t => t.Metric == prefix + "past its due date"),
            NoDataSet = tacReviews.Count(t => t.Metric == prefix + "with no due date"),
            Pendingin7Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 7 days"),
            Pendingin30Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 30 days"),
            Pendingin60Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 60 days"),
            Pendingin90Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 90 days"),
            Pendingin120Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 120 days"),
            Pendingin150Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 150 days"),
            Pendingin180Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 180 days"),
            PendinginMoreThan180Days = tacReviews.Count(t => t.Metric == prefix + "expiring in more than 180 days"),
            ReviewList = tacReviews.Where(t => t.Metric.StartsWith(prefix))
        };
        private AuditReportSummary GetAuditReportSummaryWithRatings(IEnumerable<TacReview> tacReviews, string prefix, IdType idType, IEnumerable<string> ratings) => new AuditReportSummary
        {
            Type = idType,
            Expired = tacReviews.Count(t => t.Metric == prefix + "past its due date" && ratings.Contains(t.Rating)),
            NoDataSet = tacReviews.Count(t => t.Metric == prefix + "with no due date" && ratings.Contains(t.Rating)),
            Pendingin7Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 7 days" && ratings.Contains(t.Rating)),
            Pendingin30Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 30 days" && ratings.Contains(t.Rating)),
            Pendingin60Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 60 days" && ratings.Contains(t.Rating)),
            Pendingin90Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 90 days" && ratings.Contains(t.Rating)),
            Pendingin120Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 120 days" && ratings.Contains(t.Rating)),
            Pendingin150Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 150 days" && ratings.Contains(t.Rating)),
            Pendingin180Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 180 days" && ratings.Contains(t.Rating)),
            PendinginMoreThan180Days = tacReviews.Count(t => t.Metric == prefix + "expiring in more than 180 days" && ratings.Contains(t.Rating)),
            ReviewList = tacReviews.Where(t => t.Metric.StartsWith(prefix))
        };
        private AuditReportSummary GetCloseIncidentSummaryWithRatings(IEnumerable<TacReview> tacReviews, IdType idType, IEnumerable<string> ratings) => new AuditReportSummary
        {
            Type = idType,
            Expired = tacReviews.Count(t => t.Metric == "Closed incident" && ratings.Contains(t.Rating)),
            Pendingin7Days = tacReviews.Count(t => t.Metric == "Incident pending 7 days or less" && ratings.Contains(t.Rating)),
            Pendingin30Days = tacReviews.Count(t => t.Metric == "Incident pending 30 days or less" && ratings.Contains(t.Rating)),
            Pendingin60Days = tacReviews.Count(t => t.Metric == "Incident pending 60 days or less" && ratings.Contains(t.Rating)),
            Pendingin90Days = tacReviews.Count(t => t.Metric == "Incident pending 90 days or less" && ratings.Contains(t.Rating)),
            Pendingin120Days = tacReviews.Count(t => t.Metric == "Incident pending 120 days or less" && ratings.Contains(t.Rating)),
            Pendingin150Days = tacReviews.Count(t => t.Metric == "Incident pending 150 days or less" && ratings.Contains(t.Rating)),
            Pendingin180Days = tacReviews.Count(t => t.Metric == "Incident pending 180 days or less" && ratings.Contains(t.Rating)),
            PendinginMoreThan180Days = tacReviews.Count(t => t.Metric == "Incident pending more than 180 days" && ratings.Contains(t.Rating)),
            //ReviewList = tacReviews.Where(t => t.Metric.StartsWith(prefix))
        };
        private AuditReportSummary GetAuditReportSummaryWithRating(IEnumerable<TacReview> tacReviews, string prefix, IdType idType, string rating) => new AuditReportSummary
        {
            Type = idType,
            Expired = tacReviews.Count(t => t.Metric == prefix + "past its due date" && t.Rating == rating),
            NoDataSet = tacReviews.Count(t => t.Metric == prefix + "with no due date" && t.Rating == rating),
            Pendingin7Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 7 days" && t.Rating == rating),
            Pendingin30Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 30 days" && t.Rating == rating),
            Pendingin60Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 60 days" && t.Rating == rating),
            Pendingin90Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 90 days" && t.Rating == rating),
            Pendingin120Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 120 days" && t.Rating == rating),
            Pendingin150Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 150 days" && t.Rating == rating),
            Pendingin180Days = tacReviews.Count(t => t.Metric == prefix + "expiring in next 180 days" && t.Rating == rating),
            PendinginMoreThan180Days = tacReviews.Count(t => t.Metric == prefix + "expiring in more than 180 days" && t.Rating == rating),
            ReviewList = tacReviews.Where(t => t.Metric.StartsWith(prefix))
        };

        private AuditReportSummary GetExpiredRiskMetrics(IEnumerable<TacReview> tacReviews, string prefix, IdType idType, string rating)
        {
            var summary = GetAuditReportSummaryWithRatingExpiring(tacReviews, prefix, idType, rating);
            summary.Expired = tacReviews.Count(t => t.Metric == "Expired Risk - requires review" && t.Rating == rating);
            summary.NoDataSet = tacReviews.Count(t => t.Metric == "Authorized Risk with no expected review date" && t.Rating == rating);
            return summary;
        }
    }
}

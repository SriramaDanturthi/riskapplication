using System.Collections.Generic;

namespace RiskApplication.Controllers
{
    public partial class RiskApplicationController
    {
        public class AuditReportSummary
        {
            public IdType Type { get; set; }
            public int Expired { get; set; }
            public int NoDataSet { get; set; }
            public int Pendingin7Days { get; set; }
            public int Pendingin30Days { get; set; }
            public int Pendingin60Days { get; set; }
            public int Pendingin90Days { get; set; }
            public int Pendingin120Days { get; set; }
            public int Pendingin150Days { get; set; }
            public int Pendingin180Days { get; set; }
            public int PendinginMoreThan180Days { get; set; }
            public IEnumerable<TacReview> ReviewList { set; get; }
        }
    }
}

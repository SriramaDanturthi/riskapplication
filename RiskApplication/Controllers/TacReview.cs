namespace RiskApplication.Controllers
{
    public partial class RiskApplicationController
    {
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
    }
}

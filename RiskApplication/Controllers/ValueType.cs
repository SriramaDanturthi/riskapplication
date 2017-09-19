namespace RiskApplication.Controllers
{
    public partial class RiskApplicationController
    {
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

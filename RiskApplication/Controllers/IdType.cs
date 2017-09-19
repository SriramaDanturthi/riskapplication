namespace RiskApplication.Controllers
{
    public partial class RiskApplicationController
    {
        public enum IdType
        {
            AuditIssues,
            CriticalHighIssues,
            ModerateLowIssues,
            AuditActions,
            CriticalHighActions,
            ModerateLowActions,
            HighRisks,
            ModerateRisks,
            LowRisks,
            SevereIncidents,
            MajorIncidents,
            MinorIncidents,
            NoImpactIncidents,
            WIRMActions,
            Documentation,
            Hygiene,
            Training,
            RecoveryResiliency,
            Entitlements,
            T30Alerts
        }
    }
}

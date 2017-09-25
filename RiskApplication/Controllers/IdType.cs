using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace RiskApplication.Controllers
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IdType
    {
        [EnumMember(Value = "Audit Issues")]
        AuditIssues,
        [EnumMember(Value = "Critical High Issues")]
        CriticalHighIssues,
        [EnumMember(Value = "Moderate Low Issues")]
        ModerateLowIssues,
        [EnumMember(Value = "Audit Actions")]
        AuditActions,
        [EnumMember(Value = "Critical High Actions")]
        CriticalHighActions,
        [EnumMember(Value = "Moderate Low Actions")]
        ModerateLowActions,
        [EnumMember(Value = "High Risks")]
        HighRisks,
        [EnumMember(Value = "Moderate Risks")]
        ModerateRisks,
        [EnumMember(Value = "Low Risks")]
        LowRisks,
        [EnumMember(Value = "Severe Incidents")]
        SevereIncidents,
        [EnumMember(Value = "Major Incidents")]
        MajorIncidents,
        [EnumMember(Value = "Minor Incidents")]
        MinorIncidents,
        [EnumMember(Value = "No Impact Incidents")]
        NoImpactIncidents,
        [EnumMember(Value = "WIRM Actions")]
        WIRMActions,
        [EnumMember(Value = "Documentation")]
        Documentation,
        [EnumMember(Value = "Hygiene")]
        Hygiene,
        [EnumMember(Value = "Training")]
        Training,
        [EnumMember(Value = "Recovery Resiliency")]
        RecoveryResiliency,
        [EnumMember(Value = "Entitlements")]
        Entitlements,
        [EnumMember(Value = "T30 Alerts")]
        T30Alerts
    }
}

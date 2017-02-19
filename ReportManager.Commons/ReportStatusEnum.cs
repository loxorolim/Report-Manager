using System.ComponentModel;

namespace ReportManager.Commons
{
    public enum ReportStatusEnum
    {
        [Description("Em espera")]
        Awaiting,
        [Description("Alertado")]
        Alerted,
        [Description("Resolvido")]
        Resolved
    }
}

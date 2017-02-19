using ReportManager.Commons;
using System;

namespace ReportManager.BusinessRules.DataTransferObjects
{
    public class ReportDTO
    {
        public DateTime Date { get; set; }
        public ReportStatusEnum Status { get; set; }
        public string Flow { get; set; }
        public string Application { get; set; }
        public string Impact { get; set; }
        public string Workaround { get; set; }
        public string WorkaroundTime { get; set; }
        public string Solution { get; set; }
        public string SolutionTime { get; set; }
        public string Reporter { get; set; }
        public string Description { get; set; }
        public string ResponsibleTeam { get; set; }

    }
}

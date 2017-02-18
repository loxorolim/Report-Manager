using ReportManager.Commons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportManager.BusinessRules.DataTransferObjects
{
    public class ReportDTO
    {
        public List<string> StatusOptions { get { return Enum.GetNames(typeof(ReportStatusEnum)).ToList();} }

        public DateTime Date { get; set; }
        public int Status { get; set; }
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

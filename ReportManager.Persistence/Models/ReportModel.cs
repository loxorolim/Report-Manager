using ReportManager.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Persistence.Models
{
    public class ReportModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ReportStatusEnum Status { get; set; }
        public string Flow { get; set; }
        public string Application { get; set; }
        public string Impact { get; set; }
        public string Workaround { get; set; }
        public string WorkaraoundTime { get; set; }
        public string Solution { get; set; }
        public string SolutionTime { get; set; }
        public string Reporter { get; set; }
        public string Description { get; set; }
        public string ResponsibleTeam { get; set; }
    }
}

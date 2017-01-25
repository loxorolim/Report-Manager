using ReportManager.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.BusinessRules.Report
{
    public class ReportBr
    {
        public List<string> GetReportStatusTypes()
        {
            return new List<string> { "Aguardando", "Alertado", "Solucionado" };
        }

    }
}

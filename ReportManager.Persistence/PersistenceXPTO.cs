using LiteDB;
using ReportManager.Persistence.Models;
using ReportManager.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Persistence
{
    public static class PersistenceXPTO
    {
        public static int Main()
        {
            ReportRepository a = new ReportRepository(@"Reports.db");
            for(int i = 0; i < 10; i++)
            {
                ReportModel r = new ReportModel()
                {
                    Date = DateTime.Now
                };
                a.InsertReport(r);
            }

            IEnumerable<ReportModel> birl = a.GetReportCollectionByRecentDate(0, 10);
            IEnumerable<ReportModel> birl2 = a.GetReportCollectionByRecentDate(0, 3);

            return 0;
        }
    }
}

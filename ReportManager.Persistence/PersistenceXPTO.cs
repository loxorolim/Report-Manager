using ReportManager.Persistence.Entities;
using ReportManager.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace ReportManager.Persistence
{
    public static class PersistenceXPTO
    {
        public static int Main()
        {
            ReportRepository a = new ReportRepository(@"Reports.db");
            for(int i = 0; i < 10; i++)
            {
                ReportEntity r = new ReportEntity()
                {
                    Date = DateTime.Now
                };
                a.InsertReport(r);
            }

            IEnumerable<ReportEntity> birl = a.GetReportCollectionByRecentDate(0, 10);
            IEnumerable<ReportEntity> birl2 = a.GetReportCollectionByRecentDate(0, 3);

            return 0;
        }
    }
}

using LiteDB;
using ReportManager.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ReportManager.Persistence.Repositories
{
    public class ReportRepository : BaseRepository
    {
        public ReportRepository(string connectionString) : base(connectionString)
        {

        }

        public ReportEntity GetReportById(int id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var reports = db.GetCollection<ReportEntity>("reports");

                return reports.Find(t => t.Id == id).FirstOrDefault();
            }
        }
        public IEnumerable<ReportEntity> GetReportCollectionByRecentDate(int start, int size)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var reports = db.GetCollection<ReportEntity>("reports");

                return reports.Find(Query.All("Date",Query.Descending), start, size);
            }
        }

        public void InsertReport(ReportEntity report)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var reports = db.GetCollection<ReportEntity>("reports");

                reports.Insert(report);
            }
        }
    }
}

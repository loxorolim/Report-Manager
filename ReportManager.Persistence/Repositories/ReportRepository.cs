using LiteDB;
using ReportManager.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Persistence.Repositories
{
    public class ReportRepository : BaseRepository
    {
        public ReportRepository(string connectionString) : base(connectionString)
        {

        }

        public ReportModel GetReport(int id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var reports = db.GetCollection<ReportModel>("reports");

                return reports.Find(t => t.Id == id).FirstOrDefault();
            }
        }
        public IEnumerable<ReportModel> GetReportCollectionByRecentDate(int start, int size)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var reports = db.GetCollection<ReportModel>("reports");

                return reports.Find(Query.All("Date",Query.Descending), start, size);
            }
        }

        public void InsertReport(ReportModel report)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var reports = db.GetCollection<ReportModel>("reports");

                reports.Insert(report);
            }
        }
    }
}

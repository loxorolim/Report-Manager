using ReportManager.BusinessRules.Report;
using ReportManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReportManager.Controllers
{
    public class ReportController : Controller
    {
        private ReportBr _reportBR;

        public ReportController()
        {
            _reportBR = new ReportBr();
        }

        [HttpGet]
        public ActionResult GetReport(int id)
        {
            return View("Report");
        }

        [HttpGet]
        public ActionResult CreateReport()
        {
            List<string> reportStatusTypes = _reportBR.GetReportStatusTypes();

            ViewData["ReportStatuses"] = reportStatusTypes;

            return View();
        }

        [HttpPost]
        public ActionResult CreateReport(CreateReportViewModel createReportViewModel)
        {

            List<string> reportStatusTypes = _reportBR.GetReportStatusTypes();
            ViewData["ReportStatuses"] = reportStatusTypes;

            return View();
        }



        [HttpPost]
        public ActionResult InsertReport(int id)
        {
            return View();
        }
        
        [HttpGet]
        public string GetReportCollectionByRecentDateJson(int start, int size)
        {
            return "wow";
        }


    }
}
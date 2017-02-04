using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ReportManager.BusinessRules.DataTransferObjects;
using ReportManager.BusinessRules.Report;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ReportManager.Controllers
{
    public class ReportController : Controller
    {
        private ReportBr _reportBR;
        private JsonSerializerSettings _jsonSerializerSettings;

        public ReportController()
        {
            _reportBR = new ReportBr();
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Converters =
                {
                    new StringEnumConverter { CamelCaseText = false },
                    new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }
                }
            };
        }


        [HttpGet]
        public string GetReportCollectionByRecentDate(int start, int size)
        {
            IEnumerable<ReportDTO> reports = _reportBR.GetReportCollectionByRecentDate(start,size);

            string json = JsonConvert.SerializeObject(reports,_jsonSerializerSettings);

            return json;
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
        public ActionResult CreateReport(ReportDTO reportDto)
        {
            if(ModelState.IsValid)
            {
                _reportBR.CreateReport(reportDto);
                return View("Index");
            }
            // deu xibu
            return View("500");
            
            
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
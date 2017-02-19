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
        private JsonSerializer _jsonSerializer;
        private JsonSerializerSettings _jsonSerializerSettings;

        public ReportController()
        {
            _reportBR = new ReportBr();
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters =
                {
                    new StringEnumConverter { CamelCaseText = false }//,
                    //new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }
                }
            };
            _jsonSerializer = JsonSerializer.Create(_jsonSerializerSettings);
        }


        [HttpGet]
        public string GetReportCollectionByRecentDate(int start, int size)
        {
            IEnumerable<ReportDTO> reports = _reportBR.GetReportCollectionByRecentDate(start,size);

            return JsonConvert.SerializeObject(reports, _jsonSerializerSettings);
        }

        [HttpGet]
        public string GetReportJson(int id)
        {
            return "";
        }

        [HttpGet]
        public ActionResult GetReport(int id)
        {
            
            return View(id);

        }


        [HttpGet]
        public ActionResult CreateReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateReport(ReportDTO reportDto)
        {
            //Fluxo não vai poder ser nulo.
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
        



    }
}
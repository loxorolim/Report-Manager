using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ReportManager.BusinessRules.DataTransferObjects;
using ReportManager.BusinessRules.Report;
using ReportManager.Commons;
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

        [HttpPost]
        public void UpdateReport(ReportDTO report)
        {
            _reportBR.UpdateReport(report);
        }

        [HttpPost]
        public void CreateReport(ReportDTO report)
        {
            _reportBR.CreateReport(report);
        }

        [HttpPost]
        public void DeleteReport(ReportDTO report)
        {
            _reportBR.DeleteReport(report);
        }

        [HttpGet]
        public string GetReportUtilsJson()
        {
            var utils = new
            {
                EmptyReport = new ReportDTO(),
                ReportStatusOptions = EnumTools.GetEnumList<ReportStatusEnum>()

            };

            return JsonConvert.SerializeObject(utils, _jsonSerializerSettings);
        }
    }
}
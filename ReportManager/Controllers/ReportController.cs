﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
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

        [HttpGet]
        public string GetReportJson(int id)
        {
            ReportDTO report = _reportBR.GetReportById(id);

            if (report.Date != null && report.Flow != null)
            {
                JObject jsonObject = JObject.FromObject(report, _jsonSerializer);
                jsonObject.Add("year", report.Date.Year);
                jsonObject.Add("month", ((MonthEnum)report.Date.Month).ToString());
                jsonObject.Add("day", report.Date.Day);
                jsonObject.Add("hour", report.Date.Hour + ":" + report.Date.Minute);
                return jsonObject.ToString();
            }
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
            List<string> reportStatusTypes = _reportBR.GetReportStatusTypes();

            ViewData["ReportStatuses"] = reportStatusTypes;

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
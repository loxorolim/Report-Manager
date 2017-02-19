using ReportManager.BusinessRules.Report;
using System.Web.Mvc;

namespace ReportManager.Controllers
{
    public class HomeController : Controller
    {
        private ReportBr _reportBR;

        public HomeController()
        {
            _reportBR = new ReportBr();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
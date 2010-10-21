using System.Web.Mvc;
using System;

namespace Northwind.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var logger = log4net.LogManager.GetLogger("Northwind");
            logger.Info("Calling HomeController.Index");
            return View();
        }
    }
}

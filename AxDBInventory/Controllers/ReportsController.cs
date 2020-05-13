using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AxDBInventory.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult ListGridReport()
        {
            return View();
        }
    }
}
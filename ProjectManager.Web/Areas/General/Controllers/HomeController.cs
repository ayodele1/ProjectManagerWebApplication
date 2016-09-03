using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Web.Areas.General.Controllers
{
    public class HomeController : Controller
    {
        // GET: General/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
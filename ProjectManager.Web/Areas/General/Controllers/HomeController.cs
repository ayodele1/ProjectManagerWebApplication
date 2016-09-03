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

        public ActionResult Welcome()
        {
            return View();
        }
    }
}
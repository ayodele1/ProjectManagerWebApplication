using System.Web.Mvc;

namespace ProjectManager.Web.Areas.Authentication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Authentication/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return Content("");
        }
    }
}
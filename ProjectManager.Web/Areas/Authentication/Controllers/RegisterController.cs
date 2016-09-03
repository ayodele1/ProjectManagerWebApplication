using System.Web.Mvc;

namespace ProjectManager.Web.Areas.Authentication.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Authentication/Register
        public ActionResult Index()
        {
            ViewBag.Title = "Create a New Account";
            return View();
        }


    }
}
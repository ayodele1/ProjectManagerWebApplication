using ProjectManager.Web.Areas.Authentication.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectManager.Web.Areas.Authentication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Authentication/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel newLogin)
        {
            if (!ModelState.IsValid)
                return View(newLogin);
            try
            {
                if (Membership.ValidateUser(newLogin.UserName, newLogin.Password))
                {
                    FormsAuthentication.SetAuthCookie(newLogin.UserName, true);
                    return RedirectToAction("Welcome", "Home", new { area = "General" });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
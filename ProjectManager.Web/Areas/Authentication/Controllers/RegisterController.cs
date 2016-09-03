using DomainObjects;
using System.Web.Mvc;

namespace ProjectManager.Web.Areas.Authentication.Controllers
{
    public class RegisterController : Controller
    {
        private UserResponsibilityRepository _urr = new UserResponsibilityRepository();
        private UserRepository _ur = new UserRepository();
        // GET: Authentication/Register
        public ActionResult Index()
        {
            ViewBag.ResponsibilityId = new SelectList(_urr.GetAll(), "Id", "Responsibility");
            ViewBag.Title = "Create a New Account";
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNewUser(User newUser)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            try
            {
                newUser.Role = "User";
                newUser.SetPasswordHash(newUser.Password); ///Hashes the password using Bcrypt.
                _ur.AddUser(newUser);
                return RedirectToAction("Welcome", "Home", new { area = "General" });
            }
            catch (System.Exception)
            {
                return RedirectToAction("Index");
            }
        }


    }
}
using DomainObjects;
using ProjectManager.Web.Areas.Authentication.ViewModels;
using System;
using System.Data.Entity.Validation;
using System.Web.Mvc;

namespace ProjectManager.Web.Areas.Authentication.Controllers
{
    public class RegisterController : Controller
    {
        private UserResponsibilityRepository _urr = new UserResponsibilityRepository();
        private UserRepository _ur = new UserRepository();
        ModelMapper mapper = new ModelMapper();
        // GET: Authentication/Register
        public ActionResult Index()
        {
            ViewBag.ResponsibilityId = new SelectList(_urr.GetAll(), "Id", "Responsibility");
            ViewBag.Title = "Create a New Account";
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNewUser(RegistrationModel newRegistration)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            try
            {
                User newUser = new User("User");
                if (!mapper.Map<RegistrationModel, User>(newRegistration, newUser))
                    throw new InvalidOperationException();
                newUser.SetPasswordHash(newUser.Password); ///Hashes the password using Bcrypt.
                _ur.AddUser(newUser);
                return RedirectToAction("Welcome", "Home", new { area = "General" });
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException)
            {
                return RedirectToAction("Index");
            }
        }


    }
}
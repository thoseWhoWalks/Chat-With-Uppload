using Some.Controllers;
using App.Model.Api;
using App.Model.Services;
using System.Web.Mvc;
using System.Web.Security;

namespace App.UI.Controllers
{
    public class AccountController : ControllerBaseModelList<AccountModelApi>
    {
        public AccountController() : base(UnitOfWork.Instance.AccountService)
        {
        }

        public ActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(UnitOfWork.Instance.AccountService.CurrentUser);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountModelApi model)
        {
            var res = UnitOfWork.Instance.AccountService.VerifyUser(model.Password,model.Login);

            if (res != null)
            {
                FormsAuthentication.SetAuthCookie(model.Login, true);
                return RedirectToAction("Chat","Chat");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
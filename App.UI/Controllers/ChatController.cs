using App.Model;
using Some.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Model.Services;
using System.Web.Mvc;



namespace App.UI.Controllers
{
    public class ChatController : ControllerBaseModelList<MessageModelApi>
    {
        public ChatController() : base(UnitOfWork.Instance.MessageService)
        {
        }

        public ActionResult Chat()
        {

            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("SignUp", "Account");

            ViewBag.Title = "Chat Page";

            return View(_service.GetList());
        }
    }
}
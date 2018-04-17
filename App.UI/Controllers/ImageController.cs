using App.Model;
using Some.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Model.Services;
using System.Web.Mvc;
using System.IO;

namespace App.UI.Controllers
{
    public class ImageController : ControllerBaseModelList<ImageModelApi>
    {
        public ImageController(ServiceBaseModelList<ImageModelApi> service) : base(UnitOfWork.Instance.ImageService)
        {
        }
        
        public ActionResult Uppload(HttpPostedFileBase file)
        {
            if (file == null)
                return RedirectToAction("Account", "SignUp");

            #region Saving
            string pic = System.IO.Path.GetFileName(file.FileName);
            string path = System.IO.Path.Combine(
                                       Server.MapPath("~/UserContent/UserImages"), pic);
            
            file.SaveAs(path);
            #endregion

            #region Saving to DB
            var img = new ImageModelApi
            {
                Path = path,
                Upploader = UnitOfWork.Instance.AccountService.CurrentUser
            };

            _service.Create(img);
            #endregion

            return RedirectToAction("Account", "SignUp");
        }
    }
}
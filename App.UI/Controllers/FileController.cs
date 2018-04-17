using App.Model;
using Some.Controllers;
using System.Web;
using App.Model.Services;
using System.Web.Mvc;

namespace App.UI.Controllers
{
    public class FileController : ControllerBaseModelList<FileModelApi>
    {
        public FileController(ServiceBaseModelList<FileModelApi> service) : base(UnitOfWork.Instance.FileService)
        { 

        }

        public ActionResult Uppload(HttpPostedFileBase file)
        {

            if (file == null)
                return RedirectToAction("Chat", "Chat");

            #region Saving
            string pic = System.IO.Path.GetFileName(file.FileName);
            string path = System.IO.Path.Combine(
                                       Server.MapPath("~/UserContent/UserFiles"), pic);

            file.SaveAs(path);
            #endregion

            #region Saving to DB
            var f = new FileModelApi
            {
                Path = path,
                 Uploder = UnitOfWork.Instance.AccountService.CurrentUser
            };

            _service.Create(f);
            #endregion

            return View("Chat", f);
        }

        public FileResult Download(FileModelApi model)
        { 
            return File( model.Path, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}
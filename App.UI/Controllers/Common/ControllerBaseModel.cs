using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model.Services;
using System.Web.Mvc;

namespace Some.Controllers 
{
    public abstract class ControllerBaseModel<TModel>:Controller
    {
        protected readonly ServiceBaseModel<TModel> _service;
        public ControllerBaseModel(ServiceBaseModel<TModel> service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual ActionResult Post(TModel model)
        {

            var res = _service.Create(model);

            return View("SignUp", res);
        }

        [HttpDelete]
        public virtual ActionResult Delete(TModel model)
        {
            var res = _service.Delete(model);

            return RedirectToAction("Home", "Index");
        }

        [HttpPut]
        public virtual ActionResult Put(TModel model)
        {
            var res = _service.Update(model);

            return View("SignUp",model);
        }
    }
}

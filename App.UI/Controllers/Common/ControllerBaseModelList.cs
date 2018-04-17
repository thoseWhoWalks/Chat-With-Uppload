using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model.Services;

namespace Some.Controllers 
{
    public abstract class  ControllerBaseModelList<TModel> : ControllerBaseModel<TModel>
    {
        protected readonly ServiceBaseModelList<TModel> _service;
        public ControllerBaseModelList(ServiceBaseModelList<TModel> service) : base(service)
        {
            _service = service;
        }

        public virtual ICollection<TModel> GetList()
        {
            return _service.GetList();
        }
    }
}

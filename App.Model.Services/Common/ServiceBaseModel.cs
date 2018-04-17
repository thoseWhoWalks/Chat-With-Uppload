using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model.Data;

namespace App.Model.Services 
{
    public class ServiceBaseModel<TModel> : ServiceBase
    {
        public ServiceBaseModel(DB_Context context) : base(context)
        {
        }

        public virtual TModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual TModel Create(TModel model)
        {
            throw new NotImplementedException();
        }

        public virtual TModel Update(TModel model)
        {
            throw new NotImplementedException();
        }

        public virtual TModel Delete(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}

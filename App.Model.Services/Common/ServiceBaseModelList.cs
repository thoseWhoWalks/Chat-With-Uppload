using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model.Data;

namespace App.Model.Services
{
    public class ServiceBaseModelList<TModel> : ServiceBaseModel<TModel>
    {
        public ServiceBaseModelList(DB_Context context) : base(context)
        {
        }

        public virtual ICollection<TModel> GetList()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model.Data;

namespace App.Model.Services 
{
    public class ServiceBase
    {
        protected readonly DB_Context db_context;
        public ServiceBase(DB_Context context)
        {
            db_context = context;
        }
    }
}

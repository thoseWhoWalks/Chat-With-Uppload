using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class ResponseBase<TModel>
    {
        public bool OK { get; set; } = true;

        public TModel Model { get; set; }
    }
}

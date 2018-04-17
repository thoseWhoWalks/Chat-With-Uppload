using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model.Data
{
    class NameConvention:Convention 
    {
        public NameConvention()
        {
            Properties<string>()
                .Where(s => (s.Name == "FirstName" || s.Name == "LastName" || s.Name == "Login"|| s.Name =="Email"))
                .Configure(s => s.HasMaxLength(256).IsRequired());
        }
    }
}

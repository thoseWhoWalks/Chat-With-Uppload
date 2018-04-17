using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model.Data
{
    class PathConvention:Convention
    {
        public PathConvention()
        {
            Properties<string>()
                .Where(s => s.Name == "Path")
                .Configure(s => s.HasMaxLength(256).IsRequired());
        }
    }
}

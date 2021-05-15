using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSalon.Services.ExportF
{
    public class ExportFactory
    {
        public Export create(ExportTypes exportTypes)
        {
            if(exportTypes == ExportTypes.JSON)
            {
                return new ExportJSON();
            }else if(exportTypes == ExportTypes.CSV)
            {
                return new ExportCSV();
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSalon.Services.ExportF
{
    public class ExportFactory
    {
        public Export create(string exportTypes)
        {
            if(exportTypes == ExportTypes.json.ToString())
            {
                return new ExportJSON();
            }else if(exportTypes == ExportTypes.csv.ToString())
            {
                return new ExportCSV();
            }
            else if(exportTypes == ExportTypes.xlsx.ToString())
            {
                return new ExportExcel();
            }
            return null;
        }
    }
}

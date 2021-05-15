using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalon.Models;

namespace WebSalon.Services.ExportF
{
    public interface Export
    {
        public void export(List<ProgramareExport> programari);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebSalon.Models;

namespace WebSalon.Services.ExportF
{
    public class ExportJSON : Export
    {
        public void export(List<ProgramareExport> programari)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(programari,options);
            File.WriteAllText(@"D:\sem2@utcn\PS\lab8\WebSalon\WebSalon\Programari.json", json);
        }
    }
}

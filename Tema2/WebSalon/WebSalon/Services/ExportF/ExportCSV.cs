using System;
using System.Collections.Generic;
using System.IO;
using WebSalon.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace WebSalon.Services.ExportF
{
    public class ExportCSV : Export
    {
        public void export(List<ProgramareExport> programari)
        {
            TextWriter textWriter = File.CreateText("Programari.csv");
            CsvConfiguration cofiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
            cofiguration.HasHeaderRecord = true;
            cofiguration.Delimiter = ",";
            var csvWriter = new CsvWriter(textWriter,cofiguration);

            csvWriter.WriteRecords<ProgramareExport>(programari);
            textWriter.Flush();

            textWriter.Close();

        }
    }
}

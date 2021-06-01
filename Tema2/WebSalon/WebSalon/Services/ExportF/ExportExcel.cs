using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GemBox.Spreadsheet;
using Syncfusion.XlsIO;
using WebSalon.Models;


namespace WebSalon.Services.ExportF
{
    public class ExportExcel : Export
    {
        public void export(List<ProgramareExport> programari)
        {

            List<ProgramareViewModel> programareViewModels = new List<ProgramareViewModel>();
            foreach(ProgramareExport programare in programari)
            {
                ProgramareViewModel programareViewModel = new ProgramareViewModel();
                programareViewModel.ProgramareId = programare.ProgramareId;
                programareViewModel.numeClient = programare.numeClient;
                programareViewModel.telefon = programare.telefon;
                programareViewModel.dataOra = programare.dataOra;
                programareViewModel.cost = programare.cost;

                programareViewModels.Add(programareViewModel);
            }

            DataTableUtility dataTableUtility = new DataTableUtility();
            DataTable dataTable = dataTableUtility.ConvertToDataTable(programareViewModels);

            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var workbook = new ExcelFile();
            var worksheet = workbook.Worksheets.Add("DataTable to Sheet");

            worksheet.Cells[0, 0].Value = "Programari:";

            worksheet.InsertDataTable(dataTable,
            new InsertDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 2
            });

            workbook.Save("Programari.xlsx");
        }
    }
}

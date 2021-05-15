using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalon.Models;

namespace WebSalon.Services
{
    public interface IProgramareService
    {
        public IEnumerable<Programare> GetProgramari();
        public  Programare GetProgramare(int programareId);
        public void AdaugareProgramare(Programare programare);
        public void StergereProgramare(Programare programare);
        public void UpdateProgramare(Programare programare);
        public void Save();
        public ProgramareViewModel costTotal(int programareId);
        public IEnumerable<Programare> GetProgramareClient(string numeClient);
        public ProgramareDataViewModel GetProgramareDataInceputFinal(DateTime dataI, DateTime dataF);
        public void Dispose();
        public void export(string type, List<ProgramareExport> programari);
        public List<ProgramareExport> getProgramariExport();
    }
}

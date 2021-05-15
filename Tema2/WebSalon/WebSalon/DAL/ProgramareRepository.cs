using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalon.Data;
using WebSalon.Models;

namespace WebSalon.DAL
{
    public class ProgramareRepository : GenericRepository<Programare> 
    {
        public ProgramareRepository(WebSalonContext context) : base(context) { }

        public ProgramareViewModel costProgramare(int programareId)
        {
            Programare programare = GetByID(programareId);
            ProgramareViewModel programareViewModel = new ProgramareViewModel();

            programareViewModel.ProgramareId = programare.ProgramareId;
            programareViewModel.numeClient = programare.numeClient;
            programareViewModel.dataOra = programare.dataOra;
            programareViewModel.telefon = programare.telefon;
            float cost = 0.0f;

            List<Serviciu> servicii = _context.Serviciu.Where(ps => ps.ProgramareServiciu.Any(p => p.Programare.ProgramareId == programareId)).ToList();

            foreach(Serviciu serviciu in servicii)
            {
                cost += serviciu.pret;
            }

            programareViewModel.cost = cost;

            return programareViewModel;
        }

        public List<ProgramareExport> getProgramariExport()
        {
            List<ProgramareExport> programariExport = new List<ProgramareExport>();


            List<Programare> programari = Get().ToList();

            foreach (Programare programare in programari)
            {

                ProgramareExport programareExport = new ProgramareExport();

                programareExport.ProgramareId = programare.ProgramareId;
                programareExport.numeClient = programare.numeClient;
                programareExport.dataOra = programare.dataOra;
                programareExport.telefon = programare.telefon;
                float cost = 0.0f;

                List<Serviciu> servicii = _context.Serviciu.Where(ps => ps.ProgramareServiciu.Any(p => p.Programare.ProgramareId == programare.ProgramareId)).ToList();

                foreach (Serviciu serviciu in servicii)
                {
                    cost += serviciu.pret;
                }

                programareExport.cost = cost;
                programareExport.servicii = servicii;
                programariExport.Add(programareExport);
            }

            return programariExport;
        }

        public IQueryable<DateTime> selectListData()
        {
            IQueryable<DateTime> dateQuery = from p in _context.Programare
                                             orderby p.dataOra
                                             select p.dataOra;
            return dateQuery;
        }
    }

   
}

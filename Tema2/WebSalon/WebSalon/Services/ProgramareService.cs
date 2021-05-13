using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSalon.DAL;
using WebSalon.Data;
using WebSalon.Models;

namespace WebSalon.Services
{
    public class ProgramareService : IProgramareService
    {

        private UnitOfWork unitOfWork;

        public ProgramareService(WebSalonContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public void AdaugareProgramare(Programare programare)
        {
            unitOfWork.ProgramareRepository.Insert(programare);
            unitOfWork.Save();
        }

        public Programare GetProgramare(int programareId)
        {
            Programare programare = unitOfWork.ProgramareRepository.GetByID(programareId);
            return programare;
        }

        public IEnumerable<Programare> GetProgramari()
        {
            IEnumerable<Programare> programari = unitOfWork.ProgramareRepository.Get();
            return programari;
        }

        public void StergereProgramare(Programare programare)
        {
            unitOfWork.ProgramareRepository.Delete(programare);
            unitOfWork.Save();
        }

        public void UpdateProgramare(Programare programare)
        {
            unitOfWork.ProgramareRepository.Update(programare);
            unitOfWork.Save();
        }

        public void Save()
        {
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public ProgramareViewModel costTotal(int programareId)
        {
            return unitOfWork.ProgramareRepository.costProgramare(programareId);
        }

        public IEnumerable<Programare> GetProgramareClient(string numeClient)
        {
            IEnumerable<Programare> programari = unitOfWork.ProgramareRepository.Get();
            programari = programari.Where(p => p.numeClient.Contains(numeClient));
            return programari;
        }

        public ProgramareDataViewModel GetProgramareDataInceputFinal(DateTime dataI, DateTime dataF)
        {
            IEnumerable<Programare> programariL = unitOfWork.ProgramareRepository.Get();
            programariL = programariL.Where(p => p.dataOra.Date >= dataI.Date && p.dataOra.Date <= dataF.Date);


            ProgramareDataViewModel programareDataViewModel = new ProgramareDataViewModel
            {
                programari = programariL.ToList(),
                DateInceput = new SelectList(unitOfWork.ProgramareRepository.selectListData().Distinct().ToList()),
                DateFinala = new SelectList(unitOfWork.ProgramareRepository.selectListData().Distinct().ToList())

            };

            return programareDataViewModel;
        }
    }
}

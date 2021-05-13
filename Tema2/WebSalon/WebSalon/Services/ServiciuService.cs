using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalon.DAL;
using WebSalon.Data;
using WebSalon.Models;

namespace WebSalon.Services
{
    public class ServiciuService : IServiciuService
    {
        private UnitOfWork unitOfWork;

        public ServiciuService(WebSalonContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public void AdaugareServiciu(Serviciu serviciu)
        {
            unitOfWork.ServiciuRepository.Insert(serviciu);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Serviciu GetServiciu(int serviciuId)
        {
            Serviciu serviciu = unitOfWork.ServiciuRepository.GetByID(serviciuId);
            return serviciu;
        }

        public IEnumerable<Serviciu> GetServicii()
        {
            IEnumerable<Serviciu> servicii = unitOfWork.ServiciuRepository.Get();
            return servicii;
        }

        public void Save()
        {
            unitOfWork.Save();
        }

        public void StergereServiciu(Serviciu serviciu)
        {
            unitOfWork.ServiciuRepository.Delete(serviciu);
            unitOfWork.Save();
        }

        public void UpdateServiciu(Serviciu serviciu)
        {
            unitOfWork.ServiciuRepository.Update(serviciu);
            unitOfWork.Save();
        }
    }
}

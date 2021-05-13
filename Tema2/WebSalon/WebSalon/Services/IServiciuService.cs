using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalon.Models;

namespace WebSalon.Services
{
    interface IServiciuService
    {
        public IEnumerable<Serviciu> GetServicii();
        public Serviciu GetServiciu(int serviciuId);
        public void AdaugareServiciu(Serviciu serviciu);
        public void StergereServiciu(Serviciu serviciu);
        public void UpdateServiciu(Serviciu serviciu);
        public void Save();
        public void Dispose();
    }
}

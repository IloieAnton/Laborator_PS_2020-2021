using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema1.Entities;

namespace Tema1.DAO.serviciu
{
    public interface IServiciuDAO
    {
        List<Serviciu> getAllServicii();
        bool addServiciu(Serviciu serviciu);

        bool deleteServiciu(String numeServiciu);

        bool updateServiciu(String nume, float pret);

        Serviciu getServiciu(String nume);
    }
}

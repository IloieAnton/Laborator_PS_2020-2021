using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema1.DAO.serviciu;
using Tema1.Entities;

namespace Tema1.BL
{
    public class ServiciuService
    {
        IServiciuDAO _serviciuDAO;

        public ServiciuService(IServiciuDAO serviciuDAO)
        {
            _serviciuDAO = serviciuDAO;
        }

        public bool adaugareServiciu(String nume,String pret)
        {
            float pretFloat = 0.0f;
            try
            {
                pretFloat = float.Parse(pret, CultureInfo.InvariantCulture.NumberFormat);
            }catch(FormatException e)
            {
                return false;
            }
            //float pretFloatR= (float)Math.Round(pretFloat * 100f) / 100f; // rotunjire cu 2 zecimale
            Serviciu serviciu = new Serviciu(nume, pretFloat);
            return _serviciuDAO.addServiciu(serviciu);

        }

        public bool stergereServiciu(String nume)
        {
            return _serviciuDAO.deleteServiciu(nume);
        }

        public List<Serviciu> afisareServicii()
        {
            List<Serviciu> servicii = null;
            servicii = _serviciuDAO.getAllServicii();
            return servicii;
        }

        public bool modifcareServiciu(String nume, String pretNou)
        {
            float pretFloat = 0.0f;
            try
            {
                pretFloat = float.Parse(pretNou, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch (FormatException e)
            {
                return false;
            }

            return _serviciuDAO.updateServiciu(nume, pretFloat);
        }

        public Serviciu getServiciu(String nume)
        {
            return _serviciuDAO.getServiciu(nume);
        }
    }
}

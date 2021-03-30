using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1.Entities
{
    public class Serviciu
    {
        String nume;
        float pret;

        public Serviciu(String nume,float pret)
        {
            this.nume = nume;
            this.pret = pret;
        }

        public String getNume()
        {
            return nume;
        }

        public float getPret()
        {
            return pret;
        }

        public void setNume(String nume)
        {
            this.nume = nume;
        }

        public void setPret(float pret)
        {
            this.pret = pret;
        }
    }
}

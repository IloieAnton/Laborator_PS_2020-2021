using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1.Entities
{
    public class Programare
    {
        private String numeClient;
        private DateTime data;
        private DateTime ora;
        private String telefon;
        private List<Serviciu> servicii;
        private int idServicii;

        public Programare(String numeClient, DateTime data, DateTime ora, String telefon,List<Serviciu> servicii){
            this.numeClient = numeClient;
            this.data = data;
            this.ora = ora;
            this.telefon = telefon;
            this.servicii = servicii;
        }

        public void setNumeClient(String numeClient)
        {
            this.numeClient = numeClient;
        }
        public String getNumeClient()
        {
            return numeClient;
        }
        public void setData(DateTime data)
        {
            this.data = data;
        }

        public DateTime getData()
        {
            return data;
        }
        public void setOra(DateTime ora)
        {
            this.ora = ora;
        }

        public DateTime getOra()
        {
            return ora;
        }

        public void setTelefon(String telefon)
        {
            this.telefon = telefon;
        }
        public String getTelefon()
        {
            return telefon;

        }

        public void setServicii(List<Serviciu> servicii)
        {
            this.servicii = servicii;
        }

        public List<Serviciu> getServicii()
        {
            return servicii;
        }

        public int getId()
        {
            return idServicii;
        }

        public void setId(int idServicii)
        {
            this.idServicii = idServicii;
        }
    }
}

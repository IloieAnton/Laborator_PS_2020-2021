using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1.Entities
{
    public class User
    {
        private String username;
        private String parola;
        private String rol;
        private String nume;

        public User(String username, String parola, String nume, String rol)
        {
            this.username = username;
            this.parola = parola;
            this.rol = rol;
            this.nume = nume;
        }

        public void setRol(String rol)
        {
            this.rol = rol;
        }
        public void setUsername(String username)
        {
            this.username = username;
        }
        public void setParola(String parola)
        {
            this.parola = parola;
        }
        public void setNume(String nume)
        {
            this.nume = nume;
        }
        public String getRol()
        {
            return rol;
        }

        public String getUsername()
        {
            return username;
        }

        public String getParola()
        {
            return parola;
        }

        public String getNume()
        {
            return nume;
        }
    }
}

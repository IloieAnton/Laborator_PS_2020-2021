using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1.Entities
{
    public class ProgramareServiciu
    {
        private int id;
        private String numeServiciu;

        public ProgramareServiciu(int id,String numeServiciu)
        {
            this.id = id;
            this.numeServiciu = numeServiciu;
        }

        public int getId()
        {
            return id;
        }
        public String getNumeServiciu()
        {
            return numeServiciu;
        }

        public void setId(int id)
        {
            this.id=id;
        }

        public void setNumeServiciu(String numeServiciu)
        {
            this.numeServiciu = numeServiciu;
        }
    }
}

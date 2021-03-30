using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema1.DAO.programare;
using Tema1.Entities;

namespace Tema1.BL
{
    class ProgramareServiciuServer
    {
        private IProgramareServiciuDAO _programareServiciuDAO;

        public ProgramareServiciuServer(IProgramareServiciuDAO programareServiciuDAO)
        {
            _programareServiciuDAO = programareServiciuDAO;
        }

        public bool addProgramareServiciu(ProgramareServiciu programareServiciu)
        {
            return _programareServiciuDAO.addProgramareServicii(programareServiciu);
        }

        public List<ProgramareServiciu> selectareServiciiClient(int id)
        {
            return _programareServiciuDAO.selectServiciiClient(id);
        }

    }
}

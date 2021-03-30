using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema1.Entities;

namespace Tema1.DAO.programare
{
    public interface IProgramareServiciuDAO
    {
        bool addProgramareServicii(ProgramareServiciu programareServiciu);
        List<ProgramareServiciu> selectServiciiClient(int id);
    }
}

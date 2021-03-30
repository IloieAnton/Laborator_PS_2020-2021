using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema1.Entities;

namespace Tema1.DAO.programare
{
    public interface IProgramareDAO
    {
        int  addProgramare(Programare programare);

        List<Programare> getProgramari(DateTime date);

        List<Programare> getProgramariClient(String numeClient);
    }
}

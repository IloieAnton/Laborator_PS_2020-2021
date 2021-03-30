using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema1.DAO.programare;
using Tema1.DAO.serviciu;
using Tema1.Entities;

namespace Tema1.BL
{
    public class ProgramareService
    {
        private IProgramareDAO _programareDAO;
        private IServiciuDAO _serviciuDAO;
        private IProgramareServiciuDAO _programareServiciuDAO;

        public ProgramareService(IProgramareDAO programareDAO,IServiciuDAO serviciuDAO,IProgramareServiciuDAO programareServiciuDAO)
        {
            _programareDAO = programareDAO;
            _serviciuDAO = serviciuDAO;
            _programareServiciuDAO = programareServiciuDAO;
        }

        public bool adaugareProgramare(String numeClient,String data,String ora,String telefon,List<String> servicii)
        {
            DateTime dataP;
            DateTime oraP;

            try
            {
                dataP = DateTime.ParseExact(data, "yyyy-MM-dd", null);
                oraP = DateTime.Parse(ora);
            }catch(FormatException e)
            {
                return false;
            }

            if (!esteNrTelefon(telefon) || servicii.Count == 0)
            {
                return false;
            }
            //verificare sa nu mai fie programari la aceeasi ora si cu aceleasi servicii sau cu un serviciu la fel.
            List<Programare> programari = listaProgramari(data);
            if(programari != null)
            {
                foreach(Programare programareV in programari)
                {
                    if(programareV.getOra() == oraP)
                    {
                        foreach(String serviciu in servicii)
                        {
                            foreach(Serviciu serviciuP in programareV.getServicii())
                            {
                                if (serviciu.Equals(serviciuP.getNume()))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }


            List<Serviciu> serviciiList = new List<Serviciu>();
            foreach(String numeServiciu in servicii)
            {
                Serviciu ser = _serviciuDAO.getServiciu(numeServiciu);
                serviciiList.Add(ser);
            }
            Programare programare = new Programare(numeClient, dataP, oraP, telefon, serviciiList);
            int id_servicii = _programareDAO.addProgramare(programare);
            if (id_servicii != -1)
            {
                foreach (Serviciu serviciu in programare.getServicii())
                {
                    ProgramareServiciu programareServiciu = new ProgramareServiciu(id_servicii, serviciu.getNume());
                    _programareServiciuDAO.addProgramareServicii(programareServiciu);
                }
            }

            return id_servicii != -1;
        }

        public List<Programare> listaProgramari(String data)
        {
            DateTime dataP = DateTime.ParseExact(data, "yyyy-MM-dd", null);
            List<Programare> programari = _programareDAO.getProgramari(dataP);
            if (programari != null)
            {
                foreach (Programare programare in programari)
                {
                    List<ProgramareServiciu> programareServiciuList = _programareServiciuDAO.selectServiciiClient(programare.getId());
                    List<Serviciu> servicii = new List<Serviciu>();
                    foreach (ProgramareServiciu programareServiciu in programareServiciuList)
                    {
                        Serviciu serv = _serviciuDAO.getServiciu(programareServiciu.getNumeServiciu());
                        servicii.Add(serv);
                    }
                    programare.setServicii(servicii);
                }
            }
            else
            {
                return null;
            }

            return programari;
        }

        public List<Programare> listaProgramariClient(String numeClient)
        {
            List<Programare> programari = _programareDAO.getProgramariClient(numeClient);
            if (programari != null)
            {
                foreach (Programare programare in programari)
                {
                    List<ProgramareServiciu> programareServiciuList = _programareServiciuDAO.selectServiciiClient(programare.getId());
                    List<Serviciu> servicii = new List<Serviciu>();
                    foreach (ProgramareServiciu programareServiciu in programareServiciuList)
                    {
                        Serviciu serv = _serviciuDAO.getServiciu(programareServiciu.getNumeServiciu());
                        servicii.Add(serv);
                    }
                    programare.setServicii(servicii);
                }
            }
            else
            {
                return null;
            }

            return programari;

        }

        private bool esteNrTelefon(String telefon)
        {
            return telefon.All(char.IsDigit);
        }
    }
}

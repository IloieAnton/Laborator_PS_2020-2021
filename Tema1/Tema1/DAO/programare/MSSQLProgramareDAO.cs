using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema1.Entities;

namespace Tema1.DAO.programare
{
    class MSSQLProgramareDAO : IProgramareDAO
    {
        private String _connectionString = @"Data Source=DESKTOP-2BQTDHD\SQLEXPRESS;Initial Catalog=salonA;Integrated Security=True";
        SqlConnection _conn = null;
   
        public MSSQLProgramareDAO()
        {
            try
            {
                _conn = new SqlConnection(_connectionString);

            }
            catch (SqlException e)
            {

                Console.WriteLine(e.Message);
                _conn = null;

            }

        }
        public int addProgramare(Programare programare)
        {

            String sql = "INSERT INTO programare(numeClient,data,ora,telefon)" + "output inserted.id_servicii " +" VALUES (@val1,@val2,@val3,@val4)";
            object obj;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@val1", programare.getNumeClient());
                cmd.Parameters.AddWithValue("@val2", programare.getData());
                cmd.Parameters.AddWithValue("@val3", programare.getOra());
                cmd.Parameters.AddWithValue("@val4", programare.getTelefon());

                 obj = cmd.ExecuteScalar();
               
                _conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            return Int32.Parse(obj.ToString()) ;
        }

        public List<Programare> getProgramari(DateTime data)
        {
            String sql = "SELECT * FROM programare WHERE data=@data";
            List<Programare> programari = new List<Programare>();
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@data", data);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                   
                    DateTime dataP = DateTime.Parse(reader["data"].ToString());
                    DateTime oraP =DateTime.Parse(reader["ora"].ToString());
                    Programare programare = new Programare(reader["numeClient"].ToString(),dataP,oraP, reader["telefon"].ToString(),null);
                    programare.setId(Int32.Parse(reader["id_servicii"].ToString()));
                    programari.Add(programare);
                }
                _conn.Close();
            }

            catch (SqlException e)

            {
                Console.WriteLine(e.Message);
                return null;
            }
            return programari;
        }

        public List<Programare> getProgramariClient(String numeClient)
        {
            String sql = "SELECT * FROM programare WHERE numeClient=@numeClient";
            List<Programare> programari = new List<Programare>();
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@numeClient",numeClient);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    DateTime dataP = DateTime.Parse(reader["data"].ToString());
                    DateTime oraP = DateTime.Parse(reader["ora"].ToString());
                    Programare programare = new Programare(reader["numeClient"].ToString(), dataP, oraP, reader["telefon"].ToString(), null);
                    programare.setId(Int32.Parse(reader["id_servicii"].ToString()));
                    programari.Add(programare);
                }
                _conn.Close();
            }

            catch (SqlException e)

            {
                Console.WriteLine(e.Message);
                return null;
            }
            return programari;

        }
    }
}

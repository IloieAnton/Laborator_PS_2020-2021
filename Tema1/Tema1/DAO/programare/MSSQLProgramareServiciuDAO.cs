using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema1.Entities;

namespace Tema1.DAO.programare
{
    public class MSSQLProgramareServiciuDAO : IProgramareServiciuDAO
    {
        private String _connectionString = @"Data Source=DESKTOP-2BQTDHD\SQLEXPRESS;Initial Catalog=salonA;Integrated Security=True";
        SqlConnection _conn = null;

        public MSSQLProgramareServiciuDAO()
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
        public bool addProgramareServicii(ProgramareServiciu programareServiciu)
        {
            String sql = "INSERT INTO programareServiciu(id,numeServiciu) VALUES (@val1,@val2)";
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@val1", programareServiciu.getId());
                cmd.Parameters.AddWithValue("@val2", programareServiciu.getNumeServiciu());

                cmd.ExecuteNonQuery();

                _conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public List<ProgramareServiciu> selectServiciiClient(int id)
        {
            List<ProgramareServiciu> programareServiciuList = new List<ProgramareServiciu>();
            String sql = "SELECT * FROM programareServiciu WHERE id=@id";

            try

            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProgramareServiciu programareServiciu = new ProgramareServiciu(Int32.Parse(reader["id"].ToString()), reader["numeServiciu"].ToString());
                    programareServiciuList.Add(programareServiciu);
                }
                _conn.Close();
            }

            catch (SqlException e)

            {
                Console.WriteLine(e.Message);
                return null;
            }
            return programareServiciuList;
        }
    }
}

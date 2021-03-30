using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema1.Entities;

namespace Tema1.DAO.serviciu
{
    class MSSQLServiciuDAO : IServiciuDAO
    {
        private String _connectionString = @"Data Source=DESKTOP-2BQTDHD\SQLEXPRESS;Initial Catalog=salonA;Integrated Security=True";
        SqlConnection _conn = null;

        public MSSQLServiciuDAO()
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
        public bool addServiciu(Serviciu serviciu)
        {
            String sql = "INSERT INTO serviciu(nume,pret) VALUES (@val1,@val2)";
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@val1", serviciu.getNume());
                cmd.Parameters.AddWithValue("@val2", serviciu.getPret());

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

        public bool deleteServiciu(string numeServiciu)
        {
            String sql = "DELETE FROM serviciu WHERE nume=@val1";
            object obj;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@val1", numeServiciu);

                obj = cmd.ExecuteNonQuery();

                _conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            if (Int32.Parse(obj.ToString()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Serviciu> getAllServicii()
        {
            String sql = "SELECT * FROM serviciu";
            List<Serviciu> servicii = new List<Serviciu>();
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);

                SqlDataReader reader = cmd.ExecuteReader();

                Serviciu serviciu = null;

                while(reader.Read())
                {
                     serviciu = new Serviciu(reader["nume"].ToString(), float.Parse(reader["pret"].ToString()));
                    servicii.Add(serviciu);
                }
                _conn.Close();
            }

            catch (SqlException e)

            {
                Console.WriteLine(e.Message);
                return null;
            }
            return servicii;
        }

        public bool updateServiciu(String nume, float pret)
        {
            String sql = "UPDATE serviciu SET pret=@pretNou WHERE nume=@numeServiciu";
            object obj;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@pretNou",pret );
                cmd.Parameters.AddWithValue("@numeServiciu", nume);

                obj = cmd.ExecuteNonQuery();

                _conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            if (Int32.Parse(obj.ToString()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public Serviciu getServiciu(String nume)
        {
            Serviciu ser = null;
            String sql = "SELECT * FROM serviciu WHERE nume=@numeServiciu";

            try

            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@numeServiciu", nume);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ser = new Serviciu(reader["nume"].ToString(), float.Parse(reader["pret"].ToString()));
                }
                _conn.Close();
            }

            catch (SqlException e)

            {
                Console.WriteLine(e.Message);
                return null;
            }
            return ser;
        }
    }
}

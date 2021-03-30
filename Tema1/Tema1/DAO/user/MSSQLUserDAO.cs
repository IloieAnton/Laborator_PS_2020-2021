using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema1.Entities;

namespace Tema1.DAO
{
    class MSSQLUserDAO : IUserDAO
    {
        private String _connectionString = @"Data Source=DESKTOP-2BQTDHD\SQLEXPRESS;Initial Catalog=salonA;Integrated Security=True";
        SqlConnection _conn = null;

        public MSSQLUserDAO()
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

        public User getUser(String username, String parola)
        {
            User u = null;
            String sql = "SELECT * FROM users WHERE username='" + username + "' AND parola='" + parola + "'";

            try

            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    u = new User(reader["username"].ToString(), reader["parola"].ToString(), reader["nume"].ToString(), reader["rol"].ToString());
                }
                _conn.Close();
            }

            catch (SqlException e)

            {
                Console.WriteLine(e.Message);
                return null;
            }
            return u;

        }

        public bool addUser(User user)
        {
            String sql = "INSERT INTO users(username,nume,parola,rol) VALUES (@val1,@val2,@val3,@val4)";
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@val1", user.getUsername());
                cmd.Parameters.AddWithValue("@val2", user.getNume());
                cmd.Parameters.AddWithValue("@val3", user.getParola());
                cmd.Parameters.AddWithValue("@val4", user.getRol());

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
    }
}

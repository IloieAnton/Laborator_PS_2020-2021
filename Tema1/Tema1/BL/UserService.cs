using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tema1.DAO;
using Tema1.Entities;

namespace Tema1.BL
{
   public class UserService
    {
        IUserDAO _userDAO;

        public UserService(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public User login(String username,String parola)
        {
            String parolaCriptata = getMd5Hash(parola);
            return _userDAO.getUser(username, parolaCriptata);
        }

        public bool adaugareUser(String username,String parola,String nume)
        {
            String parolaCriptata = getMd5Hash(parola);
            User u = new User(username, parolaCriptata, nume, "angajat");
            return _userDAO.addUser(u);
        }

        private static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object. 

            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash. 

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 

            // and create a string. 

            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  

            // and format each one as a hexadecimal string. 

            for (int i = 0; i < data.Length; i++)

            {

                sBuilder.Append(data[i].ToString("x2"));

            }

            // Return the hexadecimal string. 

            return sBuilder.ToString();
        }

    }
}

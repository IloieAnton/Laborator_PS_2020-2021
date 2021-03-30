using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema1.Entities;

namespace Tema1.DAO
{
    public interface IUserDAO
    {
        User getUser(String username,String parolaCriptata);
        bool addUser(User user);
    }
}

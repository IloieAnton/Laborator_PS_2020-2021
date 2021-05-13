using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalon.Models;

namespace WebSalon.DAL
{
    public interface IUnitOfWork
    {
        public void Save();
        public void Dispose();
    }
}

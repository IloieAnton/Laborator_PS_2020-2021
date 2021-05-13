using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSalon.Data;
using WebSalon.Models;

namespace WebSalon.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private WebSalonContext _context;
        private ProgramareRepository programareRepository;
        private GenericRepository<ProgramareServiciu> programareServiciuRepository;
        private GenericRepository<Serviciu> serviciuRepository;

        public UnitOfWork(WebSalonContext context)
        {
            _context = context;
        }
        public  ProgramareRepository ProgramareRepository
        {
            get
            {
                if(this.programareRepository == null)
                {
                    this.programareRepository = new ProgramareRepository(_context);
                }
                return programareRepository;
            }
        }

        public GenericRepository<Serviciu> ServiciuRepository
        {
            get
            {
                if (this.serviciuRepository == null)
                {
                    this.serviciuRepository = new GenericRepository<Serviciu>(_context);
                }
                return serviciuRepository;
            }
        }

        public GenericRepository<ProgramareServiciu> ProgramareServiciuRepository
        {
            get
            {
                if (this.programareServiciuRepository == null)
                {
                    this.programareServiciuRepository = new GenericRepository<ProgramareServiciu>(_context);
                }
                return programareServiciuRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    } 
}

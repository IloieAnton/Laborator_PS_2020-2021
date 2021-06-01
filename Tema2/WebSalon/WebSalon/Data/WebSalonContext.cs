using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFramework;
using WebSalon.Models;

namespace WebSalon.Data
{
    [System.Data.Entity.DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WebSalonContext : DbContext
    {

        public WebSalonContext(DbContextOptions<WebSalonContext> options)
           : base(options)
        {
        }

        public DbSet<Programare> Programare { get; set; }
        public DbSet<Serviciu> Serviciu { get; set; }
        public DbSet<ProgramareServiciu> ProgramareServiciu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramareServiciu>().HasKey(ps => new { ps.ProgramareId, ps.ServiciuId });
        }
    }
}

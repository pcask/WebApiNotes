using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Çalışan Assembly üzerinde bulunan bütün config dosyalarını bul ve Entity'lerimi oluştururken bu konfigurasyonları uygula.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
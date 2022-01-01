using EmployeeManagement.Data.Entities;
using EmployeeManagement.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data.EF
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
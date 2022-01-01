using EmployeeManagement.Data.EF;
using EmployeeManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data.Extensions
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var employeeList = new Employee[]
            {
                new Employee
                {
                    Id = 1,
                    Name = "Thomas Hardy",
                    Email = "thomashardy@mail.com",
                    Address = "89 Chiaroscuro Rd, Portland, USA",
                    Phone = "(171) 555-222",
                },
                new Employee
                {
                    Id = 2,
                    Name = "Dominique Perrier",
                    Email = "dominiqueperrier@mail.com",
                    Address = "Obere Str. 57, Berlin, Germany",
                    Phone = "(313) 555-5735",
                },
                new Employee
                {
                    Id = 3,
                    Name = "Maria Anders",
                    Email = "mariaanders@mail.com",
                    Address = "25, Rue lauriston, Paris, France",
                    Phone = "(503) 555-9931",
                },
                new Employee
                {
                    Id = 4,
                    Name = "Fran Wilson",
                    Email = "franwilson@mail.com",
                    Address = "C/ Araquil, 67, Marid, Spain",
                    Phone = "(204) 619-5731",
                },
                new Employee
                {
                    Id = 5,
                    Name = "Martin Blank",
                    Email = "martinblank@mail.com",
                    Address = "Via Monte Blanco 34, Turin, Italy",
                    Phone = "(480) 631-2097",
                },
            };

            modelBuilder.Entity<Employee>().HasData(employeeList);
        }

        public static void Seed(this ApplicationDbContext dbContext)
        {
            var employeeList = new Employee[]
            {
                new Employee
                {
                    Id = 6,
                    Name = "Thomas Hardy",
                    Email = "thomashardy@mail.com",
                    Address = "89 Chiaroscuro Rd, Portland, USA",
                    Phone = "(171) 555-222",
                },
                new Employee
                {
                    Id = 7,
                    Name = "Dominique Perrier",
                    Email = "dominiqueperrier@mail.com",
                    Address = "Obere Str. 57, Berlin, Germany",
                    Phone = "(313) 555-5735",
                },
                new Employee
                {
                    Id = 8,
                    Name = "Maria Anders",
                    Email = "mariaanders@mail.com",
                    Address = "25, Rue lauriston, Paris, France",
                    Phone = "(503) 555-9931",
                },
                new Employee
                {
                    Id = 9,
                    Name = "Fran Wilson",
                    Email = "franwilson@mail.com",
                    Address = "C/ Araquil, 67, Marid, Spain",
                    Phone = "(204) 619-5731",
                },
                new Employee
                {
                    Id = 10,
                    Name = "Martin Blank",
                    Email = "martinblank@mail.com",
                    Address = "Via Monte Blanco 34, Turin, Italy",
                    Phone = "(480) 631-2097",
                },
            };

            dbContext.AddRange(employeeList);

            dbContext.Database.OpenConnection();
            try
            {
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Employees ON;");
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Employees OFF");
            }
            finally
            {
                dbContext.Database.CloseConnection();
            }
        }
    }
}
using EmployeeManagement.Data.EF;
using EmployeeManagement.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagement.UnitTests.Common
{
    public static class InMemoryDb
    {
        public static ApplicationDbContext GetInMemoryDb()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new ApplicationDbContext(builder.Options);

            dbContext.Seed();

            return dbContext;
        }
    }
}
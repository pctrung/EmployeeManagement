using EmployeeManagement.Application.Services;
using EmployeeManagement.Data.EF;
using EmployeeManagement.Models.RequestModels.Employee;
using EmployeeManagement.UnitTests.Common;
using System;
using Xunit;

namespace EmployeeManagement.UnitTests.Application.Service
{
    public class EmployeeServiceTests
    {
        [Fact]
        public async void GetAll_ThereAreEmployees_ReturnNotEmptyList()
        {
            // Arrange
            ApplicationDbContext dbContext = InMemoryDb.GetInMemoryDb();

            var employeeService = new EmployeeService(dbContext);

            // Act
            var employeeList = await employeeService.GetAllAsync();

            // Assert
            Assert.NotEmpty(employeeList);
        }

        [Fact]
        public async void GetAll_ThereIsNoEmployee_ReturnEmptyList()
        {
            // Arrange
            ApplicationDbContext dbContext = InMemoryDb.GetInMemoryDb();
            dbContext.Employees.RemoveRange(dbContext.Employees);
            dbContext.SaveChanges();

            var employeeService = new EmployeeService(dbContext);

            // Act
            var employeeList = await employeeService.GetAllAsync();

            // Assert
            Assert.Empty(employeeList);
        }

        [Fact]
        public async void CreateEmployee_ValidRequest_ReturnNewId()
        {
            // Arrange
            ApplicationDbContext dbContext = InMemoryDb.GetInMemoryDb();

            var employeeService = new EmployeeService(dbContext);

            var request = new CreateEmployeeRequestModel()
            {
                Name = "Pham Chi Trung",
                Address = "Can Tho",
                Email = "phamchitrung.work@gmail.com",
                Phone = "0369 444 444"
            };

            // Act
            var newEmployeeId = await employeeService.CreateAsync(request);

            // Assert
            Assert.NotEqual(0, newEmployeeId);
        }

        [Fact]
        public async void CreateEmployee_InValidRequest_ReturnZero()
        {
            // Arrange
            ApplicationDbContext dbContext = InMemoryDb.GetInMemoryDb();

            var employeeService = new EmployeeService(dbContext);

            var request = new CreateEmployeeRequestModel() { };

            // Act
            var newEmployeeId = await employeeService.CreateAsync(request);

            // Assert
            Assert.Equal(0, newEmployeeId);
        }

        [Fact]
        public async void DeleteEmployee_ValidId_ReturnTrue()
        {
            // Arrange
            ApplicationDbContext dbContext = InMemoryDb.GetInMemoryDb();

            var employeeService = new EmployeeService(dbContext);

            var deleteId = 5;

            // Act
            var result = await employeeService.DeleteByIdAsync(deleteId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void DeleteEmployee_InvalidId_ReturnFalse()
        {
            // Arrange
            ApplicationDbContext dbContext = InMemoryDb.GetInMemoryDb();

            var employeeService = new EmployeeService(dbContext);

            var deleteId = 10;

            // Act
            var result = await employeeService.DeleteByIdAsync(deleteId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async void DeleteEmployee_ThereIsNoEmployee_ReturnFalse()
        {
            // Arrange
            ApplicationDbContext dbContext = InMemoryDb.GetInMemoryDb();
            dbContext.Employees.RemoveRange(dbContext.Employees);
            dbContext.SaveChanges();

            var employeeService = new EmployeeService(dbContext);

            var deleteId = 10;

            // Act
            var result = await employeeService.DeleteByIdAsync(deleteId);

            // Assert
            Assert.False(result);
        }
    }
}
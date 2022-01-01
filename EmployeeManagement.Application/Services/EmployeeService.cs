using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Data.EF;
using EmployeeManagement.Data.Entities;
using EmployeeManagement.Models.RequestModels.Employee;
using EmployeeManagement.Models.ViewModels.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
            var employeeViewModelList = await _dbContext.Employees
                .Select(x => new EmployeeViewModel() { Id = x.Id, Name = x.Name, Address = x.Address, Email = x.Email, Phone = x.Phone })
                .ToListAsync();

            return employeeViewModelList;
        }

        public async Task<int> CreateAsync(CreateEmployeeRequestModel request)
        {
            var newEmployee = new Employee()
            {
                Name = request.Name,
                Address = request.Address,
                Email = request.Email,
                Phone = request.Phone,
            };
            await _dbContext.AddAsync(newEmployee);
            await _dbContext.SaveChangesAsync();

            return newEmployee.Id;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var deleteEmployee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (deleteEmployee is null)
            {
                return false;
            }

            _dbContext.Remove(deleteEmployee);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
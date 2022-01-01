using EmployeeManagement.Data.Entities;
using EmployeeManagement.Models.RequestModels.Employee;
using EmployeeManagement.Models.ViewModels.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetAllAsync();

        Task<int> CreateAsync(CreateEmployeeRequestModel request);

        Task<bool> DeleteByIdAsync(int id);
    }
}
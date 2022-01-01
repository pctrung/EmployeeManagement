using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Models.RequestModels.Employee;
using EmployeeManagement.MVCSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EmployeeManagement.MVCSite.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employeeList = await _employeeService.GetAllAsync();

            return View(employeeList);
        }

        public IActionResult Create()
        {
            return PartialView("_CreateEmployeePartial");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _employeeService.CreateAsync(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView("_DeleteEmployeePartial", id);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAction(int id)
        {
            var isSuccessed = await _employeeService.DeleteByIdAsync(id);

            if (!isSuccessed)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
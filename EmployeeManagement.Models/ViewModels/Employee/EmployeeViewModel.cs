using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
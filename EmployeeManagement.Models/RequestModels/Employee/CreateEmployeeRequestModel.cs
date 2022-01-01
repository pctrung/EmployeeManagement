using EmployeeManagement.Utils.Contants;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.RequestModels.Employee
{
    public class CreateEmployeeRequestModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        [MaxLength(SystemConstants.MAX_LENGTH_NAME, ErrorMessage = "Your name is too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(SystemConstants.MAX_LENGTH_PHONE, ErrorMessage = "Your phone is too long")]
        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
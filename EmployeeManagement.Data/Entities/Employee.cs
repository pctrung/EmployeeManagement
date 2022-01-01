using EmployeeManagement.Utils.Contants;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Data.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(SystemConstants.MAX_LENGTH_NAME)]
        public string Name { get; set; }

        [MaxLength(SystemConstants.MAX_LENGTH_PHONE)]
        public string Phone { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
    }
}
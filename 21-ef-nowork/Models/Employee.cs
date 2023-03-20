using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Leave Balance")]
        public float LeaveBalance { get; set; }
        //{ 
        //    get { return LeaveBalance; }
        //    set { LeaveBalance = value; }
        //}
    }
}

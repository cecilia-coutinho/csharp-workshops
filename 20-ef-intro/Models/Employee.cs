using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFirstEntity.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(60)]
        public string Email { get; set; }
        [StringLength(40)]
        public string Address { get; set; }
    }
}

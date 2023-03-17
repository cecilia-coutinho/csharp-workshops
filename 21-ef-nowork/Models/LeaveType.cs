using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Models
{
    public class LeaveType
    {
        [Key]
        public int LeaveTypeId { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Leave Type Name")]
        public string LeaveTypeName { get; set; }
        [StringLength(120)]
        [DisplayName("Leave Type Description")]
        public string LeaveTypeDescription { get; set; }
    }
}

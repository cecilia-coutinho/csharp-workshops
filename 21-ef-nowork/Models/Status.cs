using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        [Required]
        [StringLength(15)]
        [DisplayName("Status")]
        public string StatusName { get; set; }
    }
}

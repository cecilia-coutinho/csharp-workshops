using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Models
{
    public class LeaveRequest
    {
        [Key]
        public int LeaveRequestId { get; set; }
        public int FkEmployeeId { get; set; }
        public int FkLeaveTypeId { get; set; }

        [Required]
        public DateTime RequestStartDate { get; set; }

        [Required]
        public DateTime RequestEndDate { get; set; }
        public float RequestedDays
        {
            get
            {
                TimeSpan span = RequestEndDate - RequestStartDate;
                return (float)span.TotalDays + 1;
            }
        }
        public int FkStatusId { get; set; }
    }
}

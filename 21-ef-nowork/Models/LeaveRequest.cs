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
        [Required]
        public DateTime RequestStartDate { get; set; }

        [Required]
        public DateTime RequestEndDate { get; set; }

        public float RequestedDays { get; set; }
        //public float RequestedDays
        //{
        //    get
        //    {
        //        TimeSpan span = RequestEndDate - RequestStartDate;
        //        return (float)span.TotalDays + 1;
        //    }
        //}
        [Required]
        public int FkEmployeeId { get; set; }

        [Required]
        public int FkLeaveTypeId { get; set; }

        [Required]
        public int FkStatusId { get; set; }
        public DateTime RequestCreatedOn { get; set; } = DateTime.Now;
        public virtual Employee Employees { get; set; }
        public virtual LeaveType LeaveTypes { get; set; }
        public virtual Status StatusList { get; set; }
    }
}

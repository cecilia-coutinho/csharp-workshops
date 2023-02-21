using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop16DbCsharp
{
    internal class CourseModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int points { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }
}

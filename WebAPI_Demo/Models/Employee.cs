using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_Demo.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string EmployeeLocation { get; set; }
    }
}

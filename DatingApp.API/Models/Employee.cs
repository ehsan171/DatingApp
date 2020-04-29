using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }

        

        public virtual ICollection<EmployeeProject> EmployeeProject {get; set; }
    }
}
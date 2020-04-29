using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDetail { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProject {get; set; }
    }
}
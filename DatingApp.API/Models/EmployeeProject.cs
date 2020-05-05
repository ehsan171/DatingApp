using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DatingApp.API.Models
{
    public class EmployeeProject
    {
        // [Key]
        // [Column(Order=1)]
        public int EmployeeId {get; set; }

        // [Key]
        // [Column(Order=2)]
        public int ProjectId { get; set; }

        public virtual Employee Employee  { get; set; }
        public virtual Project Project  { get; set; }
        // public string EmployeeName { get; set; }
        // public string ProjectName { get; set; }

    }
}
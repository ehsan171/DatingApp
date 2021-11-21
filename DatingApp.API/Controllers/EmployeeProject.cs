using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectController: ControllerBase
    {
        
        private readonly DataContext _context;

        public EmployeeProjectController(DataContext context)
        {
            _context = context;
        }

        // GET api/stydent
        [HttpGet]
        public  IActionResult GetValues()
        {
           

   
            var Employee = _context.Employee
            .Include(u => u.EmployeeProject)
            .ThenInclude(u => u.Project)
            .ToList();

            var department = Employee[0].EmployeeProject
            .Select(x => x.Employee.EmployeeName);
            var d2 =Employee[0].EmployeeProject
            .Select(x => x.Project.ProjectName);
            var a = department.Concat(d2).ToList();
    //         Dictionary<string, string> LoaderArray = new Dictionary<string, string>
    // {
    //     {"Emploee","hhh" },
    //     {"Project",""}
        
    // };

    
  


    
            //   string query = "SELECT * FROM EmployeeProject FROM     EmployeeProject";
            // var department =  _context.EmployeeProject
            // .FromSqlRaw(query).ToList();


            // return View(department);
            // var students = await _context.EmployeeProject.ToListAsync();
            
            
            return  new ObjectResult(a);;
            
        }

       
    }
}
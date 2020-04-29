using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.API.Controllers
{

    public class EmployeeController: ControllerBase
    {
        
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        // GET api/employees
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            // await _context.Genres.AddAsync(new Genre() { Name = "Dutch Golden Age Painting" });
            // await _context.Genres.AddAsync(new Genre() { Name = "Early Renaissance" });
            // await _context.SaveChangesAsync();
          
            // user.Username = "jjj";
            // await _context.Users.AddAsync(user);
            // await _context.SaveChangesAsync();

            // return user;
            var employees = await _context.Employee.ToListAsync();
            return Ok(employees);
            
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(x => x.EmployeeId == id);
            return Ok(employee);
        }
    }
}
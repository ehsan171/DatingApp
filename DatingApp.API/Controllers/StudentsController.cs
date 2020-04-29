using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController: ControllerBase
    {
         private readonly DataContext _context;

        public StudentsController(DataContext context)
        {
            _context = context;
        }

        // GET api/stydents
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            return Ok(student);
        }
    
    }
}
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.API.Controllers
{

    public class ProjectController: ControllerBase
    {
        
        private readonly DataContext _context;

        public ProjectController(DataContext context)
        {
            _context = context;
        }

        // GET api/Project
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var projects = await _context.Project.ToListAsync();
            return Ok(projects);
            
        }

        // GET api/Project/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var project = await _context.Project.FirstOrDefaultAsync(x => x.ProjectId == id);
            return Ok(project);
        }
    }
}
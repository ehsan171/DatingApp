using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasicDataController: ControllerBase
    {
        private readonly DataContext _context;
        public BasicDataController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("formats")]
        public async Task<IActionResult> GetFormats()
        {
            var formats = await _context.BasicDatas
            .Where(format => format.Type == "2")
            .Select(x => new{
                Id = x.Id,
                Name = x.Name,
            } )
            .ToListAsync();
            
            return Ok(formats);
        }
        
        [AllowAnonymous]
        [HttpGet("statuses")]
        public async Task<IActionResult> GetStatuses()
        {
            var statuses = await _context.Statuses
            .Select(x => new{
                Id = x.Id,
                Name = x.Name,
            } )
            .ToListAsync();
            
            return Ok(statuses);
        }
        
        [AllowAnonymous]
        [HttpGet("genres")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _context.BasicDatas
            .Where(genre => genre.Type == "1")
            .Select(x => new{
                Id = x.Id,
                Name = x.Name,
            } )
            .ToListAsync();
            
            return Ok(genres);
        }
        
    }
}
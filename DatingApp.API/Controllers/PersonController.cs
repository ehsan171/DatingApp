using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
     [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonController(DataContext context)
        {
            _context = context;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTusers()
        {
            var values = await _context.Persons.ToListAsync();
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTusers(int id)
        {
            var value = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // POST api/tusers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/tuser/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/tusers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

  

}
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        
        private readonly DataContext _context;

        public BooksController(DataContext context)
        {
            _context = context;
        }

        // GET api/books
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(book);
        }

    }
}
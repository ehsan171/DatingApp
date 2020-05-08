using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenplayController : ControllerBase
     {
        private readonly DataContext _context;
           private readonly IScreenplayRepository _repo;
        private readonly IConfiguration _config;
        public ScreenplayController(DataContext context,IScreenplayRepository repo, IConfiguration config)
        {
            _context = context;
            _config = config;
            _repo = repo; 
        }

      
      


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetScreenplays()
        {
            var screenplays = await _context.Screenplays
            // .Include(p => p.Status)
            // .Include(or => or.OrgStructure)
            // .Include(o => o.Episodes).ThenInclude(w => w.EpisodeWriters)
            // .Include(p => p.ScreenplayGenres).ThenInclude(g => g.BasicData)
            // .Include(p => p.ScreenplayFormats).ThenInclude(g => g.BasicData)
            // .Include(p => p.ScreenplayProducers).ThenInclude(g => g.Producer)
            .Select(x => new { 
                                Title = x.Title,
                                OrgStructure = x.OrgStructure.Name,
                                Status = x.Status.Name,
                                EpisodeTitles = x.Episodes.Select(s => 
                                
                                new{
                                    title =  s.EpisodeTitle,
                                    writer = s.EpisodeWriters.Select(w => w.Writer).Select(a => new {
                                                FirstName = a.FirstName,
                                                LastName = a.LastName}),
                                    concept = s.EpisodeConcepts.Select(w => w.BasicData).Select(a => new {
                                                conceptName = a.Name,}),

                                } ),
                                Genre = x.ScreenplayGenres.Select(s => s.BasicData).Select(g => g.Name),
                                Producers = x.ScreenplayProducers
                                    .Select(s => s.Producer)
                                        .Select(g => new {
                                            FirstName = g.FirstName,
                                            LastName = g.LastName,
                                        }),
                                Writers = x.Episodes
                                    .Select(s => s.EpisodeWriters
                                        .Select(w => w.Writer)
                                            .Select(a => new {
                                                FirstName = a.FirstName, LastName = a.LastName
                                })),
                                Concept = x.Episodes
                                    .Select(s => s.EpisodeConcepts
                                        .Select(w => w.BasicData)
                                            .Select(a => new {
                                                ConceptName = a.Name,
                                                
                                })),

  })
     
            .ToListAsync();
            return Ok(screenplays);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScreenplays(int id)
        {
            var screenplay = await _context.Screenplays.Where(screenplay => screenplay.Id == id)
            // .Include(p => p.Status)
            // .Include(or => or.OrgStructure)
            // .Include(o => o.Episodes).ThenInclude(w => w.EpisodeWriters)
            // .Include(p => p.ScreenplayGenres).ThenInclude(g => g.BasicData)
            // .Include(p => p.ScreenplayFormats).ThenInclude(g => g.BasicData)
            // .Include(p => p.ScreenplayProducers).ThenInclude(g => g.Producer)
            .Select(x => new { 
                                Title = x.Title,
                                OrgStructure = x.OrgStructure.Name,
                                Status = x.Status.Name,
                                EpisodeTitles = x.Episodes.Select(s => new {
                                            EpisodeTitle = s.EpisodeTitle
                                        }),
                                Genre = x.ScreenplayGenres.Select(s => s.BasicData).Select(g => g.Name),
                                Producers = x.ScreenplayProducers
                                    .Select(s => s.Producer)
                                        .Select(g => new {
                                            FirstName = g.FirstName,
                                            LastName = g.LastName,
                                        }),
                                Writers = x.Episodes
                                    .Select(s => s.EpisodeWriters
                                        .Select(w => w.Writer)
                                            .Select(a => new {
                                                FirstName = a.FirstName,
                                                LastName = a.LastName,
                                })),
                                Concept = x.Episodes
                                    .Select(s => s.EpisodeConcepts
                                        .Select(w => w.BasicData)
                                            .Select(a => new {
                                                ConceptName = a.Name,
                                                
                                })),

  })
     
            .ToListAsync();
            
            return Ok(screenplay);
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

            [AllowAnonymous]
         [HttpPost("register")]
        public async Task<IActionResult> Register(ScreenplayForRegisterDto userForRegisterDto)
        {
            // validate request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if (await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already ex...");

            
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username,
                photoUrl = userForRegisterDto.photoUrl,

            };

            var studentToCreate = new Student
            {
                Name =userForRegisterDto.name
            };
            
            var screenplayToCreate = new Screenplay
            {
                Title =userForRegisterDto.Title
            };
            

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
            var createdStudent = await _repo.RegisterStudent(studentToCreate);
            var createdS = await _repo.RegisterScreenplay(screenplayToCreate);
            return StatusCode(201);
        }

        
    }

}
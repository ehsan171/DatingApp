using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

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

    //   [AllowAnonymous]
      [HttpGet("test")]

      public async Task<IActionResult> GetTests()
        {
             var identity = (ClaimsIdentity)User.Identity;
  Console.WriteLine( User.Identity.Name);

Console.WriteLine(identity.FindFirst("OrgId").Value);
            var screenplays = await _context.ScreenplayOrgStructures
            .Where(s =>s.OrgStructure.OrgId == int.Parse(identity.FindFirst("OrgId").Value) |  ( int.Parse(identity.FindFirst("OrgId").Value) == 0 ))

            .Select(x => new { 
                                OrgStructure = x.OrgStructure,
                                OrgStructureId = x.OrgStructureId,
                                Status = x.Screenplay.Status.Name,
                                BaravordNo = x.Screenplay.BaravordNo,
                                Title = x.Screenplay.Title,
                                Id = x.Screenplay.Id,
                                RegDate = x.Screenplay.RegDate,
                                TotalNumberEpisodes =x.Screenplay.TotalNumberEpisodes,
                                Producers = x.Screenplay.ScreenplayProducers.Select(s => s.Producer)
                                        .Select(g => g.FirstName + ' ' + g.LastName ),
                                Format = x.Screenplay.ScreenplayFormats.Select(s => s.BasicData).Select(g => g.Name),
                                Genre = x.Screenplay.ScreenplayGenres.Select(s => s.BasicData).Select(g => g.Name),
                                EpisodeTitle = x.Screenplay.Episodes.Select(s => 
                                
                                new{
                                    title =  s.EpisodeTitle,
                                    writer = s.EpisodeWriters.Select(w => w.Writer).Select(a => new {
                                                FirstName = a.FirstName,
                                                LastName = a.LastName}),
                                    concept = s.EpisodeConcepts.Select(w => w.BasicData).Select(a => new {
                                                conceptName = a.Name,}),

                                } ),
                                Writers = x.Screenplay.Episodes
                                    .Select(s => s.EpisodeWriters
                                        .Select(w => w.Writer)
                                            .Select(a => 
                                               a.FirstName + ' ' + a.LastName
                                )),
                                 Concept = x.Screenplay.Episodes
                                    .Select(s => s.EpisodeConcepts
                                        .Select(w => w.BasicData)
                                            .Select(a => new {
                                                ConceptName = a.Name,
                                                
                                })),
                                ScreenplayId = x.ScreenplayId,
                           
                                
  })
     
            .ToListAsync();
            return Ok(screenplays);
        }


      [AllowAnonymous]
      [HttpGet("test/{id}")]

      public async Task<IActionResult> GetTest(int id)
        {
            var screenplays = await _context.ScreenplayOrgStructures.Where(s => s.OrgStructureId == 1 )

            .Select(x => new { 
                                OrgStructure = x.OrgStructure,
                                OrgStructureId = x.OrgStructureId,
                                Status = x.Screenplay.Status.Name,
                                BaravordNo = x.Screenplay.BaravordNo,
                                Title = x.Screenplay.Title,
                                RegDate = x.Screenplay.RegDate,
                                TotalNumberEpisodes =x.Screenplay.TotalNumberEpisodes,
                                ScreenplayProducers = x.Screenplay.ScreenplayProducers.Select(s => s.Producer)
                                        .Select(g => g.FirstName + ' ' + g.LastName ),
                                Formats = x.Screenplay.ScreenplayFormats.Select(s => s.BasicData).Select(g => g.Name),
                                Genres = x.Screenplay.ScreenplayGenres.Select(s => s.BasicData).Select(g => g.Name),
                                EpisodeTitle = x.Screenplay.Episodes.Select(s => 
                                
                                new{
                                    title =  s.EpisodeTitle,
                                    writer = s.EpisodeWriters.Select(w => w.Writer).Select(a => new {
                                                FirstName = a.FirstName,
                                                LastName = a.LastName}),
                                    concept = s.EpisodeConcepts.Select(w => w.BasicData).Select(a => new {
                                                conceptName = a.Name,}),

                                } ),
                                Writers = x.Screenplay.Episodes
                                    .Select(s => s.EpisodeWriters
                                        .Select(w => w.Writer)
                                            .Select(a => 
                                               a.FirstName + ' ' + a.LastName
                                )),
                                 Concept = x.Screenplay.Episodes
                                    .Select(s => s.EpisodeConcepts
                                        .Select(w => w.BasicData)
                                            .Select(a => new {
                                                ConceptName = a.Name,
                                                
                                })),

                                ScreenplayId = x.ScreenplayId,
                                
  })
     
            .ToListAsync();
            return Ok(screenplays);
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
                                id = x.Id,
                                BaravordNo = x.BaravordNo,
                                Title = x.Title,
                                RegDate = x.RegDate,
                                TotalNumberEpisodes =x.TotalNumberEpisodes,
                                // OrgStructure = x.OrgStructure.Name,
                                OrgStructure = x.screenplayOrgStructures.Select(s => s.OrgStructure).Select(g => g.Name),
                                OrgId = x.screenplayOrgStructures.Select(s => s.OrgStructure).Where(org => org.OrgId == 1).Select(g => g.Name),
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
                                Format = x.ScreenplayFormats.Select(s => s.BasicData).Select(g => g.Name),
                                Producers = x.ScreenplayProducers
                                    .Select(s => s.Producer)
                                        .Select(g => g.FirstName + ' ' + g.LastName ),
                                Writers = x.Episodes
                                    .Select(s => s.EpisodeWriters
                                        .Select(w => w.Writer)
                                            .Select(a => 
                                               a.FirstName + ' ' + a.LastName
                                )),
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
            // var identity = (ClaimsIdentity)User.Identity;
            Console.WriteLine("ddddddddddddddd");
            var screenplay = await _context.Screenplays.Where(screenplay => screenplay.Id == id)
            // .Include(p => p.Status)
            // .Include(or => or.OrgStructure)
            // .Include(o => o.Episodes).ThenInclude(w => w.EpisodeWriters)
            // .Include(p => p.ScreenplayGenres).ThenInclude(g => g.BasicData)
            // .Include(p => p.ScreenplayFormats).ThenInclude(g => g.BasicData)
            // .Include(p => p.ScreenplayProducers).ThenInclude(g => g.Producer)
              .Select(x => new { 
                                id = x.Id,
                                BaravordNo = x.BaravordNo,
                                Title = x.Title,
                                RegDate = x.RegDate,
                                TotalNumberEpisodes =x.TotalNumberEpisodes,
                                // OrgStructure = x.OrgStructure.Name,
                                OrgStructure = x.screenplayOrgStructures.Select(s => s.OrgStructure).Select(g => g.Name),
                                OrgId = x.screenplayOrgStructures.Select(s => s.OrgStructure).Select(g => g.Name),
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
                                Format = x.ScreenplayFormats.Select(s => s.BasicData).Select(g => g.Name),
                                Producers = x.ScreenplayProducers
                                    .Select(s => s.Producer)
                                        .Select(g => g.FirstName + ' ' + g.LastName ),
                                Writers = x.Episodes
                                    .Select(s => s.EpisodeWriters
                                        .Select(w => w.Writer)
                                            .Select(a => 
                                               a.FirstName + ' ' + a.LastName
                                )),
                                Concept = x.Episodes
                                    .Select(s => s.EpisodeConcepts
                                        .Select(w => w.BasicData)
                                            .Select(a => new {
                                                ConceptName = a.Name,
                                                
                                })),

  })
     
            .ToListAsync();
            bool isEmpty = !screenplay[0].OrgId.Any();
            
            if(!isEmpty ){
                return Ok(screenplay);
            }
            else{
                 return Ok();
            }
            
           
        }

  [AllowAnonymous]
        [HttpGet("episode/{id}")]
        public async Task<IActionResult> Episode(int id)
        {

           var value = await _context.Episodes.Include(p => p.EpisodeWriters).Where(screenplay => screenplay.ScreenplayId == id)
           .Select(x => new { 
               EpisodeNumber = x.EpisodeNumber,
               EpisodeTitle = x.EpisodeTitle,
               Url = x.Url,
               Writers = x.EpisodeWriters
                        .Select(W => W.Writer)
                        .Select(a => a.FirstName + ' ' + a.LastName),
              Concept = x.EpisodeConcepts.Select(s => s.BasicData).Select(g => g.Name),
                                
                                    
           })
           
           .ToListAsync();
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

            [AllowAnonymous]
         [HttpPost("register")]
        public async Task<IActionResult> Register(ScreenplayForRegisterDto screenplayForRegisterDto)
        { 
            // validate request
            screenplayForRegisterDto.Title = screenplayForRegisterDto.Title.ToLower();
            if (await _repo.ScreenplayExists(screenplayForRegisterDto.Title))
                return BadRequest("فیلمنامه ای با این عنوان قبلا ثبت شده است");
            
            var screenplayToCreate = new Screenplay
            {
                Title =screenplayForRegisterDto.Title,
                BaravordNo =screenplayForRegisterDto.BaravordNo,
                StatusId =screenplayForRegisterDto.StatusId,
                TotalNumberEpisodes =screenplayForRegisterDto.TotalNumberEpisodes,
                RegDate = screenplayForRegisterDto.RegDate
            };
            Console.WriteLine(screenplayForRegisterDto.OrgStructure[0]);
            
            Dictionary<string, object> otherData = new Dictionary<string,object>();
            otherData.Add("Genres", screenplayForRegisterDto.Genre);
            otherData.Add("Producers", screenplayForRegisterDto.Producer);
            otherData.Add("Formats", screenplayForRegisterDto.Format);
            otherData.Add("OrgStructures", screenplayForRegisterDto.OrgStructure);


          var createdS = await _repo.RegisterScreenplay(screenplayToCreate,  otherData);

            // return StatusCode(201);
            return StatusCode(201, new {
    data = new { id = screenplayToCreate.Id }
});
        }

        [AllowAnonymous]
        [HttpGet("formatReport")]
        public async Task<IActionResult> GetScreenplaysFormatReport()
        {
           


     var formatReport = await _context.ScreenplayFormats.Include(p => p.BasicData).GroupBy(p => p.BasicDataId)
           .Select(x => new { 
               FormatNumber = x.Count(),
               FormatKey = x.Key,
              
                // FormatName = x.BasicData                
                                    
           })
           
           .ToListAsync();
            return Ok(formatReport);
            
        }

        [AllowAnonymous]
        [HttpGet("statusReport")]
        public async Task<IActionResult> GetScreenplaysStatusReport()
        {
           


     var statusReport = await _context.Screenplays.GroupBy(p => p.StatusId)
           .Select(x => new { 
               StatusNumber = x.Count(),
               StatusKey = x.Key,
              
                // FormatName = x.BasicData                
                                    
           })
           
           .ToListAsync();
            return Ok(statusReport);
            
        }



        
    }

}
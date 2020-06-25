using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

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
        
        [AllowAnonymous]
        [HttpGet("concepts")]
        public async Task<IActionResult> GetConcepts()
        {
            
            var concepts = await _context.BasicDatas
            .Where(concept => concept.Type == "3")
            .Select(x => new{
                Id = x.Id,
                Name = x.Name,
                Parent = x.Parent
            } )
            .ToListAsync();
            
            return Ok(concepts);
        }
        
        [AllowAnonymous]
        [HttpGet("orgs")]
        public async Task<IActionResult> GetOrgs()
        {
            
            var orgs = await _context.OrgStructures
           
            .Select(x => new{
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId,
                IsInner = x.IsInner,
                OrgId = x.OrgId
            } )
            .ToListAsync();
            
            return Ok(orgs);
        }
        
    }
}
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
        [HttpGet("groups/{parentId}")]
        public async Task<IActionResult> GetGroups(int parentId)
        {
            var groups = await _context.BasicDatas
            .Where(group => group.Type == "1" && group.Parent==parentId)
            .Select(x => new{
                Id = x.Id,
                Name = x.Name,
            } )
            .ToListAsync();
            
            return Ok(groups);
        }
        
        [AllowAnonymous]
        [HttpGet("orgIds")]
        public async Task<IActionResult> GetOrgIds()
        {
            Console.WriteLine("2xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            var orgIds = await _context.BasicDatas
            .Where(orgId => orgId.Type == "4" & orgId.Parent == null)
            .Select(x => new{
                Id = x.Id,
                Name = x.Name,
            } )
            .ToListAsync();
           Console.WriteLine("eweweweweeweweweweweee");

            return Ok(orgIds);
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
            
            var orgs = await _context.BasicDatas
            .Where(concept => concept.Type == "4")
            .Select(x => new{
                Id = x.Id,
                Name = x.Name,
                ParentId = x.Parent,
                IsInner = 1,
                //OrgId = x.ItemID
            } )
            .ToListAsync();
            
            return Ok(orgs);
        }
        
    }
}
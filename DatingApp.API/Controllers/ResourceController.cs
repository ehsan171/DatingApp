using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IScreenplayRepository _repo;
        private readonly IConfiguration _config;

        public ResourceController(DataContext context,IScreenplayRepository repo, IConfiguration config)
        {
            _context = context;
            _config = config;
            _repo = repo; 
        }
      
        [AllowAnonymous]
        [HttpGet("getAllResources")]

        public async Task<IActionResult> GetAllResources()
        {
            var identity = (ClaimsIdentity)User.Identity;
      
            var resources = await _context.Resources
            
                .Select(x => new { 
                    Id = x.ResourceId,
                    Title = x.Title,
                    
                })
     
                .ToListAsync();
            
            return Ok(resources);
        }

       [AllowAnonymous]
        [HttpGet("getResource/{resourceId}")]

        public async Task<IActionResult> GetResource(int resourceId)
        {
            var identity = (ClaimsIdentity)User.Identity;
      
            var resources = await _context.Resources
                .Where(resource => resource.ResourceId == resourceId)
                .Select(x => new { 
                    Id = x.ResourceId,
                    Title = x.Title,
                    Capacity = x.Capacity,
                    Unit = x.BasicData.Name
                    
                })
                    
     
                .ToListAsync();
            
            return Ok(resources);
        }

       
    }
}
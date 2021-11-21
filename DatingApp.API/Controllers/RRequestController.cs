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
    public class RRequestController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IScreenplayRepository _repo;
        private readonly IConfiguration _config;

        public RRequestController(DataContext context,IScreenplayRepository repo, IConfiguration config)
        {
            _context = context;
            _config = config;
            _repo = repo; 
        }
        [AllowAnonymous]
        [HttpGet("getAllRRequests")]

        public async Task<IActionResult> GetAllRRequests()
        {
            var identity = (ClaimsIdentity)User.Identity;
            Console.WriteLine(identity.IsAuthenticated); 
            var rRequests = await _context.RRequests
                
                .Select(x => new { 
                 
                    Status = x.Barname.Status.Name,
                    BarnameTitle = x.Barname.Title,
                    RRequestTitle = x.Title,
                    Id = x.Barname.Id,
                    RegDate = x.Barname.RegDate,
                    Producers = x.Barname.BarnameProducers.Select(s => s.Producer)
                        .Select(g => g.FirstName + ' ' + g.LastName ),
                    Group = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Name),
                    GroupID = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Id),
                    Network = x.Barname.BarnameNetworks.Select(s => s.BasicData).Select(g => g.Name)
                      
                           
                                
                })
     
                .ToListAsync();
            
            return Ok(rRequests);
        }

        [AllowAnonymous]
        [HttpGet("getAllRRequestsByGroup/{groupId}")]

        public async Task<IActionResult> GetAllRRequestsByGroup(int groupId)
        {
            var identity = (ClaimsIdentity)User.Identity;
            Console.WriteLine(identity.IsAuthenticated); 
            var rRequests = await _context.RRequests
                
                .Select(x => new { 
                 
                    Status = x.Barname.Status.Name,
                    BarnameTitle = x.Barname.Title,
                    RRequestTitle = x.Title,
                    Id = x.Barname.Id,
                    RegDate = x.Barname.RegDate,
                    Producers = x.Barname.BarnameProducers.Select(s => s.Producer)
                        .Select(g => g.FirstName + ' ' + g.LastName ),
                    Group = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Name),
                    GroupID = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Id),
                    Network = x.Barname.BarnameNetworks.Select(s => s.BasicData).Select(g => g.Name)
                      
                           
                                
                }).Where(s => s.GroupID.Contains(groupId))
     
                .ToListAsync();
            
            return Ok(rRequests);
        }

       
    }
}
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
    public class BarnameController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IScreenplayRepository _repo;
        private readonly IConfiguration _config;

        public BarnameController(DataContext context,IScreenplayRepository repo, IConfiguration config)
        {
            _context = context;
            _config = config;
            _repo = repo; 
        }
       [AllowAnonymous]
       [HttpGet("getAllBarnames")]

      public async Task<IActionResult> GetAllBarnames()
        {
             var identity = (ClaimsIdentity)User.Identity;
             Console.WriteLine(identity.IsAuthenticated); 
            var barnames = await _context.BarnameNetworks
            
            .Select(x => new { 
                                Network = x.BasicData.Name,
                                NetworkId = x.BasicDataId,
                                Status = x.Barname.Status.Name,
                                Title = x.Barname.Title,
                                Id = x.Barname.Id,
                                RegDate = x.Barname.RegDate,
                                Producers = x.Barname.BarnameProducers.Select(s => s.Producer)
                                        .Select(g => g.FirstName + ' ' + g.LastName ),
                                Group = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Name)
                      
                           
                                
   })
     
            .ToListAsync();
            
            return Ok(barnames);
        }

       [AllowAnonymous]
       [HttpGet("getAllBarnamesByGroup/{groupId}")]

      public async Task<IActionResult> GetAllBarnamesByGroup(int groupId)
        {
             var identity = (ClaimsIdentity)User.Identity;
             Console.WriteLine(identity.IsAuthenticated); 
            var barnames = await _context.BarnameNetworks
            
            .Select(x => new { 
                                Network = x.BasicData.Name,
                                NetworkId = x.BasicDataId,
                                Status = x.Barname.Status.Name,
                                Title = x.Barname.Title,
                                Id = x.Barname.Id,
                                RegDate = x.Barname.RegDate,
                                Producers = x.Barname.BarnameProducers.Select(s => s.Producer)
                                        .Select(g => g.FirstName + ' ' + g.LastName ),
                                Group = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Name),
                                GroupID = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Id),

                           
                                
   }).Where(s => s.GroupID.Contains(groupId))

     
            .ToListAsync();
            
            return Ok(barnames);
        }

       
       [AllowAnonymous]
       [HttpGet("getBarnameById/{id}")]

      public async Task<IActionResult> GetBarnameById(int id)
        {
             var identity = (ClaimsIdentity)User.Identity;
            var barnames = await _context.BarnameNetworks
            
            .Select(x => new { 
                                Network = x.BasicData.Name,
                                NetworkId = x.BasicDataId,
                                Status = x.Barname.Status.Name,
                                Title = x.Barname.Title,
                                Id = x.Barname.Id,
                                BaravordNo = x.Barname.BaravordNo,
                                RegDate = x.Barname.RegDate,
                                Producers = x.Barname.BarnameProducers.Select(s => s.Producer)
                                        .Select(g => g.FirstName + ' ' + g.LastName ),
                                Group = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Name),
                                GroupID = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Id),

                           
                                
   }).Where(s => s.Id==id)

     
            .ToListAsync();
            
            return Ok(barnames);
        }

       
    }
}
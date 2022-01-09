using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
 
    public class AllocationController: ControllerBase
    {
        private readonly DataContext _context;
        private readonly IAllocationRepository _repo;
        private readonly IConfiguration _config;
        public AllocationController(DataContext context,IAllocationRepository repo, IConfiguration config)
        {
            _context = context;
            _config = config;
            _repo = repo; 
        }
        
        [AllowAnonymous]
        [HttpGet("getAllAllocations")]

        public async Task<IActionResult> GetAllAllocations()
        {
            var identity = (ClaimsIdentity)User.Identity;
            Console.WriteLine(identity.IsAuthenticated); 
            var allocations = await _context.Allocations
            
                .Select(x => new { 
                    ResourceName = x.Resource.Title,
                    x.Resource.ResourceId,
                    x.Day,
                    x.Month,
                    x.Year,
                    x.Hour,
                    x.Barname.Title,
                    x.Barname.Id,
                  
                    Producers = x.Barname.BarnameProducers.Select(s => s.Producer)
                        .Select(g => g.FirstName + ' ' + g.LastName ),
                    Group = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Name)
                      
                           
                                
                })
     
                .ToListAsync();
            
            return Ok(allocations);
        }

        [AllowAnonymous]
        [HttpGet("GetAllAllocationsByResourceYearMonth/{resourceId:int}/{year:int}/{month:int}")]

        public async Task<IActionResult> GetAllAllocationsByResourceYearMonth(int resourceId, int year, int month)
        {
           
            var identity = (ClaimsIdentity)User.Identity;
            Console.WriteLine(identity.IsAuthenticated); 
            var allocations = await _context.Allocations
            
                .Where(allocation => 
                        allocation.ResourceId == resourceId  
                   && allocation.Year == year 
                    && allocation.Month == month 
                   && allocation.FinalAcceptance == true
                    )
                .Select(x => new { 
                    x.Hour,
                    x.Day,
                    x.Month,
                    x.Year,
                    x.Barname.Title,
                    x.Barname.Id,
                    network = x.Barname.BarnameNetworks.Select(n=>n.BasicData).Select(a => a.Name),
                    x.UsedUnit,
                    Producers = x.Barname.BarnameProducers.Select(s => s.Producer)
                        .Select(g => g.FirstName + ' ' + g.LastName ),
                    Group = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Name)
                })
     
                .ToListAsync();
          
            var resource = await _context.Resources
                .Where(x=>x.ResourceId==resourceId)
                .Select(x => new
            {
                ResourceName = x.Title,
                x.ResourceId,
                ResourceCapacity = x.Capacity,
            })
                .ToListAsync();
            Dictionary<string, object> result =
                new Dictionary<string, object> {{"allocations", allocations}, {"test", resource}};

            return Ok(result);
        }
         
         
        [AllowAnonymous]
        [HttpGet("AcceptRequest/{resourceId:int}/{year:int}/{month:int}/{day:int}/{barnameId:int}")]

        public async Task<IActionResult> AcceptRequest(int resourceId, int year, int month, int day, int barnameId)
        {
           
            var identity = (ClaimsIdentity)User.Identity;
            Console.WriteLine(identity.IsAuthenticated);
            
            (from allocation in  _context.Allocations
                    where 
                        allocation.ResourceId == resourceId
                        && allocation.Year == year
                        && allocation.Month == month
                        && allocation.Day == day
                        && allocation.BarnameId == barnameId select allocation).ToList()
                .ForEach(x => x.FinalAcceptance = true);
            await _context.SaveChangesAsync();
            return StatusCode(201);

        }
         
        [AllowAnonymous]
        [HttpGet("RejectRequest/{resourceId:int}/{year:int}/{month:int}/{day:int}/{barnameId:int}")]

        public async Task<IActionResult> RejectRequest(int resourceId, int year, int month, int day, int barnameId)
        {
           
            var identity = (ClaimsIdentity)User.Identity;
            Console.WriteLine(identity.IsAuthenticated);
            
            (from allocation in  _context.Allocations
                    where 
                        allocation.ResourceId == resourceId
                        && allocation.Year == year
                        && allocation.Month == month
                        && allocation.Day == day
                        && allocation.BarnameId == barnameId select allocation).ToList()
                .ForEach(x => x.FinalAcceptance = false);
            await _context.SaveChangesAsync();
            return StatusCode(201);

        }
         
        
        [AllowAnonymous]
        [HttpGet("GetAllWaitingAllocationsByResourceYearMonthForColor/{resourceId:int}/{year:int}/{month:int}")]

        public async Task<IActionResult> GetAllWaitingAllocationsByResourceYearMonthForColor(int resourceId, int year, int month)
        {
           
            var identity = (ClaimsIdentity)User.Identity;
            Console.WriteLine(identity.IsAuthenticated); 
            var allocations = await _context.Allocations
            
                .Where(allocation => 
                    allocation.ResourceId == resourceId && 
                    allocation.Year == year &&
                    allocation.Month == month && 
                    allocation.FinalAcceptance != false)
                .Select(x => new { 
                    x.Hour,
                    x.Day,
                    x.Month,
                    x.Year,
                    x.Barname.Title,
                    x.Barname.Id,
                    network = x.Barname.BarnameNetworks.Select(n=>n.BasicData).Select(a => a.Name),
                    x.UsedUnit,
                    x.FinalAcceptance,
                    Producers = x.Barname.BarnameProducers.Select(s => s.Producer)
                        .Select(g => g.FirstName + ' ' + g.LastName ),
                    Group = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Name)
                })
     
                .ToListAsync();
          
            var resource = await _context.Resources
                .Where(x=>x.ResourceId==resourceId)
                .Select(x => new
            {
                ResourceName = x.Title,
                x.ResourceId,
                ResourceCapacity = x.Capacity,
            })
                .ToListAsync();
            Dictionary<string, object> result =
                new Dictionary<string, object> {{"allocations", allocations}, {"test", resource}};

            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpGet("GetAllWaitingAllocationsByResourceYearMonthForEachBarname/{resourceId:int}/{year:int}/{month:int}/{barnameId:int}")]

        public async Task<IActionResult> GetAllWaitingAllocationsByResourceYearMonthForEachBarname(int resourceId, int year, int month, int barnameId)
        {
           
            var identity = (ClaimsIdentity)User.Identity;
            Console.WriteLine(identity.IsAuthenticated); 
            var allocations = await _context.Allocations
            
                .Where(allocation => 
                    allocation.ResourceId == resourceId && 
                    allocation.Year == year &&
                    allocation.Month == month &&
                    allocation.BarnameId == barnameId &&
                    allocation.IsDeleted != true &&
                    allocation.FinalAcceptance != false)
                .Select(x => new { 
                    x.Hour,
                    x.Day,
                    x.Month,
                    x.Year,
                    x.Barname.Title,
                    x.Barname.Id,
                    x.Activity1,
                    x.Activity2,
                    x.Activity3,
                    x.FinalAcceptance
                })
     
                .ToListAsync();
            var activity = await _context.Allocations
            
                .Where(allocation => 
                    allocation.ResourceId == resourceId && 
                    allocation.Year == year &&
                    allocation.Month == month &&
                    allocation.BarnameId == barnameId &&
                    allocation.IsDeleted != true)
                .Select(x => new { 
                    x.Hour,
                    x.Day,
                    // x.Month,
                    // x.Year,
                    // x.Barname.Title,
                    // x.Barname.Id,
                    x.Activity1,
                    x.Activity2,
                    x.Activity3
                })
     
                .ToListAsync();

            var resource = await _context.Resources
                .Where(x=>x.ResourceId==resourceId)
                .Select(x => new
            {
                ResourceName = x.Title,
                x.ResourceId,
                ResourceCapacity = x.Capacity,
            })
                .ToListAsync();
            Dictionary<string, object> result =
                new Dictionary<string, object>
                {
                    {"allocations", allocations}, 
                    {"test", resource},
                    {"activities", activity.GroupBy(l=>l.Day).Select(x=>
                        new
                        {
                            activity1=x.Any(i=>i.Activity1),
                            activity2=x.Any(i=>i.Activity2),
                            activity3=x.Any(i=>i.Activity3),
                            day=x.Max(i=>i.Day)
                        })}
                };

            return Ok(result);
        }
        
        
        
        [AllowAnonymous]
        [HttpGet("DeleteWaitingAllocationsByResourceYearMonthDayForEachBarname/{resourceId:int}/{year:int}/{month:int}/{day:int}/{barnameId:int}")]

        public async Task<IActionResult> DeleteWaitingAllocationsByResourceYearMonthDayForEachBarname(int resourceId, int year, int month, int day, int barnameId)
        {
           
            
            var identity = (ClaimsIdentity)User.Identity;
            Console.WriteLine(identity.IsAuthenticated);
            
            (from allocation in  _context.Allocations
                    where 
                        allocation.ResourceId == resourceId
                        && allocation.Year == year
                        && allocation.Month == month
                        && allocation.Day == day
                        && allocation.FinalAcceptance != false
                        && allocation.BarnameId == barnameId select allocation).ToList()
                .ForEach(x => x.IsDeleted = true);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
        
        [AllowAnonymous]
        [HttpGet("GetAllAllocationsByResourceYearForAccepting/{resourceId}/{year}")]

        public async Task<IActionResult> GetAllAllocationsByResourceYearForAccepting(int resourceId, int year)
        {
           
            // var identity = (ClaimsIdentity)User.Identity;
       
            var allocations = await _context.Allocations
            
                .Where(allocation => 
                    allocation.ResourceId == resourceId && 
                    allocation.Year == year 
                    && allocation.FinalAcceptance == null)
                .Select(x => new { 
                    ResourceName = x.Resource.Title,
                    x.Resource.ResourceId,
                    ResourceCapacity = x.Resource.Capacity,
                    x.Day,
                    x.Month,
                    x.Year,
                    x.Hour,
                    x.Barname.Title,
                    x.Barname.Id,
                    x.UsedUnit,
                    
                  
                    Producers = x.Barname.BarnameProducers.Select(s => s.Producer)
                        .Select(g => g.FirstName + ' ' + g.LastName ),
                    Group = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Name)
                      
                           
                                
                })
     
                .ToListAsync();
          
            var resource = await _context.Resources
                .Where(x=>x.ResourceId==resourceId)
                .Select(x => new
            {
                ResourceName = x.Title,
                x.ResourceId,
                ResourceCapacity = x.Capacity,
            })
                .ToListAsync();
            Dictionary<string, object> result =
                new Dictionary<string, object> {{"allocations", allocations}, {"test", resource}};

            return Ok(result);
        }
        
        
        [AllowAnonymous]
        [HttpGet("GetAllWaitingRequestByResourceYearMonthForAccepting/{resourceId:int}/{year:int}/{Month:int}")]
        public async Task<IActionResult> GetAllWaitingRequestByResourceYearMonthForAccepting(int resourceId, int year, int month)
        {
           
            // var identity = (ClaimsIdentity)User.Identity;
       
            var allocations = await _context.Allocations
            
                .Where(allocation => 
                    allocation.ResourceId == resourceId && 
                    allocation.Year == year 
                    && allocation.Month == month
                    && allocation.FinalAcceptance == null)
                .Select(x => new { 
                    
                    x.Hour,
                    x.Day,
                    x.Month,
                    x.Year,
                    x.RegisterDate,
                    
                    x.Barname.Title,
                    network = x.Barname.BarnameNetworks.Select(n=>n.BasicData).Select(a => a.Name),
                    networkId = x.Barname.BarnameNetworks.Select(n=>n.BasicData).Select(a => a.Id),
                    x.Barname.Id,
                    x.UsedUnit,
                    
                  
                    Producers = x.Barname.BarnameProducers.Select(s => s.Producer)
                        .Select(g => g.FirstName + ' ' + g.LastName ),
                    Group = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Name)
                      
                           
                                
                })
     
                .ToListAsync();
          
            var resource = await _context.Resources
                .Where(x=>x.ResourceId==resourceId)
                .Select(x => new
            {
                ResourceName = x.Title,
                x.ResourceId,
                ResourceCapacity = x.Capacity,
            })
                .ToListAsync();
            Dictionary<string, object> result =
                new Dictionary<string, object> {{"allocations", (allocations.GroupBy(s=>new{s.Day, s.Title}).GroupBy(l=>l.Key.Day))}, {"test", resource}};

            return Ok(result);
        }
       
        [AllowAnonymous]
        [HttpGet("GetFreeResourceByResourceYearMonthDay/{resourceId:int}/{year:int}/{Month:int}/{day:int}")]
        public async Task<IActionResult> GetFreeResourceByResourceYearMonthDay(int resourceId, int year, int month, int day)
        {
           
            // var identity = (ClaimsIdentity)User.Identity;
       
            var allocations = await _context.Allocations
                
                .Where(allocation => 
                    allocation.ResourceId == resourceId  
                    && allocation.Day == day 
                    && allocation.Year == year 
                    && allocation.Month == month
                    && allocation.FinalAcceptance == true)
                .GroupBy(a => a.Hour)
                .Select(x => new { 
                    usedResource = x.Sum(b => b.UsedUnit),
                     Hour = x.Key
                })
     
                .ToListAsync();
          
            var resource = await _context.Resources
                .Where(x=>x.ResourceId==resourceId)
                .Select(x => new
            {
                ResourceName = x.Title,
                x.ResourceId,
                ResourceCapacity = x.Capacity,
            })
                .ToListAsync();
            Dictionary<string, object> result =
                new Dictionary<string, object> {{"allocations", (allocations)}, {"test", resource}};

            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpGet("GetWaitingRequestByResourceYearBarnameForAccepting/{resourceId:int}/{year:int}/{barnameId:int}")]

        public async Task<IActionResult> GetWaitingRequestByResourceYearBarnameForAccepting(int resourceId, int year, int barnameId)
        {
           
            // var identity = (ClaimsIdentity)User.Identity;
            
            var allocations = await _context.Allocations
            
                .Where(allocation => 
                    allocation.ResourceId == resourceId && 
                    allocation.Year == year 
                    && allocation.FinalAcceptance == null &&
                    allocation.BarnameId == barnameId)
                .Select(x => new { 
                    ResourceName = x.Resource.Title,
                    x.Resource.ResourceId,
                    ResourceCapacity = x.Resource.Capacity,
                    x.Day,
                    x.Month,
                    x.Year,
                    x.Hour,
                    x.Barname.Title,
                    x.Barname.Id,
                    x.UsedUnit,
                    
                  
                    Producers = x.Barname.BarnameProducers.Select(s => s.Producer)
                        .Select(g => g.FirstName + ' ' + g.LastName ),
                    Group = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Name)
                      
                           
                                
                })
     
                .ToListAsync();
          
            var resource = await _context.Resources
                .Where(x=>x.ResourceId==resourceId)
                .Select(x => new
            {
                ResourceName = x.Title,
                x.ResourceId,
                ResourceCapacity = x.Capacity,
            })
                .ToListAsync();
            Dictionary<string, object> result =
                new Dictionary<string, object> {{"allocations", allocations}, {"test", resource}};

            return Ok(result);
        }
        
         
      
      
        
        [AllowAnonymous]
        [HttpGet("GetAllAcceptedAllocationsByResourceYear/{resourceId:int}/{year:int}")]

        public async Task<IActionResult> GetAllAcceptedAllocationsByResourceYear(int resourceId, int year)
        {
           
            // var identity = (ClaimsIdentity)User.Identity;
            Console.WriteLine("5%4="+5%4); 
            var allocations = await _context.Allocations
            
                .Where(allocation => 
                    allocation.ResourceId == resourceId && 
                    allocation.Year == year 
                    && allocation.FinalAcceptance == true)
                .Select(x => new { 
                    ResourceName = x.Resource.Title,
                    x.Resource.ResourceId,
                    ResourceCapacity = x.Resource.Capacity,
                    x.Day,
                    x.Month,
                    x.Year,
                    x.Hour,
                    x.Barname.Title,
                    x.Barname.Id,
                    x.UsedUnit,
                    
                  
                    Producers = x.Barname.BarnameProducers.Select(s => s.Producer)
                        .Select(g => g.FirstName + ' ' + g.LastName ),
                    Group = x.Barname.BarnameGroups.Select(s => s.BasicData).Select(g => g.Name)
                      
                           
                                
                })
     
                .ToListAsync();
          
            var resource = await _context.Resources
                .Where(x=>x.ResourceId==resourceId)
                .Select(x => new
            {
                ResourceName = x.Title,
                x.ResourceId,
                ResourceCapacity = x.Capacity,
            })
                .ToListAsync();
            Dictionary<string, object> result =
                new Dictionary<string, object> {{"allocations", allocations}, {"test", resource}};

            return Ok(result);
        }
        
       
        [AllowAnonymous]
        [HttpPost("register")]
       
        public async Task<IActionResult> Register(List<AllocationForRegisterDto> allocationForRegisterDto)
        {
            Console.WriteLine(allocationForRegisterDto[0].BarnameId);
        
            foreach (var allocationToRegister in allocationForRegisterDto.Select(x => new Allocation
            {
                ResourceId = x.ResourceId,
                BarnameId = x.BarnameId,
                Year = x.Year,
                Month = x.Month,
                Day = x.Day,
                Hour = x.Hour,
                UsedUnit = x.UsedUnit,
                RegisterDate = null,
                FinalAcceptance = null,
                Activity1 = x.Activity1,
                Activity2 = x.Activity2,
                Activity3 = x.Activity3,
            }))
            {
                //Console.WriteLine("day:   "+x.Day);
                var allocation = await _repo.RegisterAllocation(allocationToRegister);
            }
          
            return StatusCode(201);

            
           
        }
    }
}
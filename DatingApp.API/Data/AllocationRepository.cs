using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.API.Data
{
    public class AllocationRepository : IAllocationRepository
    {
        
        private readonly DataContext _context;
        public AllocationRepository(DataContext context)
        {
            _context = context;

        }
        
        // public async Task<Allocation> RegisterAllocation (Allocation allocation, Dictionary<string, object> otherData )
        public async Task<Allocation> RegisterAllocation (Allocation allocation )
        {
            Console.WriteLine("33333333333333333333333333333333333333333");
            Console.WriteLine(allocation.Year);
            await _context.Allocations.AddAsync(allocation);
            Console.WriteLine("aaaaaaaaaaaaassssssssssssssss");
            await _context.SaveChangesAsync();
          
            Console.WriteLine("bnnbbnbnbnbnbnnbnnbnnn");

            return allocation;
        }
      
    }
}
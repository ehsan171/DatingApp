using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAllocationRepository
    {
        // Task<Allocation> RegisterAllocation(Allocation allocation,  Dictionary<string, object> otherData);
        Task<Allocation> RegisterAllocation(Allocation allocation);
       
   
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAllocationRepository
    {
        Task<Screenplay> RegisterScreenplay(Screenplay student,  Dictionary<string, object> otherData);
       
        Task<Screenplay> GetScreenplay(int id);
    }
}
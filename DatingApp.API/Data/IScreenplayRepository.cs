using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IScreenplayRepository
    {
        Task<Screenplay> RegisterScreenplay(Screenplay student,  Dictionary<string, object> otherData);
        Task<bool> ScreenplayExists(string title);
    }
}
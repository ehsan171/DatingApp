using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IScreenplayRepository
    {
        Task<Screenplay> RegisterScreenplay(Screenplay student,  Dictionary<string, object> otherData);
        Task<Screenplay> UpdateScreenplay(Screenplay student,  Dictionary<string, object> otherData);
        Task<bool> ScreenplayTitleExists(string title);
        Task<bool> BaravordExists(string baravordNo);
        Task<bool> ScreenplayRecordExists(int id);
        Task<IEnumerable<Screenplay>> GetScreenplays();
        Task<Screenplay> GetScreenplay(int id);
    }
}
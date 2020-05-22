
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IEpisodeRepository
    {
        Task<Episode> RegisterEpisode(Episode episode,  Dictionary<string, object> otherData);
        Task<bool> EpisodeExists(string title, int episodeNumber, int screenplayId);
    }
}
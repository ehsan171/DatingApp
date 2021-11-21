using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class EpisodeRepository : IEpisodeRepository
    {
        
        private readonly DataContext _context;
        public EpisodeRepository(DataContext context)
        {
            _context = context;

        }
        
        
     
        public async Task<Episode> RegisterEpisode(Episode episode, Dictionary<string, object> otherData )
        {
               
            await _context.Episodes.AddAsync(episode);
            await _context.SaveChangesAsync();

                      List<int> writers = (List<int>) otherData["Writers"];

          
            List<int> concepts = (List<int>) otherData["Concepts"];
            //  var epWritToCreate = new EpisodeWriter
            //     {
            //         PersonId = 3,
            //         EpisodeId = episode.Id,
            //     };

                // await _context.EpisodeWriters.AddAsync(epWritToCreate);
                // await _context.SaveChangesAsync();

foreach (int writer in writers)
            {

                var epWritToCreate = new EpisodeWriter
                {
                    PersonId = writer,
                    EpisodeId = episode.Id,
                };

                await _context.EpisodeWriters.AddAsync(epWritToCreate);
                await _context.SaveChangesAsync();
            }


            foreach (int concept in concepts)
            {
              
                var epGeToCreate = new EpisodeConcept
                {
                    PMDSPSItemItemID = concept,
                    EpisodeId = episode.Id,
                    
                };

                await _context.EpisodeConcepts.AddAsync(epGeToCreate);
                await _context.SaveChangesAsync();
            }
            

            return episode;
        }

        public async Task<bool> EpisodeExists(string title, int episodeNumber, int screenplayId)
        {
           if (await _context.Episodes.AnyAsync(x => x.EpisodeTitle == title && x.EpisodeNumber == episodeNumber && x.ScreenplayId == screenplayId))
                return true;
            
            return false;
        }
    }
}
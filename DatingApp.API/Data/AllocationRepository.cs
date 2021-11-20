using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.API.Data
{
    public class ScreenplayRepository : IScreenplayRepository
    {
        
        private readonly DataContext _context;
        public ScreenplayRepository(DataContext context)
        {
            _context = context;

        }

        
        
        public async Task<Screenplay> RegisterScreenplay (Screenplay screenplay, Dictionary<string, object> otherData )
        {
        
            await _context.Screenplays.AddAsync(screenplay);
            await _context.SaveChangesAsync();
            Console.WriteLine( otherData["Formats"]);
            Console.WriteLine( "zzzzzRegisterScreenplayzzzzzzzz");
            int formats = (int) otherData["Formats"];
            List<int> genres = (List<int>) otherData["Genres"];
            List<int> producers = (List<int>) otherData["Producers"];
            List<int> orgStructures = (List<int>) otherData["OrgStructures"];
        
    
            // var names = new List<string>() { "John", "Tom", "Peter" };
            foreach (int genre in genres)
            {
                Console.WriteLine("jkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk"+genre);   
                var scGeToCreate = new ScreenplayGenre
                {
                    PMDSPSItemItemID = genre,
                    ScreenplayId = screenplay.Id,
                };
     
                await _context.ScreenplayGenres.AddAsync(scGeToCreate);
                await _context.SaveChangesAsync();
                 Console.WriteLine("rrrrrrrrrrrrrrrrrrrrrrrrrrrrrr");
            }
            foreach (int producer in producers)
            {
                var scProToCreate = new ScreenplayProducer
                {
                    PersonId = producer,
                    ScreenplayId = screenplay.Id,
                };

                await _context.ScreenplayProducers.AddAsync(scProToCreate);
                await _context.SaveChangesAsync();

                
              
                
            }
       
            foreach (int org in orgStructures)
            {
                
                    var screenOrgToCreate = new ScreenplayOrgStructure
                    {
                        PMDSPSItemItemID = org,
                        ScreenplayId = screenplay.Id,
                        
                    };

                    await _context.ScreenplayOrgStructures.AddAsync(screenOrgToCreate);
                    await _context.SaveChangesAsync();
            }

            var scForToCreate = new ScreenplayFormat
                {
                    PMDSPSItemItemID = formats,
                    ScreenplayId = screenplay.Id,
                };

            Console.WriteLine(scForToCreate.PMDSPSItem);
                await _context.ScreenplayFormats.AddAsync(scForToCreate);
                await _context.SaveChangesAsync();

            return screenplay;
        }
        
        public async Task<Screenplay> UpdateScreenplay (Screenplay screenplay, Dictionary<string, object> otherData )
        {
        
            var ScreenplayFromDb = await _context.Screenplays.FindAsync(screenplay.Id);
            ScreenplayFromDb.Title=screenplay.Title; 
            ScreenplayFromDb.TotalNumberEpisodes = screenplay.TotalNumberEpisodes; 
            ScreenplayFromDb.StatusId = screenplay.StatusId;
            ScreenplayFromDb.RegDate = screenplay.RegDate;
    
            await _context.SaveChangesAsync();  

            if (otherData["Formats"]!=null){
              
                _context.RemoveRange(_context.ScreenplayFormats.FirstOrDefault(a => a.ScreenplayId == screenplay.Id));
                _context.SaveChanges();
                
                int formats = (int) otherData["Formats"];
             
                var scForToCreate = new ScreenplayFormat
                {
                    PMDSPSItemItemID = formats,
                    ScreenplayId = screenplay.Id,
                };

                await _context.ScreenplayFormats.AddAsync(scForToCreate);
                await _context.SaveChangesAsync();
            }

            
            if (otherData["Genres"]!=null){
              
                _context.RemoveRange(_context.ScreenplayProducers.Where(x => x.ScreenplayId == screenplay.Id));
                _context.SaveChanges();
                
                List<int> genres = (List<int>) otherData["Genres"];
             
                foreach (int genre in genres)
            {
               
                var scGeToCreate = new ScreenplayGenre
                {
                    PMDSPSItemItemID = genre,
                    ScreenplayId = screenplay.Id,
                };

                    await _context.ScreenplayGenres.AddAsync(scGeToCreate);
                    await _context.SaveChangesAsync();
                }
            }

            _context.SaveChanges();

            if (otherData["Producers"] != null)
            {

                _context.RemoveRange(_context.ScreenplayProducers.Where(x => x.ScreenplayId == screenplay.Id));
                _context.SaveChanges();

                List<int> producers = (List<int>)otherData["Producers"];

                foreach (int producer in producers)
                {

                    var scProToCreate = new ScreenplayProducer
                    {
                        PersonId = producer,
                        ScreenplayId = screenplay.Id,
                };

                await _context.ScreenplayProducers.AddAsync(scProToCreate);
                await _context.SaveChangesAsync();
            }
            }
           
            if (otherData["OrgStructures"]!=null){
              
               _context.RemoveRange(_context.ScreenplayOrgStructures.Where(x => x.ScreenplayId == screenplay.Id));
                _context.SaveChanges();
                
                List<int> orgStructures = (List<int>) otherData["OrgStructures"];
             
               
            foreach (int org in orgStructures)
                {
                
                    var screenOrgToCreate = new ScreenplayOrgStructure
                    {
                        PMDSPSItemItemID = org,
                        ScreenplayId = screenplay.Id,
                        
                    };

                    await _context.ScreenplayOrgStructures.AddAsync(screenOrgToCreate);
                    await _context.SaveChangesAsync();
                }

            }
            return screenplay;
        }
        
        
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> ScreenplayTitleExists(string title)
        {
             
            if (await _context.Screenplays.AnyAsync(x => x.Title == title))
                return true;
            
            return false;
        }


        public async Task<bool> BaravordExists(string baravordNo)
        {
             
            if (await _context.Screenplays.AnyAsync(x => x.BaravordNo == baravordNo))
                return true;
            
            return false;
        }
    
        public async Task<bool> ScreenplayRecordExists(int id)
        {
             
            if (await _context.Screenplays.AnyAsync(x => x.Id == id))
                return true;
            
            return false;
        }
    
        public async Task<Screenplay> GetScreenplay(int id)
        {
            var screenplay =await _context.Screenplays.Include(p => p.Episodes).FirstOrDefaultAsync(u => u.Id == id);
            return screenplay;
        }
      
        public async Task<IEnumerable<Screenplay>> GetScreenplays()
        {
            var screenplays = await _context.Screenplays.Include(p => p.Episodes).ToListAsync();
            return screenplays;
        }
    
    }
}
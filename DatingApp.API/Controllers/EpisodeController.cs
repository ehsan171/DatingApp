using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DatingApp.API.Models;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using AutoMapper.Configuration;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/screenplay/{screenplayId}/[controller]")]
    [ApiController]
    public class EpisodeController :ControllerBase
    {
         private readonly DataContext _context;
           private readonly IEpisodeRepository _repo;
        private readonly IConfiguration _config;

        public object ViewBag { get; private set; }

        public EpisodeController(DataContext context, IEpisodeRepository repo)
        {
            _context = context;
            // _config = config;
            _repo = repo; 
        }
    
        // [AllowAnonymous]
        // [HttpPost, DisableRequestSizeLimit]
        // public IActionResult Upload(int screenplayId)
        // {
            
 
            
        //     Console.WriteLine("screenplayId" );
          
        //     try
        //     {
        //         // Console.WriteLine("dsfsdfsdfsdfdsf");
        //         var file = Request.Form.Files[0];
                
        //         var folderName = Path.Combine("Resources", "Images");
        //         var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        //         if (file.Length > 0)
        //         {
        //             var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //             var fullPath = Path.Combine(pathToSave, fileName);
        //             var dbPath = Path.Combine(folderName, fileName);

        //              var scGeToCreate = new Episode
        //                 {
        //                     Url = dbPath,
        //                     ScreenplayId = screenplayId,
        //                     // EpisodeTitle = Request.Form['s'],
        //                 };
        //     _context.Episodes.Add(scGeToCreate);
        //      _context.SaveChanges();
        //             using (var stream = new FileStream(fullPath, FileMode.Create))
        //             {
        //                 file.CopyTo(stream);
        //             }



        //             return Ok(new { dbPath });
        //         }
        //         else
        //         {
        //             return BadRequest();
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, $"Internal server error: {ex}");
        //     }
        // }
   



        [AllowAnonymous]
         [HttpPost("register")]
        public async Task<IActionResult> Register(EpisodeForCreationDto episodeForRegisterDto, int screenplayId)
        { 
             
             // validate request
             if (await _repo.EpisodeExists(episodeForRegisterDto.Title, episodeForRegisterDto.episodeNumber , screenplayId))
                return BadRequest("Username already ex...");

             
            var episodeToCreate = new Episode
            {
                EpisodeTitle =episodeForRegisterDto.Title,
                EpisodeNumber = episodeForRegisterDto.episodeNumber,
                ScreenplayId = screenplayId,
                Url =episodeForRegisterDto.Url,
            };
            
             List<int> intList = episodeForRegisterDto.Concept.ConvertAll(int.Parse);
            Dictionary<string, object> otherData = new Dictionary<string,object>();
            
            
            otherData.Add("Writers", episodeForRegisterDto.Writer);
            otherData.Add("Concepts", intList);

          var createdS = await _repo.RegisterEpisode(episodeToCreate,  otherData);
            return StatusCode(201);
        }
        
        

       
    
    }     
                
                   
}

    

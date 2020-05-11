
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DatingApp.API.Controllers
{
    // [Authorize]
    [Route("api/eposide")]
    [ApiController]
    public class EpisodeController :ControllerBase
    {
        private readonly IScreenplayRepository _repo;
        private readonly IMapper _mapper;
        public  EpisodeController (IScreenplayRepository repo, IMapper mapper){
            _repo = repo;
            _mapper = mapper;

        }


[HttpPost, DisableRequestSizeLimit]
public IActionResult Upload()
{
    try
    {
        var file = Request.Form.Files[0];
        var folderName = Path.Combine("Resources", "Images");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
 
        if (file.Length > 0)
        {
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);
 
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
 
            return Ok(new { dbPath });
        }
        else
        {
            return BadRequest();
        }
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Internal server error: {ex}");
    }
}

        // [HttpPost]
        // public async Task<IActionResult> AddEpisodeForScreenplay(
        //     int screenplayId, 
        //     EpisodeForCreationDto episodeForCreationDto)
        //     {
        //         var screenplayFormRepo = await _repo.GetScreenplay(screenplayId);

        //         var file = episodeForCreationDto.File;

        //         if (file.Length > 0)
        //         {
        //             using (var stream = file.OpenReadStream())
        //             {
        //                 var uploadParms = new F
        //             }
        //         }

        //     }
        
    }
}
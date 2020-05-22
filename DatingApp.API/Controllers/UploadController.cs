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
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Hosting;
using System.Data.Entity;

namespace DatingApp.API.Controllers
{
   [Authorize]
    [Route("api/episode/[controller]")]
    [ApiController]

    public class UploadController :ControllerBase
    {
   
    
            private readonly DataContext _context;
        //    private readonly IEpisodeRepository _repo;
        private readonly IConfiguration _config;
        public UploadController(DataContext context)
        {
            _context = context;
            // _config = config;
            // _repo = repo; 
        }
    
        [AllowAnonymous]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            
 
            
            Console.WriteLine("screenplayId" );
          
            try
            {
                // Console.WriteLine("dsfsdfsdfsdfdsf");
                var file = Request.Form.Files[0];
                
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                   Console.WriteLine(fileName);






                   fileName ="myFile_" + DateTime.Now.ToString("yy-M-dd-HH-mm-ss") + ".pdf";
                    var fullPath = Path.Combine(pathToSave, fileName);
                                       Console.WriteLine(fullPath);

                    var dbPath = Path.Combine(folderName, fileName);

            //          var scGeToCreate = new Episode
            //             {
            //                 Url = dbPath,
            //                 ScreenplayId = screenplayId,
            //                 // EpisodeTitle = Request.Form['s'],
            //             };
            // _context.Episodes.Add(scGeToCreate);
            //  _context.SaveChanges();
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
    

     [AllowAnonymous]
        [HttpGet("test")]
        public async Task<IActionResult> GetValues2()
        {
            Console.WriteLine("FASDFSFSFD");
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

    
        [AllowAnonymous]
        [Route("delete")]
        // [ValidateAntiForgeryToken]
        public ActionResult delete()
        {

            // ViewBag.deleteSuccess = "false";
            var fileName = "";
            fileName = "30.pdf";
       
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fullPath = Path.Combine(pathToSave, fileName);
            Console.WriteLine(fullPath);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
           return StatusCode(201);
        }

      
        [AllowAnonymous]
        [HttpGet("download2")]
        public async Task<IActionResult> Download([FromQuery] string file) 
       {
         Console.WriteLine("FASDFSFSFD");
        
        //    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                var folderName = Path.Combine("Resources", "Images");
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

           if (!System.IO.File.Exists(filePath+"/1.jpg"))
                Console.WriteLine(filePath);
                return NotFound();
 
           var memory = new MemoryStream();
            Console.WriteLine("ddddggggggggggggggg");
           using (var stream = new FileStream(filePath+"/1.jpg", FileMode.Open))
           {
               await stream.CopyToAsync(memory);
           }
           memory.Position = 0;

           return File(memory, GetContentType(filePath+"/1.jpg"), file);
       }

       private string GetContentType(string path)
       {
           var provider = new FileExtensionContentTypeProvider();
           string contentType;
           if(!provider.TryGetContentType(path, out contentType))
           {
               contentType = "application/octet-stream";
           }
           return contentType;
       }

    }




}
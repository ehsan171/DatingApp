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

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController :ControllerBase
    {
    private readonly DataContext _context;
        public UploadController(DataContext context)
        {
            _context = context;

        }
    
        [AllowAnonymous]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            
            try
            {
                // Console.WriteLine("dsfsdfsdfsdfdsf");
                var file = Request.Form.Files[0];
                
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                     var scGeToCreate = new UserTest
                {
                   ImgPath = dbPath
                };
 _context.UserTests.Add(scGeToCreate);
             _context.SaveChanges();
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
    }
}
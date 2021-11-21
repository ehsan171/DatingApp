using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            Console.WriteLine("aaaaaaaaaaaaaaaaasssssssssssssssss");
            Console.WriteLine(userForRegisterDto.Firstname);
            // validate request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if (await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("کاربری با این نام قبلا ثبت نام کرده است.");

            
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username,
                photoUrl = userForRegisterDto.photoUrl,
                OrgId = userForRegisterDto.OrgId,
                Firstname = userForRegisterDto.Firstname,
                Lastname = userForRegisterDto.Lastname,

            };

          
            

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
            
            return StatusCode(201);
        }
        [HttpPost("processReg")]
        public async Task<IActionResult> ProcessReg(ProcessDataForRegisterDto processDataForRegisterDto)
        {
            // validate request
        
           
            
            var processDataToCreate = new ProcessDataReg
            {
                Activity = processDataForRegisterDto.Activity,
                Type = processDataForRegisterDto.Type,
                UserId = processDataForRegisterDto.UserId,
                ScreenplayId = processDataForRegisterDto.ScreenplayId,
                Time = DateTime.Now

            };

            
            

            var createdUser = await _repo.ProcessReg(processDataToCreate);
        
            return StatusCode(201);
        }

       

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);
            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username),
                new Claim("OrgId", userFromRepo.OrgId.ToString()),
                new Claim("Firstname", userFromRepo.Firstname.ToString()),
                new Claim("Lastname", userFromRepo.Lastname.ToString()),


            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
    
       
            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });

        }

    }
}
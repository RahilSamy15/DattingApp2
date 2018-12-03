using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuthRepository _Rep { get; }
        public IConfiguration _Conf { get; }
        public AuthController(IAuthRepository rep, IConfiguration conf)
        {
            _Conf = conf;
            _Rep = rep;

        }
        [HttpPost("register")]
        public async Task<IActionResult> register(UserForRegisterDto User)
        {
            User.Username = User.Username.ToLower();
            if (await _Rep.UserExist(User.Username))
                return BadRequest("username already exists");

            var createdUser = await _Rep.Register(new User { UserName = User.Username }, User.password);
            return StatusCode(201);


        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto User)
        {
            
            var UserCheck = await _Rep.LogIn(User.Username.ToLower(), User.password);
            if (UserCheck == null)
                return Unauthorized();
            var claims = new[]{
               new Claim(ClaimTypes.NameIdentifier,UserCheck.Id.ToString()),
               new Claim(ClaimTypes.Name, UserCheck.UserName)
               };
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Conf.GetSection("AppSetings:Token").Value)); 
            var creds = new SigningCredentials(Key,SecurityAlgorithms.HmacSha512Signature); 

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject= new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1), 
                SigningCredentials= creds
            }; 
            var TokenHandler = new JwtSecurityTokenHandler(); 
            var token = TokenHandler.CreateToken(tokenDescriptor); 

            return Ok(
                new {
                    token= TokenHandler.WriteToken(token),
                }
            );

        }

    }
}
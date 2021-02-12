using IngameDemo.Core.Context;
using IngameDemo.Core.DTOs;
using IngameDemo.Core.Models;
using IngameDemo.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IngameDemoProject.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(ApiContext context)
        {
            _userRepository = new UserRepository(context);
        }

        private string GenerateToken(LoginInput loginInput)
        {
            var someClaims = new Claim[]{
                new Claim(JwtRegisteredClaimNames.UniqueName,loginInput.Email),
                new Claim(JwtRegisteredClaimNames.Email,loginInput.Email),
                new Claim(JwtRegisteredClaimNames.NameId,Guid.NewGuid().ToString())
            };

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Lorem ipsum dolor sit amet consectetuer adipiscing elit Aenean commodo ligula eget dolor Aenean massa"));
            var token = new JwtSecurityToken(
                //issuer: "west-world.fabrikam.com",
                //audience: "heimdall.fabrikam.com",
                claims: someClaims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("Login")]
        public string Login([FromBody] LoginInput user)
        {
            var result = _userRepository.Login(user);

            if (result is null)
                return null;
            return JsonConvert.SerializeObject(GenerateToken(user));

        }


        [HttpPost("Register")]
        public User Register(UserInput userInput)
        {
            var user = new User()
            {
                Email = userInput.Email,
                Name = userInput.Name,
                Password = userInput.Password
            };
            return _userRepository.Create(user);
        }
    }
}

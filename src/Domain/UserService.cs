using Dot.Net.WebApi.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using WebApi.Domain.Interfaces;
using WebApi.Models;
using WebApi.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Dot.Net.WebApi.Domain
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task CreateUser(UserModel user)
        {
            await _userRepository.CreateUser(user);
        }

        public async Task<UserModel> GetUser(int userId)
        {

            return await _userRepository.FindByUserId(userId);
        }

        public async Task DeleteUser(int userId)
        {
            await _userRepository.DeleteUser(userId);
        }

        public async Task UpdateUser(UserModel user)
        {
            await _userRepository.UpdateUser(user);
        }

        public async Task<string> Login(string username, string password)
        {
            var LoginUser = _userRepository.FindByUserNameAndPassword(username, password);

            if (LoginUser.Result == null)
            {
                return string.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                Audience = _configuration["Jwt:Audience"],
                Issuer = _configuration["Jwt:Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }
    }
}
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
using System.Security.Cryptography;
using System.Drawing;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

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

        public async Task SignUp(string username, string password)
        {
            // check if username is already in database
            var LoginUser = await _userRepository.FindByUserName(username);

            if (LoginUser != null)
            {
                throw new Exception("Username already exists.");
            }

            //check regex Password
            if (!Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"))
            {
                throw new Exception("Password must be minimum eight characters, at least one letter, one number and one special character");
            }

            // Generate a random salt
            byte[] salt = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            // Hash the password with the salt
            byte[] saltedPassword = Encoding.UTF8.GetBytes(password + Encoding.UTF8.GetString(salt));
            byte[] hashedPassword;
            using (var sha256 = SHA256.Create())
            {
                hashedPassword = sha256.ComputeHash(saltedPassword);
            }
            UserModel user = new UserModel()
            {
                userName = username,
                hashedPassword = hashedPassword,
                salt = salt
            };

            await _userRepository.CreateUser(user);
        }

        public async Task<string> Login(string username, string password)
        {
            // check if username is in database
            var LoginUser = await _userRepository.FindByUserName(username);

            if (LoginUser == null)
            {
                return null;
            }

            // Hash the salted password
            byte[] saltedPassword = Encoding.UTF8.GetBytes(password + Encoding.UTF8.GetString(LoginUser.salt));
            byte[] hashedSaltedPassword;
            using (var sha256 = SHA256.Create())
            {
                hashedSaltedPassword = sha256.ComputeHash(saltedPassword);
            }

            // Compare the hashed salted password with the stored hashed password
            if (!hashedSaltedPassword.SequenceEqual(LoginUser.hashedPassword))
            {
                return null;
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
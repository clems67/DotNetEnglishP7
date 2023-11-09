using Dot.Net.WebApi.Repositories;
using System.Threading.Tasks;
using WebApi.Domain.Interfaces;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace Dot.Net.WebApi.Domain
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
    }
}
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

        public async Task<UserModel> CreateUser(UserModel user)
        {
            return new UserModel();
        }

        public async Task<UserModel> DeleteUser(int userId)
        {
            return new UserModel();
        }

        public async Task<UserModel> GetUser(int userId)
        {

            return await _userRepository.FindByUserName(userId);
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            return new UserModel();
        }
    }
}
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Domain.Interfaces;

namespace Dot.Net.WebApi.Domain
{
    public class UserService : IUserService
    {
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
            return new UserModel();
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            return new UserModel();
        }
    }
}
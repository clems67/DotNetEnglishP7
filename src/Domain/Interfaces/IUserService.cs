using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Domain.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(UserModel user);
        Task<UserModel> GetUser(int userId);
        Task UpdateUser(UserModel user);
        Task DeleteUser(int userId);
    }
}

using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(UserModel user);
        Task<UserModel> FindByUserId(int userId);
        Task UpdateUser(UserModel user);
        Task DeleteUser(int userId);
    }
}

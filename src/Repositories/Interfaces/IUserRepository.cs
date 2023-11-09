using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> FindByUserId(int id);
        Task CreateUser(UserModel user);
        Task UpdateUser(UserModel user);
        Task DeleteUser(int userId);
    }
}

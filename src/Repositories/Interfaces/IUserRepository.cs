using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(UserModel user);
        Task<UserModel> FindByUserId(int userId);
        Task<UserModel> FindByUserNameAndPassword(string userName, string passWord);
        Task UpdateUser(UserModel user);
        Task DeleteUser(int userId);
    }
}

using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> CreateUser(UserModel user);
        Task<UserModel> GetUser(int userId);
        Task<UserModel> UpdateUser(UserModel user);
        Task<UserModel> DeleteUser(int userId);
    }
}

using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> FindByUserName(int id);
    }
}

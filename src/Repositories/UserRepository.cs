using Dot.Net.WebApi.Data;
using System.Linq;
using Dot.Net.WebApi.Domain;
using System;
using System.Collections.ObjectModel;
using WebApi.Repositories.Interfaces;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dot.Net.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }


        public async Task<UserModel> FindByUserName(int id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                return dbContext.Users.Where(user => user.Id == id)
                                  .FirstOrDefault();
            }
        }
    }
}
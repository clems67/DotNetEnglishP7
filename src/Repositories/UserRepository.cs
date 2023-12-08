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
using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task CreateUser(UserModel user)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<UserModel> FindByUserId(int userId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext =  scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                return dbContext.Users.Where(user => user.Id == userId)
                                  .FirstOrDefault();
            }
        }

        public async Task<UserModel> FindByUserNameAndPassword(string userName, string passWord)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                return dbContext.Users.Where(user => user.userName == userName)
                    .Where(user => user.password == passWord)
                                  .FirstOrDefault();
            }
        }

        public async Task UpdateUser(UserModel user)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                dbContext.Users.Update(user);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int userId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocalDbContext>();
                UserModel user = dbContext.Users.Find(userId);
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
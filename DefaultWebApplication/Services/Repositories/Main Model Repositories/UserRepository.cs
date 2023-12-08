using DefaultWebApplication.Attributes;
using DefaultWebApplication.Database;
using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Models.Domain_Models.Main_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultWebApplication.Services.Repositories.Main_Model_Repositories
{
    [CustomService(Lifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
    public class UserRepository : IRepository<User, UserCommandModel>
    {
        #region Properties and Service Instances
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Interface Methods
        public async Task<User> CreateEntity(UserCommandModel command)
        {
            var user = new User
            {
                Name = command.UserName,
                Surname = command.UserSurname,
                Age = command.UserAge,
                TagName = command.UserTagName ?? GenerateUserTagName(command),
                Email = command.UserEmail,
                Password = command.UserPassword
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task DeleteEntityCollection(Func<User, bool> criteria)
        {
            var matchingUsers = await _context.Users.ToListAsync();
            matchingUsers = matchingUsers.Where(criteria).ToList();

            foreach (var user in matchingUsers)
            {
                user.Deleted = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetEntityCollection(Func<User, bool> criteria)
        {
            var matchingUsers = await _context.Users.ToListAsync();
            matchingUsers = matchingUsers.Where(criteria).ToList();

            if (!matchingUsers.Any())
                throw new Exception("Given criteria is not satisfied by any entity in the context.");

            return matchingUsers;
        }

        public async Task<User> UpdateEntity(Func<User, bool> criteriaUnique, UserCommandModel command)
        {
            var matchingUsers = await _context.Users.ToListAsync();
            matchingUsers = matchingUsers.Where(criteriaUnique).ToList();

            if (matchingUsers.Count > 1)
                throw new Exception("Given criteria does not uniquely define a single entity from the context.");
            if (!matchingUsers.Any())
                throw new Exception("Given criteria is not satisfied by any entity from the context.");

            var user = matchingUsers.First();

            user.Name = command.UserName;
            user.Surname = command.UserSurname;
            user.Email = command.UserEmail;
            user.Password = command.UserPassword;
            user.Age = command.UserAge;
            user.TagName = command.UserTagName ?? GenerateUserTagName(command);

            await _context.SaveChangesAsync();
            return user;
        }
        #endregion

        #region Specific Methods
        public async Task CreateUser(UserCommandModel command)
            => await CreateEntity(command);

        public async Task DeleteUserById(int userId)
        {
            await DeleteEntityCollection(user => user.UserId == userId);
        }

        public async Task<User> GetUserById(int userId)
        {
            var enumerableUserList = await GetEntityCollection(user => user.UserId == userId);
            return enumerableUserList.First();
        }

        public async Task<User> UpdateUserById(int userId, UserCommandModel command)
            => await UpdateEntity(user => user.UserId == userId, command);
        #endregion

        #region Helper Methods
        private string GenerateUserTagName(UserCommandModel command)
        {
            return command.UserName[0].ToString() + command.UserSurname[0..2];
        }
        #endregion
    }

}

using EFCoreFirstAPI.Contexts;
using EFCoreFirstAPI.Exceptions;
using EFCoreFirstAPI.Interfaces;
using EFCoreFirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFirstAPI.Repositories
{
    public class UserRepository : IRepository<string, User>
    {
        private readonly ShoppingContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ShoppingContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<User> Add(User entity)
        {
            try
            {
                _context.Users.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not add user");
                throw new CouldNotAddException("User");
            }
        }

        public async Task<User> Delete(string key)
        {
            var user = await Get(key);
            if(user == null)
            {
                throw new NotFoundException("User");
            }
            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not delete user");
                throw new Exception("Unable to delete");
            }
        }

        public async Task<User> Get(string key)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == key);
                return user;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not get user");
                throw new NotFoundException("User");
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            if(users.Count == 0)
            {
                throw new CollectionEmptyException("Users");
            }
            return users;
        }

        public async Task<User> Update(string key, User entity)
        {
            var user = await Get(key);
            if (user == null)
            {
                throw new NotFoundException("User");
            }
            try
            {
                _context.Users.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not update user details");
                throw new Exception("Unable to modify user object");
            }
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Melodie.Models;
using Microsoft.EntityFrameworkCore;

namespace Melodie.Data
{
    public class MelodieDbService : IMelodieDbService
    {
        private readonly MelodieDbContext _db;

        public MelodieDbService(MelodieDbContext dbContext)
        {
            _db = dbContext;
        }
        
        // GET
        public async Task<User> GetUserById(int userId)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _db.Users.ToListAsync();
        }

        // ADD
        public async Task<int> AddUser(User user)
        {
            _db.Add(user);
            return await _db.SaveChangesAsync();
        }

        // UPDATE
        public async Task<int> UpdateUser(User user)
        {
            try
            {
                _db.Update(user);
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        // DELETE
        public async Task<int> DeleteUser(int userId)
        {
            try
            {
                _db.Users.Remove(new User {UserId = userId});
                return await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
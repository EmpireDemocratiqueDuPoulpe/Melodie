using System.Collections.Generic;
using System.Threading.Tasks;
using Melodie.Models;

namespace Melodie.Data
{
    public interface IMelodieDbService
    {
        // GET
        Task<User> GetUserById(int userId);
        Task<IEnumerable<User>> GetAllUsers();
        
        // ADD
        Task<int> AddUser(User user);
        
        // UPDATE
        Task<int> UpdateUser(User user);
        
        // DELETE
        Task<int> DeleteUser(int userId);
    }
}
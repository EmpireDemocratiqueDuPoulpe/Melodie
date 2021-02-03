using Melodie.Data;

namespace Melodie.Models
{
    public class User
    {
        private MelodieDbContext _context;
        
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string CreationDate { get; set; }
    }
}
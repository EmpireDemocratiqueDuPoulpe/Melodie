using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Melodie.Models
{
    public class AspNetUser : IdentityUser
    {
        [NotMapped, DataType(DataType.Password), MaxLength(2000)]
        public string Password { get; set; }
        
        [NotMapped, DataType(DataType.Password), MaxLength(2000)]
        public string PasswordConfirmation { get; set; }
    }
}
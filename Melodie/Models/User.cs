using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace Melodie.Models
{
    public class User : IdentityUser, IUser
    {
        [Key, Column("user_id")]
        public int? UserId { get; set; }
        
        
        [Required, Column("username"), MaxLength(32)]
        public string Username { get; set; }
        
        
        [Column("email"), MaxLength(320)]
        public string EmailAddress { get; set; }
        
        
        [Required, Column("password"), MaxLength(2000)]
        public string Password { get; set; }
        
        
        [NotMapped]
        public string PasswordConfirmation { get; set; }
        
        
        [Column("creation_date", TypeName = "Date")]
        public DateTime CreationDate { get; set; }
    }
}
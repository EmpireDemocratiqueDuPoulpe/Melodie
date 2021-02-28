using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Melodie.Models
{
    public class User
    {
        [Key, Column("user_id")]
        public int? UserId { get; set; }
        
        
        [Required, Column("username"), MaxLength(32)]
        public string Username { get; set; }
        
        
        [Column("email"), MaxLength(320)]
        public string EmailAddress { get; set; }
        
        
        [Required, Column("password"), DataType(DataType.Password), MaxLength(2000)]
        public string Password { get; set; }
        
        
        [NotMapped, DataType(DataType.Password), MaxLength(2000)]
        public string PasswordConfirmation { get; set; }
        
        
        [Column("creation_date", TypeName = "Date")]
        public DateTime CreationDate { get; set; }
    }
}
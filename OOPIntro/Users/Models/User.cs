using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 4)]
        [Required]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 6)]
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,50}$")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]([.\-_A-Za-z]*[A-Za-z])*@[A-Za-z]+\.[A-Za-z]+$")]
        public string Email { get; set; }

        public byte[] Picture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1,120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

    }
}

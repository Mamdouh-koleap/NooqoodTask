using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}

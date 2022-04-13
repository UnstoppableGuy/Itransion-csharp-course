using Microsoft.AspNetCore.Identity;
using System;

namespace Task4.Models
{
    public class User : IdentityUser
    {
        public virtual DateTimeOffset LastLoginTime { get; set; }
        public virtual DateTimeOffset RegistrationDate { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Identity;

namespace CheckSkillsASP.Entity
{
    public class AppUser : IdentityUser<int>
    {
        public string NickName { get; set; }
        public DateTime WasCreated { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
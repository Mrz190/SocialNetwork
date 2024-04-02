using Microsoft.AspNetCore.Identity;

namespace CheckSkillsASP.Entity
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}

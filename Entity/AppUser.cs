using Microsoft.AspNetCore.Identity;

namespace CheckSkillsASP.Entity
{
    public class AppUser : IdentityUser<int>
    {
        public string NickName { get; set; } = null!;
        public DateTime WasCreated { get; set; }
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}

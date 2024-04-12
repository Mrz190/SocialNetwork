using CheckSkillsASP.Entity;
using Microsoft.IdentityModel.Tokens;

namespace CheckSkillsASP.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}

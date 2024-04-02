using CheckSkillsASP.Entity;

namespace CheckSkillsASP.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}

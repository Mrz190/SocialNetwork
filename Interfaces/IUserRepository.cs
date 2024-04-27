using CheckSkillsASP.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CheckSkillsASP.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<IEnumerable<AppUser>> GetUsersByNameAsync(string name);
        Task<AppUser> GetUserByNickNameAsync(string nickname);
        Task<AppUser> GetUserByIdAsync(int id);
        Task<bool> UserExist(string nickname);
        //Task AddUser(AppUser user);
        Task<bool> SaveAsync();

        Task<bool> CheckNickName(string checkString);
    }
}

﻿using CheckSkillsASP.Entity;

namespace CheckSkillsASP.Interfaces
{
    public interface IUserRepository
    {
        //void Update(AppUser user);

        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<IEnumerable<AppUser>> GetUsersByNameAsync(string name);
        Task<AppUser> GetUserByNickNameAsync(string nickname);
        Task<AppUser> GetUserByIdAsync(int id);
    }
}
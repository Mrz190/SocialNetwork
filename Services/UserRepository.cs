using CheckSkillsASP.Data;
using CheckSkillsASP.Entity;
using CheckSkillsASP.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckSkillsASP.Services
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            var result = await _context.Users.OrderBy(i => i.Id).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<AppUser>> GetUsersByNameAsync(string name)
        {
            var result = await _context.Users.Where(n => n.UserName == name).ToListAsync();
            return result;
        }
        public async Task<AppUser> GetUserByNickNameAsync(string nickname)
        {
            var result = await _context.Users.Where(n => n.NickName == nickname).FirstOrDefaultAsync();
            return result;
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            var result = await _context.Users.Where(i => i.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UserExist(string nickname)
        {
            var users = _context.Users.Where(u => u.NickName == nickname);
            if(users.Count() >= 1)
            {
                return true;
            }
            return false;
        }

        public async Task AddUser(AppUser user)
        {

            // ХЕРНЯ ЕБАНАЯ
            // НАХУЙ УДАЛИТЬ СОХРЕНЕНИЕ И СЕДАЛТЬ ЧЕРЕЗ ЮЗЕР МЕНЕДЖЕР
            var userList = (List<AppUser>)await GetUsersAsync();

            if(userList != null)
            {
                var lastuser = userList.LastOrDefault().Id;
                user.Id = ++lastuser;
                userList.Add(user);
            }
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);

        }
    }
}

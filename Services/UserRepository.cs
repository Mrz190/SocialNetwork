using CheckSkillsASP.Data;
using CheckSkillsASP.Entity;
using CheckSkillsASP.Interfaces;
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
    }
}

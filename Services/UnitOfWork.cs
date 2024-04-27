using AutoMapper;
using CheckSkillsASP.Data;
using CheckSkillsASP.Interfaces;

namespace CheckSkillsASP.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => new UserRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasAnyChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}

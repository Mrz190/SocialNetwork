namespace CheckSkillsASP.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        Task<bool> Complete();
        bool HasAnyChanges();
    }
}

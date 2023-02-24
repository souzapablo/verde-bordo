using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
}
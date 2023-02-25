using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
}
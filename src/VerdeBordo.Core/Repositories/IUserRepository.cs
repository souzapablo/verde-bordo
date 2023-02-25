using VerdeBordo.Core.Entities;

namespace VerdeBordo.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAndPasswordAsync(string email, string password);
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task<bool> IsEmailRegistered(string email);
}
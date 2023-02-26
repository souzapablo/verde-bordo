using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories.Shared;

namespace VerdeBordo.Core.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAndPasswordAsync(string email, string password);
    Task<bool> IsEmailRegistered(string email);
}
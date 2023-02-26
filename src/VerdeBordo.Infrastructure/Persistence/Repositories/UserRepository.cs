using Microsoft.EntityFrameworkCore;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;
using VerdeBordo.Infrastructure.Persistence.Repositories.Shared;

namespace VerdeBordo.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{

    public UserRepository(VerdeBordoDbContext context) : base(context) { }

    public async Task<User?> GetByEmailAndPasswordAsync(string email, string password)
    {      
        return await Context.Users
            .SingleOrDefaultAsync(x => x.Email == email && x.Password == password && x.IsActive);
    }

    public async Task<bool> IsEmailRegistered(string email)
    {
        return await Context.Users
            .AnyAsync(x => x.Email == email);
    }
}
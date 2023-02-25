using Microsoft.EntityFrameworkCore;
using VerdeBordo.Core.Entities;
using VerdeBordo.Core.Repositories;

namespace VerdeBordo.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly VerdeBordoDbContext _dbContext;

    public UserRepository(VerdeBordoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _dbContext.Users
            .Where(x => x.IsActive).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}
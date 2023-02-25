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

    public async Task CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsEmailRegistered(string email)
    {
        return await _dbContext.Users
            .AnyAsync(x => x.Email == email);
    }
}
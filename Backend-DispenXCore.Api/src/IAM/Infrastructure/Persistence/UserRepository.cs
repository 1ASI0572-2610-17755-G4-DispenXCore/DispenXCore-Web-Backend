using Backend_DispenXCore.Api.src.IAM.Application.Interfaces;
using Backend_DispenXCore.Api.src.IAM.Domain.Entities;
using Backend_DispenXCore.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend_DispenXCore.Api.src.IAM.Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    private readonly DispenXDbContext _context;
    public UserRepository(DispenXDbContext context) => _context = context;

    public async Task<User?> GetByEmailAsync(string email) =>
        await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);

    public async Task AddAsync(User user) =>
        await _context.Set<User>().AddAsync(user);

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
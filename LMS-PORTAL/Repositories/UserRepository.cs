using LMSCapstone.Models;
using System.Threading.Tasks;
using LMSCapstone.Data;
using Microsoft.EntityFrameworkCore;

namespace LMSCapstone.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
    public class UserRepository : IUserRepository
    {
        private readonly LMSDbContext _context;
        public UserRepository(LMSDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}

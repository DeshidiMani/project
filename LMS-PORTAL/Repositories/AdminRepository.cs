using LMSCapstone.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMSCapstone.Data;
using Microsoft.EntityFrameworkCore;

namespace LMSCapstone.Repositories
{
    public interface IAdminRepository
    {
        Task<bool> ApproveInstructorAsync(int instructorId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(int userId);
    }

    public class AdminRepository : IAdminRepository
    {
        private readonly LMSDbContext _context;
        public AdminRepository(LMSDbContext context)
        {
            _context = context;
        }
        
        // Approves an instructor by setting IsApproved to true.
        public async Task<bool> ApproveInstructorAsync(int instructorId)
        {
            var user = await _context.Users.FindAsync(instructorId);
            if (user == null || user.Role != UserRole.Instructor)
                return false;
            user.IsApproved = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

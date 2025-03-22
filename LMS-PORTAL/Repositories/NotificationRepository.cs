using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Data;
using Microsoft.EntityFrameworkCore;

namespace LMSCapstone.Repositories
{
    public interface INotificationRepository
    {
        Task AddAsync(Notification notification);
        Task<IEnumerable<Notification>> GetByUserAsync(int userId);
    }

    public class NotificationRepository : INotificationRepository
    {
        private readonly LMSDbContext _context;
        public NotificationRepository(LMSDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Notification>> GetByUserAsync(int userId)
        {
            return await _context.Notifications
                          .Where(n => n.UserId == userId)
                          .ToListAsync();
        }
    }
}

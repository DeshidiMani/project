using System.Collections.Generic;
using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Repositories;
using Microsoft.AspNetCore.SignalR;
using LMSCapstone.Hubs;

namespace LMSCapstone.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetNotificationsForUserAsync(int userId);
        Task SendNotificationAsync(Notification notification);
    }

    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(INotificationRepository notificationRepository, IHubContext<NotificationHub> hubContext)
        {
            _notificationRepository = notificationRepository;
            _hubContext = hubContext;
        }

        public async Task<IEnumerable<Notification>> GetNotificationsForUserAsync(int userId)
        {
            return await _notificationRepository.GetByUserAsync(userId);
        }

        public async Task SendNotificationAsync(Notification notification)
        {
            await _notificationRepository.AddAsync(notification);
            // Real-time broadcast to the user.
            await _hubContext.Clients.User(notification.UserId.ToString()).SendAsync("ReceiveNotification", notification);
        }
    }
}

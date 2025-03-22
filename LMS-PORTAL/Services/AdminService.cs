using System.Collections.Generic;
using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Repositories;
using Microsoft.AspNetCore.SignalR; // Added for IHubContext<>
using LMSCapstone.Hubs; // Added for NotificationHub

namespace LMSCapstone.Services
{
    public interface IAdminService
    {
        Task<bool> ApproveInstructorAsync(int instructorId);
        Task<IEnumerable<User>> GetAllUsersAsync(); // New method
        Task<bool> DeleteUserAsync(int userId);       // New method
    }
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IHubContext<NotificationHub> _hubContext;
        public AdminService(IAdminRepository adminRepository, IHubContext<NotificationHub> hubContext)
        {
            _adminRepository = adminRepository;
            _hubContext = hubContext;
        }

        public async Task<bool> ApproveInstructorAsync(int instructorId)
        {
            return await _adminRepository.ApproveInstructorAsync(instructorId);
        }
        
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _adminRepository.GetAllUsersAsync();
        }
        
        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _adminRepository.DeleteUserAsync(userId);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LMSCapstone.Services;
using LMSCapstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace LMSCapstone.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("approve-instructor")]
        public async Task<IActionResult> ApproveInstructor([FromBody] ApproveInstructorModel model)
        {
            var result = await _adminService.ApproveInstructorAsync(model.InstructorId);
           if (model.InstructorId <= 0)
        {
            return BadRequest(new { success = false, message = "Invalid instructor ID." });
        }

        // Logic to approve instructor
        // Example: Update database, send notifications, etc.
        return Ok(new { success = true, message = $"Instructor with ID {model.InstructorId} approved successfully." });
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _adminService.GetAllUsersAsync();
            return Ok(new { success = true, message = (string)null, data = users });
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _adminService.DeleteUserAsync(id);
            if (result)
                return Ok(new { success = true, message = "User deleted", data = (object)null });
            return NotFound(new { success = false, message = "User not found", data = (object)null });
        }
    }
}

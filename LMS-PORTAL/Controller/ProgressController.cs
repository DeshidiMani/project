using Microsoft.AspNetCore.Mvc;
using LMSCapstone.Services;
using Microsoft.AspNetCore.Authorization;

namespace LMSCapstone.Controllers
{
    [ApiController]
    [Route("api/progress")]
    [Authorize(Roles = "Student")]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressService _progressService;

        public ProgressController(IProgressService progressService)
        {
            _progressService = progressService;
        }

        [HttpGet("{userId}/{courseId}")]
        public async Task<IActionResult> GetProgress(int userId, int courseId)
        {
            var progress = await _progressService.GetProgressAsync(userId, courseId);
            return Ok(new { success = true, data = progress });
        }
    }
}

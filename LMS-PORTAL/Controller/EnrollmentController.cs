using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LMSCapstone.Services;
using LMSCapstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace LMSCapstone.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    [Authorize(Roles = "Student")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Enroll([FromBody] Enrollment enrollment)
        {
            var result = await _enrollmentService.EnrollStudentAsync(enrollment);
            if (result)
                return Ok(new { success = true, message = "Enrollment successful", data = (object)null });
            return BadRequest(new { success = false, message = "Enrollment failed", data = (object)null });
        }
    }
}

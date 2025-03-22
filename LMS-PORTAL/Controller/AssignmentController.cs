using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LMSCapstone.Services;
using LMSCapstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace LMSCapstone.Controllers
{
    [ApiController]
    [Route("api/assignments")]
    [Authorize]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpPost("{id}/submit")]
        public async Task<IActionResult> SubmitAssignment(int id, [FromBody] AssignmentSubmission submission)
        {
            var result = await _assignmentService.SubmitAssignmentAsync(id, submission);
            return Ok(new { success = true, message = "", data = result });
        }

        [HttpGet("bycourse")]
        public async Task<IActionResult> GetAssignmentsForCourse([FromQuery] int courseId)
        {
            var assignments = await _assignmentService.GetAssignmentsByCourseAsync(courseId);
            if (assignments == null)
                return NotFound(new { success = false, message = "No assignments found", data = new object[0] });
            return Ok(new { success = true, message = "", data = assignments });
        }
    }
}

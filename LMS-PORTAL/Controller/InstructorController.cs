using Microsoft.AspNetCore.Mvc;
using LMSCapstone.Services;
using LMSCapstone.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace LMSCapstone.Controllers
{
    [ApiController]
    [Route("api/instructor")]
    [Authorize(Roles = "Instructor")]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost("upload-materials")]
        public async Task<IActionResult> UploadMaterials([FromBody] CourseMaterial material)
        {
            var result = await _instructorService.UploadCourseMaterialAsync(material);
            return Ok(new { success = true, data = result });
        }

        [HttpGet("progress/{courseId}")]
        public async Task<IActionResult> GetStudentProgress(int courseId)
        {
            var progressData = await _instructorService.GetStudentProgressAsync(courseId);
            return Ok(new { success = true, data = progressData });
        }

        [HttpPost("assignments/create")]
        public async Task<IActionResult> CreateAssignment([FromBody] Assignment assignment)
        {
            var result = await _instructorService.CreateAssignmentAsync(assignment);
            return Ok(new { success = true, data = result });
        }

        [HttpPut("grade-assignment")]
        public async Task<IActionResult> GradeAssignment([FromBody] GradeAssignmentModel model)
        {
            var result = await _instructorService.GradeAssignmentAsync(model.SubmissionId, model.Grade);
            return Ok(new { success = true, data = result });
        }

        [HttpDelete("courses/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _instructorService.DeleteCourseAsync(id);
            return Ok(new { success = true, message = "Course deleted successfully!" });
        }
    }
}

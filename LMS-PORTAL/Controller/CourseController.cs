using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LMSCapstone.Services;
using LMSCapstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace LMSCapstone.Controllers
{
    [ApiController]
    [Route("api/courses")]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            var createdCourse = await _courseService.CreateCourseAsync(course);
            if (createdCourse != null)
                return CreatedAtAction(nameof(GetCourse), new { id = createdCourse.Id }, new { success = true, message = (string)null, data = createdCourse });
            return BadRequest(new { success = false, message = "Course creation failed", data = (object)null });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
                return NotFound(new { success = false, message = "Course not found", data = (object)null });
            return Ok(new { success = true, message = (string)null, data = course });
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(new { success = true, message = (string)null, data = courses });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            var updatedCourse = await _courseService.UpdateCourseAsync(id, course);
            if (updatedCourse == null)
                return NotFound(new { success = false, message = "Course not found", data = (object)null });
            return Ok(new { success = true, message = (string)null, data = updatedCourse });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return Ok(new { success = true, message = "Course deleted", data = (object)null });
        }
    }
}

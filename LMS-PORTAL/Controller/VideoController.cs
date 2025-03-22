using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using LMSCapstone.Services;
using LMSCapstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace LMSCapstone.Controllers
{
    [ApiController]
    [Route("api/videos")]
    [Authorize]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadVideo([FromForm] VideoUploadModel model)
        {
            var result = await _videoService.UploadVideoAsync(model);
            if (result.Success)
                return Ok(new { success = true, message = result.Message, data = result.Data });
            return BadRequest(new { success = false, message = result.Message, data = (object)null });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> StreamVideo(int id)
        {
            var videoStream = await _videoService.GetVideoStreamAsync(id);
            if (videoStream == null)
                return NotFound(new { success = false, message = "Video not found", data = (object)null });
            return File(videoStream, "video/mp4");
        }
    }
}

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace LMSCapstone.Models
{
    public class VideoUploadModel
    {
        // Either a file or a remote URL can be provided.
        public IFormFile Video { get; set; }
        public string RemoteUrl { get; set; }
        
        [Required]
        public int CourseId { get; set; }
    }
}

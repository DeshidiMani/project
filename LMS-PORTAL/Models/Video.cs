using System.ComponentModel.DataAnnotations;

namespace LMSCapstone.Models
{
    public class Video
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        
        [Required]
        public string Url { get; set; }
        public string Title { get; set; }
    }
}

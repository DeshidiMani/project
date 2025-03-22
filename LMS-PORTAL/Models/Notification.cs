using System;
using System.ComponentModel.DataAnnotations;

namespace LMSCapstone.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        
        [Required] 
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

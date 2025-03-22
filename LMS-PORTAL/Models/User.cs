using System.ComponentModel.DataAnnotations;

namespace LMSCapstone.Models
{
    public enum UserRole
    {
        Admin,
        Instructor,
        Student
    }

    public class User
    {
        public int Id { get; set; }
        
        [Required] 
        public string Name { get; set; }

        [Required] 
        public string Email { get; set; }

        [Required] 
        public string PasswordHash { get; set; }

        public UserRole Role { get; set; }

        // For instructors, default is false until approved.
        public bool IsApproved { get; set; } = true;
    }

    public class RegisterModel
    {
        [Required] 
        public string Name { get; set; }
        
        [Required] 
        public string Email { get; set; }
        
        [Required] 
        public string Password { get; set; }

        // Role selection: "Student" or "Instructor"
        [Required]
        public string Role { get; set; }
    }

    public class LoginModel
    {
        [Required] 
        public string Email { get; set; }
        
        [Required] 
        public string Password { get; set; }
    }
}

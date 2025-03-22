using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Repositories;
using LMSCapstone.Helpers;

namespace LMSCapstone.Services
{
    public interface IAuthService
    {
         Task<ServiceResult> RegisterAsync(RegisterModel model);
         Task<ServiceResult> LoginAsync(LoginModel model);
    }

    public class AuthService : IAuthService
    {
         private readonly IUserRepository _userRepository;
         private readonly IJWTManager _jwtManager;
         
         public AuthService(IUserRepository userRepository, IJWTManager jwtManager)
         {
             _userRepository = userRepository;
             _jwtManager = jwtManager;
         }

         public async Task<ServiceResult> RegisterAsync(RegisterModel model)
         {
             var existing = await _userRepository.GetByEmailAsync(model.Email);
             if (existing != null)
             {
                 return new ServiceResult { Success = false, Message = "User already exists.", Data = null };
             }

             var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
             var user = new User
             {
                 Name = model.Name,
                 Email = model.Email,
                 PasswordHash = passwordHash
             };

             // If user registers as Instructor, require approval.
             if (!string.IsNullOrEmpty(model.Role) && model.Role.ToLower() == "instructor")
             {
                 user.Role = UserRole.Instructor;
                 user.IsApproved = false;  // Instructor must be approved by admin
             }
             else
             {
                 user.Role = UserRole.Student;
                 user.IsApproved = true;
             }
             
             await _userRepository.AddAsync(user);
             return new ServiceResult { Success = true, Message = "Registration successful.", Data = user };
         }

         public async Task<ServiceResult> LoginAsync(LoginModel model)
         {
             var user = await _userRepository.GetByEmailAsync(model.Email);
             if (user == null)
             {
                 return new ServiceResult { Success = false, Message = "Invalid credentials.", Data = null };
             }
             bool verified = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);
             if (!verified)
             {
                 return new ServiceResult { Success = false, Message = "Invalid credentials.", Data = null };
             }
             // Block unapproved instructors from logging in.
             if(user.Role == UserRole.Instructor && !user.IsApproved)
             {
                 return new ServiceResult { Success = false, Message = "Instructor not approved by admin yet.", Data = null };
             }
             var token = _jwtManager.GenerateToken(user);
             var data = new 
             {
                 user = new 
                 {
                     id = user.Id,
                     name = user.Name,
                     email = user.Email,
                     role = user.Role.ToString()
                 },
                 token = token
             };
             return new ServiceResult { Success = true, Message = null, Data = data };
         }
    }

    public class ServiceResult
    {
         public bool Success { get; set; }
         public string Message { get; set; }
         public object Data { get; set; }
    }
}

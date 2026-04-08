using ELearningPlatform.API.Data;
using ELearningPlatform.API.DTOs;
using ELearningPlatform.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Name = u.FullName,
                    Email = u.Email,
                    Role = u.Role.ToString()
                })
                .ToListAsync();

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> CreateUser(UserCreateDto userDto)
        {
            var user = new User
            {
                FullName = userDto.Name,
                Email = userDto.Email,
                Role = Enum.Parse<UserRole>(userDto.Role, true),
                PasswordHash = userDto.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var responseDto = new UserResponseDto
            {
                Id = user.Id,
                Name = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString()
            };

            return CreatedAtAction(nameof(GetUsers), new { id = responseDto.Id }, responseDto);
        }
    }
}
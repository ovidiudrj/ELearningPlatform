using ELearningPlatform.API.Data;
using ELearningPlatform.API.DTOs;
using ELearningPlatform.API.DTOs.ELearningPlatform.API.DTOs;
using ELearningPlatform.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseResponseDto>>> GetCourses()
        {
            var courses = await _context.Courses
                .Select(c => new CourseResponseDto
                {
                    Id = c.Id,
                    Title = c.Name,
                    Description = c.Description,
                    TeacherId = c.TeacherId
                })
                .ToListAsync();

            return Ok(courses); 
        }

        [HttpPost]
        public async Task<ActionResult<CourseResponseDto>> CreateCourse(CourseCreateDto courseDto)
        {
            var course = new Course
            {
                Name = courseDto.Title,
                Description = courseDto.Description,
                TeacherId = courseDto.TeacherId
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            var responseDto = new CourseResponseDto
            {
                Id = course.Id,
                Title = course.Name,
                Description = course.Description,
                TeacherId = course.TeacherId
            };
            return CreatedAtAction(nameof(GetCourses), new { id = responseDto.Id }, responseDto);
        }
    }
}
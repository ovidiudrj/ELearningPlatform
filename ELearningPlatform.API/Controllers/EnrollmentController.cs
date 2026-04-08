using ELearningPlatform.API.Data;
using ELearningPlatform.API.DTOs;
using ELearningPlatform.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class EnrollmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollmentResponseDto>>> GetEnrollments()
        {
            var enrollments = await _context.Enrollments
                .Select(e => new EnrollmentResponseDto
                {
                    Id = e.Id,
                    StudentId = e.StudentId, 
                    CourseId = e.CourseId,
                    EnrollmentDate = e.EnrollmentDate 
                })
                .ToListAsync();

            return Ok(enrollments);
        }

        [HttpPost]
        public async Task<ActionResult<EnrollmentResponseDto>> CreateEnrollment(EnrollmentCreateDto dto)
        {
            var enrollment = new Enrollment
            {
                StudentId = dto.StudentId, 
                CourseId = dto.CourseId,
                EnrollmentDate = DateTime.UtcNow 
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            var responseDto = new EnrollmentResponseDto
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                EnrollmentDate = enrollment.EnrollmentDate
            };

            return CreatedAtAction(nameof(GetEnrollments), new { id = responseDto.Id }, responseDto);
        }
    }
}
using ELearningPlatform.API.Data;
using ELearningPlatform.API.DTOs;
using ELearningPlatform.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GradesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeResponseDto>>> GetGrades()
        {
            var grades = await _context.Grades
                .Select(g => new GradeResponseDto
                {
                    Id = g.Id,
                    EnrollmentId = g.EnrollmentId,
                    Value = g.Value,
                    Date = g.Date
                })
                .ToListAsync();

            return Ok(grades);
        }

        [HttpPost]
        public async Task<ActionResult<GradeResponseDto>> AddGrade(GradeCreateDto dto)
        {
            var grade = new Grade
            {
                EnrollmentId = dto.EnrollmentId,
                Value = dto.Value,
                Date = DateTime.UtcNow 
            };

            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            var responseDto = new GradeResponseDto
            {
                Id = grade.Id,
                EnrollmentId = grade.EnrollmentId,
                Value = grade.Value,
                Date = grade.Date
            };

            return CreatedAtAction(nameof(GetGrades), new { id = responseDto.Id }, responseDto);
        }
    }
}
namespace ELearningPlatform.API.DTOs
{
    namespace ELearningPlatform.API.DTOs
    {
        public class CourseCreateDto
        {
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public int TeacherId { get; set; }
        }

        public class CourseResponseDto
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public int TeacherId { get; set; }
        }
    }
}

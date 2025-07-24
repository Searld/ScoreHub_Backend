using ScoreHub_Domain.Enums;

namespace ScoreHub_Domain.Entities;

public class Lesson
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public LessonStatus Status { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public bool IsCommandLesson { get; set; }
    
    public List<Team>? Teams { get; set; }
    
    public List<StudentData> Students { get; set; }
    
    public Subject Subject { get; set; } // связь с предметом один ко многим
    public Guid SubjectId { get; set; }
}
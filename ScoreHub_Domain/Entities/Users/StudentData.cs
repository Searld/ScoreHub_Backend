namespace ScoreHub_Domain.Entities;

public class StudentData
{
    public Guid Id { get; set; }
    
    public string GroupNumber { get; set; }
    public List<Lesson> PastLessons { get; set; } = [];
    
    public Lesson? Lesson { get; set; } // связь с занятием один ко многим( у одного студента может быть одно занятие, у занятия много студентов)
    public Guid? LessonId { get; set; }
    
    public Team? Team { get; set; } // у студента может не быть команды(если это не командное занятие), связь один ко многим
    public Guid? TeamId { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}
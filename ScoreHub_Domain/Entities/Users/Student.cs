namespace ScoreHub_Domain.Entities;

public class Student : User
{
    public string GroupNumber { get; set; }
    
    public List<SubjectScores> SubjectScores { get; set; }

    public Lesson? Lesson { get; set; }
    public Guid? LessonId { get; set; }
    
    public Team? Team { get; set; } //ученик может быть в команде а может и не быть(но у команды ДОЛЖНЫ БЫТЬ ученики)
    public Guid? TeamId { get; set; }
}
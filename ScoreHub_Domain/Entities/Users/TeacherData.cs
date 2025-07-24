namespace ScoreHub_Domain.Entities;

public class TeacherData
{
    public List<Subject> Subjects { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}
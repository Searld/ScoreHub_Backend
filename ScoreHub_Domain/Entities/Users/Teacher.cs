namespace ScoreHub_Domain.Entities;

public class Teacher : User
{
    public List<Subject>? Subjects { get; set; }
}
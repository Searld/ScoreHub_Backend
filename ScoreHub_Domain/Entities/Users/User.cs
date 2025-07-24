using ScoreHub_Domain.Enums;

namespace ScoreHub_Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string GroupNumber { get; set; }
    public Role Role { get; set; }
    
    public TeacherData? TeacherData { get; set; }
    public StudentData? StudentData { get; set; }
    public AssistantData? AssistantData { get; set; }

    
    public User(
        string name, string email, 
        string passwordHash, string groupNumber, Role role,
        TeacherData? teacherData = null,  StudentData? studentData = null, 
        AssistantData? assistantData = null)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        GroupNumber = groupNumber;
        Role = role;
        TeacherData = teacherData;
        StudentData = studentData;
        AssistantData = assistantData;
    }
    
    public static User CreateUser(
        string name, string email, string passwordHash, string groupNumber, Role role,
        TeacherData? teacherData = null,  StudentData? studentData = null, AssistantData? assistantData = null)
    {
        return new User(name, email, passwordHash, groupNumber,role, teacherData, studentData, assistantData);
    }
}
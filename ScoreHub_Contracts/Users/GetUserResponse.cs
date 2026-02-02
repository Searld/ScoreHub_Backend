using LessonMkn.Enums;

namespace ScoreHub_Contracts.Users;

public abstract class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
}

public class TeacherDto : UserDto
{
    public List<Guid>? SubjectIds { get; set; }
}

public class StudentDto : UserDto
{
    public string GroupNumber { get; set; }
    public Guid? LessonId { get; set; }
    public Guid? TeamId { get; set; }
}

public class AssistantDto : UserDto
{
    public Guid? TeamId { get; set; }
}

using ScoreHub_Contracts;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Repositories;
using ScoreHub_Infrastructure.Repositories;

namespace ScoreHub_Application.UseCases;

public class CreateLessonUseCase
{
    private readonly ILessonRepository _lessonRepository;
    private readonly IUserRepository _userRepository;

    public CreateLessonUseCase(ILessonRepository lessonRepository, IUserRepository userRepository)
    {
        _lessonRepository = lessonRepository;
        _userRepository = userRepository;
    }

    public async Task Execute(CreateLessonRequest request)
    {
        List<StudentData> students = new List<StudentData>();
        
        foreach (var id in request.Students)
        {
            var student = await _userRepository.GetStudentByID(id);
            students.Add(student.StudentData);
        }

        var lesson = new Lesson()
        {
            Id = Guid.NewGuid(),
            IsCommandLesson = request.IsCommandLesson,
            Students = students,
            Name = request.Name,
            StartTime = request.StartTime,
            Status = request.Status,
            SubjectId = request.SubjectId
        };
        
        if (request.IsCommandLesson)
        {
            lesson.Teams = new List<Team>();
            foreach (var t in request.Teams)
            {
                List<StudentData> studentsInTeam = new List<StudentData>();
                foreach (var id in t.StudentIds)
                {
                    var student = await _userRepository.GetStudentByID(id);
                    studentsInTeam.Add(student.StudentData);
                }

                var team = new Team()
                {
                    Id = Guid.NewGuid(),
                    Assistant = (await _userRepository.GetAssistantByID(t.AssistantId)).AssistantData,
                    Number = t.Number,
                    Students = studentsInTeam,
                };
                lesson.Teams.Add(team);
            }
        }
        
        _lessonRepository.AddAsync(lesson);
    }
}
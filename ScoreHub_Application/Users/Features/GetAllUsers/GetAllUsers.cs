using Microsoft.EntityFrameworkCore;
using ScoreHub_Application;
using ScoreHub_Contracts.Users;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Repositories.Features.GetWithFilters;
using ScoreHub_Infrastructure;

namespace ScoreHub_Domain.Repositories.Features.GetAllUsers;

public class GetAllUsers : IQueryHandler<IEnumerable<UserDto>, GetAllUsersQuery>
{
    private readonly IUserReadDbContext _context;

    public GetAllUsers(IUserReadDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery query)
    {
        var users = await _context.ReadUsers.ToListAsync();

        var result = new List<UserDto>();

        foreach (var user in users)
        {
            switch (user)
            {
                case Teacher t:
                    result.Add(new TeacherDto
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Email = t.Email,
                        Role = t.Role,
                        SubjectIds = t.Subjects?.Select(s => s.Id).ToList()
                    });
                    break;

                case Student s:
                    result.Add(new StudentDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Email = s.Email,
                        Role = s.Role,
                        GroupNumber = s.GroupNumber,
                        LessonId = s.LessonId,
                        TeamId = s.TeamId
                    });
                    break;

                case Assistant a:
                    result.Add(new AssistantDto
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Email = a.Email,
                        Role = a.Role,
                        TeamId = a.TeamId
                    });
                    break;
            }
        }

        return result;
    }   
}
using System.Diagnostics;
using ScoreHub_Application;
using ScoreHub_Domain.Entities;
using ScoreHub_Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScoreHub_Contracts.Users;

namespace ScoreHub_Domain.Repositories.Features.GetWithFilters;

public class GetUsersByEmailOrId : IQueryHandler<UserDto, GetUsersByEmailOrIdQuery>
{
    private readonly IUserReadDbContext _context;

    public GetUsersByEmailOrId(IUserReadDbContext context)
    {
        _context = context;
    }
    public async Task<UserDto> Handle(GetUsersByEmailOrIdQuery query)
    {
        var users = _context.ReadUsers;
        var id = query.Id;
        var email = query.Email;

        if (id != null && email != null)
            return null;

        User user = null;
        
        if(id != null)
            user = await users.Where(u => u.Id == id).FirstAsync();
        if(email != null)
            user = await users.Where(u => u.Email == email).FirstAsync();
        
        return user switch
        {
            Teacher t => new TeacherDto()
            {
                Id = t.Id,
                Name = t.Name,
                Email = t.Email,
                Role = t.Role,
                SubjectIds = t.Subjects?.Select(s => s.Id).ToList()
            },
            Student s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Role = s.Role,
                GroupNumber = s.GroupNumber,
                LessonId = s.LessonId,
                TeamId = s.TeamId
            },
            Assistant a => new AssistantDto
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email,
                Role = a.Role,
                TeamId = a.TeamId
            },
            _ => throw new InvalidOperationException("Unknown user type")
        };
    }
}
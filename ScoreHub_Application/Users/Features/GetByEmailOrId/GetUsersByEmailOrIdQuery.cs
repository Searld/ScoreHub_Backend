using ScoreHub_Application.Abstractions;

namespace ScoreHub_Application.Users.Features.GetByEmailOrId;

public record GetUsersByEmailOrIdQuery(Guid? Id = null, string? Email=null) : IQuery;
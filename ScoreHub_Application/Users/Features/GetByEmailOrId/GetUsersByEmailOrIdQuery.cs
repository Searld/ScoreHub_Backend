using ScoreHub_Infrastructure;

namespace ScoreHub_Domain.Repositories.Features.GetWithFilters;

public record GetUsersByEmailOrIdQuery(Guid? Id = null, string? Email=null) : IQuery;
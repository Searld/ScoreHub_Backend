namespace ScoreHub_Contracts;

public record TeamDto(Guid Id, string Number, List<Guid>? StudentIds, Guid AssistantId);
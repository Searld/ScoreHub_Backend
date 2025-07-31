namespace ScoreHub_Contracts;

public record TeamRequest(int Number, List<Guid> StudentIds, Guid AssistantId);
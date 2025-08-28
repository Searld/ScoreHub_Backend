namespace ScoreHub_Infrastructure;

public interface ICommand;

public interface ICommandHandler<TResponse, in TCommand> 
    where TCommand : ICommand
{
    Task<TResponse> Handle(TCommand command);
}

public interface ICommandHandler<in TCommand> 
    where TCommand : ICommand
{
    Task Handle(TCommand command);
}


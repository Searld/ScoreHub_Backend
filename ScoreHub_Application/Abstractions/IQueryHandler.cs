﻿namespace ScoreHub_Infrastructure;

public interface IQuery;

public interface IQueryHandler<TResponse, in TQuery> 
    where TQuery : IQuery
{
    Task<TResponse> Handle(TQuery query);
}
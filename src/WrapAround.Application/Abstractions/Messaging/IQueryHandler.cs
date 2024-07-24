using MediatR;

namespace WrapAround.Application.Abstractions.Messaging;

/// <summary>
/// Represents the handler for a query of type <typeparamref name="TQuery"/>.
/// </summary>
/// <typeparam name="TQuery">The query type.</typeparam>
/// <typeparam name="TResponse">The query response type.</typeparam>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}

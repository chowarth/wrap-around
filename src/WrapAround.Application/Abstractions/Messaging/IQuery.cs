﻿using MediatR;

namespace WrapAround.Application.Abstractions.Messaging;

/// <summary>
/// Represents a query for type <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TResponse">The query response type.</typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse>
{
}

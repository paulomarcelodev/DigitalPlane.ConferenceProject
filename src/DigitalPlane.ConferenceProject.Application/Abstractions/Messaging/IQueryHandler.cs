using MediatR;
using OperationResult;

namespace DigitalPlane.ConferenceProject.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
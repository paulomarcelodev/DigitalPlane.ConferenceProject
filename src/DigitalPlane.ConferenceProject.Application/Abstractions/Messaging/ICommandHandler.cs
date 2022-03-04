using MediatR;
using OperationResult;

namespace DigitalPlane.ConferenceProject.Application.Abstractions.Messaging;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}
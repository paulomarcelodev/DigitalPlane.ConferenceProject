using MediatR;
using OperationResult;

namespace DigitalPlane.ConferenceProject.Application.Abstractions.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
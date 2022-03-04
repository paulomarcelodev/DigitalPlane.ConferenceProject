using MediatR;

namespace DigitalPlane.ConferenceProject.Application.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
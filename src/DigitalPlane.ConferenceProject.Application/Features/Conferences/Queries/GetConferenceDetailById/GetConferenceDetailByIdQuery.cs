using DigitalPlane.ConferenceProject.Application.Abstractions.Messaging;
using OperationResult;

namespace DigitalPlane.ConferenceProject.Application.Features.Conferences.Queries.GetConferenceDetailById;

public class GetConferenceDetailByIdQuery : IQuery<Result<GetConferenceDetailByIdViewModel>>
{
    public Guid Id { get; set; }
}
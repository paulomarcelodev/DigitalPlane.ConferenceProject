using DigitalPlane.ConferenceProject.Application.Abstractions.Messaging;
using OperationResult;

namespace DigitalPlane.ConferenceProject.Application.Features.Conferences.Commands.CreateConference;

public class CreateConferenceCommand : ICommand<Result<string>>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public bool HasLimitOfAttendee { get; set; }
    public int? AttendeeLimit { get; set; }
    public DateTime Start { get; set; }
}
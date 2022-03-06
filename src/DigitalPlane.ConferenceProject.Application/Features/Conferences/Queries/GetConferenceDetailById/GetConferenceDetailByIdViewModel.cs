using DigitalPlane.ConferenceProject.Application.Abstractions;

namespace DigitalPlane.ConferenceProject.Application.Features.Conferences.Queries.GetConferenceDetailById;

public class GetConferenceDetailByIdViewModel : IViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public bool HasLimitOfAttendee { get; set; }
    public int? AttendeeLimit { get; set; }
    public DateTime Start { get; set; }
    public List<GetConferenceDetailByIdProposalDto>? Proposals { get; set; }
}
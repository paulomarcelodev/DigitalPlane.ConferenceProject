using AutoMapper;
using DigitalPlane.ConferenceProject.Application.Features.Conference.CreateConference;

namespace DigitalPlane.ConferenceProject.Application.Features.Conference;

public class ConferenceProfile : Profile
{
    public ConferenceProfile()
    {
        CreateMap<CreateConferenceCommand, Domain.Entities.Conference>();
    }
}
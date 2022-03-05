using AutoMapper;
using DigitalPlane.ConferenceProject.Application.Features.Conferences.CreateConference;

namespace DigitalPlane.ConferenceProject.Application.Features.Conferences;

public class ConferenceProfile : Profile
{
    public ConferenceProfile()
    {
        CreateMap<CreateConferenceCommand, Domain.Entities.Conference>();
    }
}
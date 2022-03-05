using AutoMapper;
using DigitalPlane.ConferenceProject.Application.Features.Conferences.CreateConference;
using DigitalPlane.ConferenceProject.Domain.Entities;

namespace DigitalPlane.ConferenceProject.Application.Features.Conferences;

public class FeatureProfile : Profile
{
    public FeatureProfile()
    {
        CreateMap<CreateConferenceCommand, Conference>();
    }
}
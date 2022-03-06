using AutoMapper;
using DigitalPlane.ConferenceProject.Application.Features.Conferences.Commands.CreateConference;
using DigitalPlane.ConferenceProject.Domain.Entities;

namespace DigitalPlane.ConferenceProject.Application.Features.Conferences;

public class ConferenceProfile : Profile
{
    public ConferenceProfile()
    {
        CreateMap<CreateConferenceCommand, Conference>();
    }
}
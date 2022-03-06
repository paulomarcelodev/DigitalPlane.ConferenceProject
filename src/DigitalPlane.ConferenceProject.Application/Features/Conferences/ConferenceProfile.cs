using AutoMapper;
using DigitalPlane.ConferenceProject.Application.Features.Conferences.Commands.CreateConference;
using DigitalPlane.ConferenceProject.Application.Features.Conferences.Queries.GetConferenceDetailById;
using DigitalPlane.ConferenceProject.Domain.Entities;

namespace DigitalPlane.ConferenceProject.Application.Features.Conferences;

public class ConferenceProfile : Profile
{
    public ConferenceProfile()
    {
        CreateMap<CreateConferenceCommand, Conference>();
        CreateMap<Proposal, GetConferenceDetailByIdProposalDto>();
        CreateMap<Conference, GetConferenceDetailByIdViewModel>();
    }
}
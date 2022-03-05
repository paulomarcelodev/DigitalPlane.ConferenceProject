using AutoMapper;
using DigitalPlane.ConferenceProject.Application.Features.Proposals.CreateProposal;
using DigitalPlane.ConferenceProject.Domain.Entities;

namespace DigitalPlane.ConferenceProject.Application.Features.Proposals;

public class FeatureProfile : Profile
{
    public FeatureProfile()
    {
        CreateMap<CreateProposalCommand, Proposal>();
    }
}
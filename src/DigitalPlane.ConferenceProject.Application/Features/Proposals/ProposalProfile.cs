using AutoMapper;
using DigitalPlane.ConferenceProject.Application.Features.Proposals.Commands.CreateProposal;
using DigitalPlane.ConferenceProject.Domain.Entities;

namespace DigitalPlane.ConferenceProject.Application.Features.Proposals;

public class ProposalProfile : Profile
{
    public ProposalProfile()
    {
        CreateMap<CreateProposalCommand, Proposal>();
    }
}
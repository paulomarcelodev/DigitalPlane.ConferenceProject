using DigitalPlane.ConferenceProject.Domain.Entities;

namespace DigitalPlane.ConferenceProject.Application.Contracts.Persistence;

public interface IProposalRepository : IAsyncRepository<Proposal>
{
}
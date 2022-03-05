using DigitalPlane.ConferenceProject.Domain.Entities;

namespace DigitalPlane.ConferenceProject.Application.Contracts.Persistence;

public interface IProposalRepository : IAsyncRepository<Proposal>
{
    Task<bool> IsUnique(Guid conferenceId, string title, string speaker);
}
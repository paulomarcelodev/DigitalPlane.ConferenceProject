using DigitalPlane.ConferenceProject.Application.Contracts.Persistence;
using DigitalPlane.ConferenceProject.Domain.Entities;

namespace DigitalPlane.ConferenceProject.Persistence.Repositories;

public class ProposalRepository : BaseRepository<Proposal>, IProposalRepository
{
    public ProposalRepository(ConferenceProjectDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> IsUnique(Guid conferenceId, string title, string speaker)
    {
        return Task.FromResult(!_dbContext.Proposals!.Any(e =>
            e.Speaker != null && e.Title != null &&
            e.ConferenceId != conferenceId && e.Title.Equals(title) &&
            e.Speaker.Equals(speaker))
        );
    }
}
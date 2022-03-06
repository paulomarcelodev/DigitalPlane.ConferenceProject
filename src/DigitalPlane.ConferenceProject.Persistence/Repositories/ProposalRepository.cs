using DigitalPlane.ConferenceProject.Application.Contracts.Persistence;
using DigitalPlane.ConferenceProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalPlane.ConferenceProject.Persistence.Repositories;

public class ProposalRepository : BaseRepository<Proposal>, IProposalRepository
{
    public ProposalRepository(ConferenceProjectDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsUnique(Guid conferenceId, string title, string speaker)
    {
        return (await _dbContext.Proposals?.FirstOrDefaultAsync(p =>
            p.ConferenceId == conferenceId && p.Title == title && p.Speaker == speaker)! ?? null) is null;
    }

    public Task<List<Proposal>>? ListByConferenceId(Guid conferenceId)
    {
        return _dbContext.Proposals?
            .AsNoTracking()
            .Where(e => e.ConferenceId == conferenceId)
            .OrderBy(e => e.Approved)
            .ThenBy(e => e.Title)
            .ToListAsync();
    }
}
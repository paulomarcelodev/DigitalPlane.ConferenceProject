using DigitalPlane.ConferenceProject.Application.Contracts.Persistence;
using DigitalPlane.ConferenceProject.Domain.Entities;

namespace DigitalPlane.ConferenceProject.Persistence.Repositories;

public class ConferenceRepository : BaseRepository<Conference>, IConferenceRepository
{
    public ConferenceRepository(ConferenceProjectDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> IsNameAndLocationUnique(string name, string location)
    {
        var matches = _dbContext.Conferences!.Any(e => e.Name.Equals(name) && e.Location.Equals(location));
        return Task.FromResult(!matches);
    }
}
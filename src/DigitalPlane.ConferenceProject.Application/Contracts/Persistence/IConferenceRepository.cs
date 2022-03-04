using DigitalPlane.ConferenceProject.Domain.Entities;

namespace DigitalPlane.ConferenceProject.Application.Contracts.Persistence;

public interface IConferenceRepository : IAsyncRepository<Conference>
{
    Task<bool> IsNameAndLocationUnique(string name, string location);
}
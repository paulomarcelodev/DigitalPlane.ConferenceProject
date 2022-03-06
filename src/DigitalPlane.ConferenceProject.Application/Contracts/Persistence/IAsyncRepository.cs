using DigitalPlane.ConferenceProject.Domain.Common;

namespace DigitalPlane.ConferenceProject.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : Entity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByIdAsNoTrackingAsync(Guid id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
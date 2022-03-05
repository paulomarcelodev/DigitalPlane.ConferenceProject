using DigitalPlane.ConferenceProject.Domain.Common;
using DigitalPlane.ConferenceProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalPlane.ConferenceProject.Persistence;

public class ConferenceProjectDbContext : DbContext
{
    public ConferenceProjectDbContext(DbContextOptions<ConferenceProjectDbContext> options)
        : base(options)
    {
    }

    public DbSet<Conference>? Conferences { get; set; }
    public DbSet<Proposal>? Proposals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConferenceProjectDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
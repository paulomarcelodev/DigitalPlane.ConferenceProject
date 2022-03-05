using DigitalPlane.ConferenceProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalPlane.ConferenceProject.Persistence.Configurations;

public class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
{
    public void Configure(EntityTypeBuilder<Proposal> builder)
    {
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Speaker)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Approved)
            .IsRequired();

        builder.Property(e => e.ConferenceId)
            .IsRequired();

        builder
            .HasOne(e => e.Conference)
            .WithMany(c => c.Proposals)
            .IsRequired();

        builder.HasIndex(e => e.Title);
        builder.HasIndex(e => e.Speaker);
    }
}
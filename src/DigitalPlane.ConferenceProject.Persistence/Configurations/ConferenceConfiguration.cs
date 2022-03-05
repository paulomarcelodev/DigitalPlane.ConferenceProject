using DigitalPlane.ConferenceProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalPlane.ConferenceProject.Persistence.Configurations;

public class ConferenceConfiguration : IEntityTypeConfiguration<Conference>
{
    public void Configure(EntityTypeBuilder<Conference> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Location)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.HasLimitOfAttendee)
            .IsRequired();

        builder.Property(e => e.Start)
            .IsRequired();

        builder
            .HasMany(c => c.Proposals)
            .WithOne(e => e.Conference);

        builder.HasIndex(e => e.Name);
    }
}
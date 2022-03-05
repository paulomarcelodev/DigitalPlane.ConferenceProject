using DigitalPlane.ConferenceProject.Domain.Common;

namespace DigitalPlane.ConferenceProject.Domain.Entities;

public class Proposal : AuditableEntity
{
    public Guid ConferenceId { get; set; }
    public Conference? Conference { get; set; }
    public string? Speaker { get; set; }
    public string? Title { get; set; }
    public bool Approved { get; set; }
}
using DigitalPlane.ConferenceProject.Domain.Common;

namespace DigitalPlane.ConferenceProject.Domain.Entities;

public class Attendee : AuditableEntity
{
    public Guid ConferenceId { get; set; }
    public Conference Conference { get; set; }
    public string Name { get; set; }
}
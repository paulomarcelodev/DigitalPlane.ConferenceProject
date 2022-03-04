using DigitalPlane.ConferenceProject.Domain.Common;

namespace DigitalPlane.ConferenceProject.Domain.Entities;

public class Conference : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime Start { get; set; }
}
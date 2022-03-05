using DigitalPlane.ConferenceProject.Application.Abstractions.Messaging;
using OperationResult;

namespace DigitalPlane.ConferenceProject.Application.Features.Proposals.CreateProposal;

public class CreateProposalCommand : ICommand<Result<string>>
{
    public Guid ConferenceId { get; set; }
    public string? Title { get; set; }
    public string? Speaker { get; set; }
}
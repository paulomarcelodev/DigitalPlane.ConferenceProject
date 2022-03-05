using DigitalPlane.ConferenceProject.Application.Contracts.Persistence;
using FluentValidation;

namespace DigitalPlane.ConferenceProject.Application.Features.Proposals.CreateProposal;

public class CreateProposalCommandValidator : AbstractValidator<CreateProposalCommand>
{
    private const int TitleLength = 50;
    private const int SpeakLength = 100;
    private readonly IProposalRepository _proposalRepository;
    private readonly IConferenceRepository _conferenceRepository;

    public CreateProposalCommandValidator(IProposalRepository proposalRepository, IConferenceRepository conferenceRepository)
    {
        _proposalRepository = proposalRepository;
        _conferenceRepository = conferenceRepository;

        RuleFor(p => p.Title)
            .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(TitleLength).WithMessage("{PropertyName} must not exceed " + TitleLength + " characters.");

        RuleFor(p => p.Speaker)
            .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(SpeakLength).WithMessage("{PropertyName} must not exceed " + SpeakLength + " characters.");

        RuleFor(p => p.ConferenceId)
            .NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
        
        RuleFor(e => e)
            .MustAsync(ConferenceExists)
            .WithMessage($"The conference not found.");
        
        RuleFor(e => e)
            .MustAsync(ConferenceIsOpenToProposals)
            .WithMessage($"The conference already closed to proposals.");
        
        RuleFor(e => e)
            .MustAsync(ProposalIsUnique)
            .WithMessage($"The proposal with the same title, speaker for this conference already exists.");
        
    }

    private async Task<bool> ConferenceExists(CreateProposalCommand c, CancellationToken token) 
        => (await _conferenceRepository.GetByIdAsync(c.ConferenceId)) is not null;
    private async Task<bool> ConferenceIsOpenToProposals(CreateProposalCommand c, CancellationToken token) 
        => (await _conferenceRepository.GetByIdAsync(c.ConferenceId))?.IsOpenToProposals() ?? false;
    private Task<bool> ProposalIsUnique(CreateProposalCommand c, CancellationToken token) 
        => _proposalRepository.IsUnique(c.ConferenceId, c.Title, c.Speaker);
}


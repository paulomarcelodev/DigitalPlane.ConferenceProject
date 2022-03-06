using DigitalPlane.ConferenceProject.Application.Contracts.Persistence;
using FluentValidation;

namespace DigitalPlane.ConferenceProject.Application.Features.Conferences.Commands.CreateConference;

public class CreateConferenceCommandValidator : AbstractValidator<CreateConferenceCommand>
{
    private const int NameLength = 50;
    private const int DescriptionLength = 255;
    private const int LocationLength = 50;
    private readonly IConferenceRepository _conferenceRepository;

    public CreateConferenceCommandValidator(IConferenceRepository conferenceRepository)
    {
        _conferenceRepository = conferenceRepository;

        RuleFor(p => p.Name)
            .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(NameLength).WithMessage("{PropertyName} must not exceed " + NameLength + " characters.");

        RuleFor(p => p.Description)
            .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(DescriptionLength)
            .WithMessage("{PropertyName} must not exceed " + DescriptionLength + " characters.");

        RuleFor(p => p.Location)
            .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(LocationLength)
            .WithMessage("{PropertyName} must not exceed " + LocationLength + " characters.");

        RuleFor(p => p.Start)
            .GreaterThan(DateTime.Now).WithMessage("{PropertyName} must be a future date.");

        When(p => p.HasLimitOfAttendee, () =>
        {
            RuleFor(p => p.AttendeeLimit)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must greater than 0");
        });

        RuleFor(e => e)
            .MustAsync(NameAndLocationUnique)
            .WithMessage("A conference with the same name and location already exists.");
    }

    private Task<bool> NameAndLocationUnique(CreateConferenceCommand c, CancellationToken token)
    {
        return _conferenceRepository.IsNameAndLocationUnique(c.Name!, c.Location!);
    }
}
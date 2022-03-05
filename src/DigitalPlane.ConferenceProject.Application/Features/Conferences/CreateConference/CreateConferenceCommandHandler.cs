using AutoMapper;
using DigitalPlane.ConferenceProject.Application.Abstractions.Messaging;
using DigitalPlane.ConferenceProject.Application.Contracts.Persistence;
using DigitalPlane.ConferenceProject.Application.Exceptions;
using DigitalPlane.ConferenceProject.Domain.Entities;
using OperationResult;

namespace DigitalPlane.ConferenceProject.Application.Features.Conferences.CreateConference;

public class CreateConferenceCommandHandler : ICommandHandler<CreateConferenceCommand, Result<string>>
{
    private readonly IMapper _mapper;
    private readonly IConferenceRepository _conferenceRepository;

    public CreateConferenceCommandHandler(IMapper mapper, IConferenceRepository conferenceRepository)
    {
        _mapper = mapper;
        _conferenceRepository = conferenceRepository;
    }

    public async Task<Result<string>> Handle(CreateConferenceCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateConferenceCommandValidator(_conferenceRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Error<string>(new ValidationException(validationResult));
        }
        var newEntity = _mapper.Map<Conference>(request);
        newEntity = await _conferenceRepository.AddAsync(newEntity);
        return Result.Success(newEntity.Id.ToString());
    }
}
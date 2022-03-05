using AutoMapper;
using DigitalPlane.ConferenceProject.Application.Abstractions.Messaging;
using DigitalPlane.ConferenceProject.Application.Contracts.Persistence;
using DigitalPlane.ConferenceProject.Application.Exceptions;
using DigitalPlane.ConferenceProject.Domain.Entities;
using OperationResult;

namespace DigitalPlane.ConferenceProject.Application.Features.Proposals.CreateProposal;


public class CreateProposalCommandHandler : ICommandHandler<CreateProposalCommand, Result<string>>
{
    private readonly IMapper _mapper;
    private readonly IProposalRepository _proposalRepository;
    private readonly IConferenceRepository _conferenceRepository;

    public CreateProposalCommandHandler(IMapper mapper, IProposalRepository proposalRepository, IConferenceRepository conferenceRepository)
    {
        _mapper = mapper;
        _proposalRepository = proposalRepository;
        _conferenceRepository = conferenceRepository;
    }

    public async Task<Result<string>> Handle(CreateProposalCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProposalCommandValidator(_proposalRepository, _conferenceRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Error<string>(new ValidationException(validationResult));
        }
        var newEntity = _mapper.Map<Proposal>(request);
        newEntity = await _proposalRepository.AddAsync(newEntity);
        return Result.Success(newEntity.Id.ToString());
    }
}
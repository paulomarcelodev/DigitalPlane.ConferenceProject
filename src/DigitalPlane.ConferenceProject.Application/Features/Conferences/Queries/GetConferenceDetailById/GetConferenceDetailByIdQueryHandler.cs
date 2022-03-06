using AutoMapper;
using DigitalPlane.ConferenceProject.Application.Abstractions.Messaging;
using DigitalPlane.ConferenceProject.Application.Contracts.Persistence;
using DigitalPlane.ConferenceProject.Application.Exceptions;
using OperationResult;

namespace DigitalPlane.ConferenceProject.Application.Features.Conferences.Queries.GetConferenceDetailById;

public class
    GetConferenceDetailByIdQueryHandler : IQueryHandler<GetConferenceDetailByIdQuery,
        Result<GetConferenceDetailByIdViewModel>>
{
    private readonly IConferenceRepository _conferenceRepository;
    private readonly IMapper _mapper;
    private readonly IProposalRepository _proposalRepository;

    public GetConferenceDetailByIdQueryHandler(IMapper mapper, IConferenceRepository conferenceRepository,
        IProposalRepository proposalRepository)
    {
        _mapper = mapper;
        _conferenceRepository = conferenceRepository;
        _proposalRepository = proposalRepository;
    }

    public async Task<Result<GetConferenceDetailByIdViewModel>> Handle(GetConferenceDetailByIdQuery request,
        CancellationToken cancellationToken)
    {
        var conference = await _conferenceRepository.GetByIdAsNoTrackingAsync(request.Id);
        if (conference is null)
            return Result.Error<GetConferenceDetailByIdViewModel>(new NotFoundException("Conference", "id"));
        var proposals = await _proposalRepository.ListByConferenceId(conference.Id)!;
        conference.Proposals = proposals;
        return Result.Success(_mapper.Map<GetConferenceDetailByIdViewModel>(conference));
    }
}
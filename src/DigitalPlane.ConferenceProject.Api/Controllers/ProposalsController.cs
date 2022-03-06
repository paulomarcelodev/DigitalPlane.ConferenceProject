using DigitalPlane.ConferenceProject.Api.Abstractions;
using DigitalPlane.ConferenceProject.Application.Features.Proposals.Commands.CreateProposal;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPlane.ConferenceProject.Api.Controllers;

[Route("api/[controller]")]
public class ProposalsController : BaseController
{
    public ProposalsController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> CreateProposalCommand([FromBody] CreateProposalCommand command,
        CancellationToken cancellationToken)
    {
        return SendCommand(command, cancellationToken);
    }
}
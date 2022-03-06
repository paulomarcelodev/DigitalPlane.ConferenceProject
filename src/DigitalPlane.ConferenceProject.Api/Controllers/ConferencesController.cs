using DigitalPlane.ConferenceProject.Api.Abstractions;
using DigitalPlane.ConferenceProject.Application.Features.Conferences.Commands.CreateConference;
using DigitalPlane.ConferenceProject.Application.Features.Conferences.Queries.GetConferenceDetailById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPlane.ConferenceProject.Api.Controllers;

[Route("api/[controller]")]
public class ConferencesController : BaseController
{
    public ConferencesController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateConferenceCommand([FromBody] CreateConferenceCommand command,
        CancellationToken cancellationToken)
    {
        return HandlerResult(await _sender.Send(command, cancellationToken));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetConferenceDetailByIdQuery([FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        return HandlerResult(await _sender.Send(new GetConferenceDetailByIdQuery { Id = id }, cancellationToken));
    }
}
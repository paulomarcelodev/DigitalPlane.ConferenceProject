using DigitalPlane.ConferenceProject.Api.Abstractions;
using DigitalPlane.ConferenceProject.Application.Features.Conferences.Commands.CreateConference;
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
    public Task<IActionResult> CreateConferenceCommand([FromBody] CreateConferenceCommand command,
        CancellationToken cancellationToken)
        => SendCommand(command, cancellationToken);
}
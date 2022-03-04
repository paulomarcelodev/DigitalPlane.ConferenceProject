using DigitalPlane.ConferenceProject.Application.Features.Conference.CreateConference;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPlane.ConferenceProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConferencesController : ControllerBase
{
    private readonly ISender _sender;
    
    public ConferencesController(ISender sender) => _sender = sender;
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateConferenceCommand([FromBody] CreateConferenceCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }
        return Ok(result); 
    }
}
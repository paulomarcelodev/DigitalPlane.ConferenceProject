using DigitalPlane.ConferenceProject.Application.Abstractions.Messaging;
using DigitalPlane.ConferenceProject.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationResult;

namespace DigitalPlane.ConferenceProject.Api.Abstractions;

[ApiController]
public abstract class BaseController : ControllerBase
{
    private readonly ISender _sender;
    
    protected BaseController(ISender sender) => _sender = sender;
    
    public async Task<IActionResult> SendCommand(ICommand<Result> command, CancellationToken token) => 
        HandlerResult(await _sender.Send(command, token));

    public async Task<IActionResult> SendCommand(ICommand<Result<string>> command, CancellationToken token) =>
        HandlerResult(await _sender.Send(command, token));

    private IActionResult HandlerResult(Result result)=>
        result.IsSuccess ? HandlerResultSuccess(result) : HandlerFailResult(result.Exception);

    private IActionResult HandlerResult(Result<string> result) =>
        result.IsSuccess ? HandlerResultSuccess(result) : HandlerFailResult(result.Exception);
    
    private IActionResult HandlerResultSuccess(Result result) => 
        Ok(new GenericResponse(result));

    private IActionResult HandlerResultSuccess(Result<string> result) =>
        StatusCode(201, new CreateResponse(result.Value!));

    private IActionResult HandlerFailResult(Exception exception) =>
        exception switch
        {
            ValidationException e => BadRequest(new ErrorResponse(e.ValidationErrors)),
            _ => StatusCode(500)
        };

}
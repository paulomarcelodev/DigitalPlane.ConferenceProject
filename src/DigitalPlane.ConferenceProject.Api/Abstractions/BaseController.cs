using DigitalPlane.ConferenceProject.Application.Abstractions;
using DigitalPlane.ConferenceProject.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationResult;

namespace DigitalPlane.ConferenceProject.Api.Abstractions;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly ISender _sender;

    protected BaseController(ISender sender) => _sender = sender;

    protected IActionResult HandlerResult(Result<string> result)
    {
        return result.IsSuccess ? HandlerResultSuccess(result) : HandlerFailResult(result.Exception);
    }

    protected IActionResult HandlerResult<TViewModel>(Result<TViewModel> result) where TViewModel : IViewModel
    {
        return Ok(new GenericResponse(result.Value!));
    }

    private IActionResult HandlerResultSuccess(Result<string> result) =>
        StatusCode(201, new CreateResponse(result.Value!));

    private IActionResult HandlerFailResult(Exception exception) =>
        exception switch
        {
            ValidationException e => BadRequest(new ErrorResponse(e.ValidationErrors)),
            NotFoundException e => BadRequest(new ErrorResponse(new List<string> { e.Message })),
            _ => StatusCode(500)
        };
}
namespace DigitalPlane.ConferenceProject.Api.Abstractions;

public class ErrorResponse : BaseResponse
{
    public ErrorResponse(List<string> errors) : base(false)
    {
        Errors = errors;
    }
    
    public List<string>? Errors { get; }
}
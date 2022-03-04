namespace DigitalPlane.ConferenceProject.Api.Abstractions;

public abstract class BaseResponse
{
    protected BaseResponse()
    {
        Success = true;
    }

    protected BaseResponse(bool success)
    {
        Success = success;
    }

    public bool Success { get;  }
}
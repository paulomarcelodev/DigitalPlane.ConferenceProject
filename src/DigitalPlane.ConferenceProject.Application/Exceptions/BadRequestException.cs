namespace DigitalPlane.ConferenceProject.Application.Exceptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string? message) : base(message)
    {
    }
}
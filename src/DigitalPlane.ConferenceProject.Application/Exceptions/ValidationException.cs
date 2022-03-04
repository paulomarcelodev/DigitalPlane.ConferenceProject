using FluentValidation.Results;

namespace DigitalPlane.ConferenceProject.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public List<string> ValidationErrors { get; }
    
    public ValidationException(ValidationResult validationResult)
    {
        ValidationErrors = new List<string>();
        foreach (var validationError in validationResult.Errors)
        {
            ValidationErrors.Add(validationError.ErrorMessage);
        }
    }
}
using DigitalPlane.ConferenceProject.Application.Abstractions;

namespace DigitalPlane.ConferenceProject.Api.Abstractions;

public class CreateResponse : BaseResponse
{
    public CreateResponse(string id)
    {
        Data = new DataEntityId(id);
    }

    public DataEntityId Data { get; }
}

public class GenericResponse : BaseResponse
{
    public GenericResponse(IViewModel viewModel)
    {
        Data = viewModel;
    }

    public IViewModel Data { get; }
}
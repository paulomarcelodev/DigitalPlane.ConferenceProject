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
    public GenericResponse(object obj)
    {
        Data = obj;
    }

    public object Data { get; }
}
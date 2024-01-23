namespace first_web_api.Services;

public class ServiceB : IServiceTask
{
    public Guid GetTransientGuid()
    {
        throw new NotImplementedException();
    }

    public Guid GetScopedGuid()
    {
        throw new NotImplementedException();
    }

    public Guid GetSingletonGuid()
    {
        throw new NotImplementedException();
    }
}
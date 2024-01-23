namespace first_web_api.Services;

public class ServiceA : IServiceTask
{
    private readonly ILogger<ServiceA> _logger;
    private readonly ServiceTransient _serviceTransient;
    private readonly ServiceScoped _serviceScoped;
    private readonly ServiceSingleton _serviceSingleton;

    public ServiceA(ILogger<ServiceA> logger, ServiceTransient serviceTransient
        , ServiceScoped serviceScoped
        , ServiceSingleton serviceSingleton)
    {
        _logger = logger;
        _serviceTransient = serviceTransient;
        _serviceScoped = serviceScoped;
        _serviceSingleton = serviceSingleton;
    }

    public Guid GetTransientGuid()
    {
        return _serviceTransient.Guid;
    }

    public Guid GetScopedGuid()
    {
        return _serviceScoped.Guid;
    }

    public Guid GetSingletonGuid()
    {
        return _serviceSingleton.Guid;
    }
}
namespace first_web_api.Services;

public interface IServiceTask
{
    public Guid GetTransientGuid();
    public Guid GetScopedGuid();
    public Guid GetSingletonGuid();
}

public class ServiceTransient
{
    public Guid Guid { get; } = Guid.NewGuid();
}

public class ServiceScoped
{
    public Guid Guid { get; } = Guid.NewGuid();
}

public class ServiceSingleton
{
    public Guid Guid { get; } = Guid.NewGuid();
}
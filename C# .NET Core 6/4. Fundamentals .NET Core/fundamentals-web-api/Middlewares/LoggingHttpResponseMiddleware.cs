namespace first_web_api.Middlewares;

public class LoggingHttpResponseMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingHttpResponseMiddleware> _logger;

    public LoggingHttpResponseMiddleware(RequestDelegate next,
        ILogger<LoggingHttpResponseMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        using var ms = new MemoryStream();
        var bodyResponse = context.Response.Body;
        context.Response.Body = ms;
        await _next.Invoke(context);

        ms.Seek(0, SeekOrigin.Begin);
        var res = new StreamReader(ms).ReadToEnd();
        ms.Seek(0, SeekOrigin.Begin);

        await ms.CopyToAsync(bodyResponse);
        context.Response.Body = bodyResponse;

        _logger.LogInformation($"Response: {res}");
    }
}

public static class LoggingHttpResponseMiddlewareExtensions
{
    public static IApplicationBuilder UseLoggingHttpResponseMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoggingHttpResponseMiddleware>();
    }
}
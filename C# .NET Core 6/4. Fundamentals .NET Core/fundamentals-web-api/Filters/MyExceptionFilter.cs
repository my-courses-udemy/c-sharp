using Microsoft.AspNetCore.Mvc.Filters;

namespace first_web_api.Filters;

public class MyExceptionFilter : ExceptionFilterAttribute
{
    private readonly ILogger<MyExceptionFilter> _logger;

    public MyExceptionFilter(ILogger<MyExceptionFilter> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Exception caught in MyExceptionFilter");
        base.OnException(context);
    }
}
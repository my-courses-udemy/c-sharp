using Microsoft.AspNetCore.Mvc.Filters;

namespace first_web_api.Filters;

public class MyActionFilter(ILogger<MyActionFilter> logger) : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        logger.LogInformation("Action is executing before the controller");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        logger.LogInformation("Action is executed after the controller");
    }
}
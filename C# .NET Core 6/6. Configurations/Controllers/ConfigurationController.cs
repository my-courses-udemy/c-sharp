using Microsoft.AspNetCore.Mvc;

namespace _6._Configurations.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConfigurationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public ConfigurationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return _configuration["LastName"] == null
            ? NotFound()
            : Ok(_configuration["LastName"]);
    }

    [HttpGet("GetConnectionString")]
    public IActionResult GetConnectionString()
    {
        var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        Console.WriteLine($"Connection String: {connectionString}");

        return _configuration.GetConnectionString("DefaultConnection") == null
            ? NotFound()
            : Ok(_configuration.GetConnectionString("DefaultConnection"));
    }

    [HttpGet("Env")]
    public IActionResult GetEnv()
    {
        var env = _configuration["LASTNAME_ENV"];
        Console.WriteLine($"Environment: {env}");

        return env == null
            ? NotFound()
            : Ok(env);
    }
    
    [HttpGet("CommandLine")]
    public IActionResult GetCommandLine()
    {
        var commandLine = _configuration["LASTNAME_COMMANDLINE"];
        Console.WriteLine($"Command Line: {commandLine}");

        return commandLine == null
            ? NotFound()
            : Ok(commandLine);
    }
}
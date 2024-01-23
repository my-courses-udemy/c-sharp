using static System.DateTime;

namespace first_web_api.Services;

public class FileWriter : IHostedService
{
    private readonly IWebHostEnvironment _env;
    private const string FileName = "file1.txt";
    private Timer _timer;

    public FileWriter(IWebHostEnvironment env)
    {
        _env = env;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Write("Init process");
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer.DisposeAsync();
        Write("Final process");
        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        Write($"Process in progress at {Now:dd/MM/yyyy HH:mm:ss}");
    }

    private void Write(string message)
    {
        var path = Path.Combine(_env.ContentRootPath, "Files", FileName);
        using var sw = File.AppendText(path);
        sw.WriteLine(message);
    }
}
using System.Text.Json.Serialization;
using first_web_api.Db;
using first_web_api.Filters;
using first_web_api.Middlewares;
using first_web_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IServiceTask, ServiceA>();
builder.Services.AddTransient<ServiceTransient>();
builder.Services.AddScoped<ServiceScoped>();
builder.Services.AddSingleton<ServiceSingleton>();

builder.Services.AddTransient<MyActionFilter>();

builder.Services.AddHostedService<FileWriter>();

builder.Services.AddResponseCaching();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers(opt => { opt.Filters.Add(typeof(MyExceptionFilter)); })
    .AddJsonOptions(opt
        => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
// app.UseMiddleware<LoggingHttpResponseMiddleware>();
app.UseLoggingHttpResponseMiddleware();

app.Map("/route1", a =>
{
    a.Run(async context =>
    {
        await context.Response.WriteAsync("Pipe intercepted the pipeline " +
                                          "and returned this message");
    });
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
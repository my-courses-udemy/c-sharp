using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using minimum_api_BD.models;
using minimum_api_BD.repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";

//! builder.Services.AddDbContext<PizzaRepo>(options =>
//!     options.UseInMemoryDatabase("items")
//! );
builder.Services.AddSqlite<PizzaRepo>(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PizzaStore API",
        Description = "Making the Pizzas you love",
        Version = "v1"
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1"); });

app.MapGet("/", () => "Hello World!");
app.MapGet("/pizzas", async (PizzaRepo db) => await db.Pizzas.ToListAsync());
app.MapPost("/pizzas", async (PizzaRepo db, Pizza pizza) =>
{
    await db.Pizzas.AddAsync(pizza);
    await db.SaveChangesAsync();
    return Results.Created($"/pizzas/{pizza.Id}", pizza);
});
app.MapGet("/pizzas/{id:int}", async (PizzaRepo db, int id) => await db.Pizzas.FindAsync(id));
app.MapPut("/pizzas/{id:int}", async (PizzaRepo db, Pizza pizzaUpdate, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();
    pizza.Name = pizzaUpdate.Name;
    pizza.Description = pizzaUpdate.Description;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/pizzas/{id:int}", async (PizzaRepo db, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();
    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
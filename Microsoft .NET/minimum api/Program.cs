using minimum_api.entity;
using minimum_api.repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new()
            { Title = "My API", Version = "v1" });
    });
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

app.MapGet("/", () => "Hello World!");
app.MapGet("/pizzas", () => PizzaRepo.GetPizzas());
app.MapGet("/pizzas/{id}", (int id) => PizzaRepo.GetPizza(id));
app.MapPost("/pizzas", (Pizza pizza) => PizzaRepo.CreatePizza(pizza));
app.MapPut("/pizzas", (Pizza pizza) => PizzaRepo.UpdatePizza(pizza));
app.MapDelete("/pizzas/{id}", (int id) => PizzaRepo.RemovePizza(id));

app.Run();
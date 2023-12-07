using Microsoft.EntityFrameworkCore;
using minimum_api_BD.models;

namespace minimum_api_BD.repository;

public class PizzaRepo : DbContext
{
    public PizzaRepo(DbContextOptions<PizzaRepo> options) : base(options)
    {
    }
    
    public DbSet<Pizza> Pizzas { get; set; } = null!;
}
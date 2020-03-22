using System;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Databases
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderPizza> OrderPizza { get; set; }
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345;");
    }
    
    // public PizzaBoxDbContext (DbContextOptions<PizzaBoxDbContext> options) : base(options)
    // {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
      modelBuilder.Entity<Order>().HasMany(o => o.OrderPizzas).WithOne(op => op.Order);
      modelBuilder.Entity<Order>().HasOne(o => o.Store).WithMany(o => o.Orders);
      modelBuilder.Entity<Order>().HasOne(o => o.User).WithMany(o => o.Orders);
      modelBuilder.Entity<Order>().HasData(new Order[] 
      {
        new Order() { OrderId = 1, OrderDateTime = new DateTime(2020, 01, 01, 01, 00, 00), StoreId = 1, UserId = 1},
        new Order() { OrderId = 2, OrderDateTime = new DateTime(2020, 01, 02, 01, 00, 00), StoreId = 2, UserId = 1},
        new Order() { OrderId = 3, OrderDateTime = new DateTime(2020, 01, 03, 01, 00, 00), StoreId = 3, UserId = 2},
        new Order() { OrderId = 4, OrderDateTime = new DateTime(2020, 02, 11, 02, 00, 00), StoreId = 1, UserId = 2},
        new Order() { OrderId = 5, OrderDateTime = new DateTime(2020, 02, 12, 02, 00, 00), StoreId = 2, UserId = 3},
        new Order() { OrderId = 6, OrderDateTime = new DateTime(2020, 02, 13, 03, 00, 00), StoreId = 3, UserId = 3},
        new Order() { OrderId = 7, OrderDateTime = new DateTime(2020, 03, 21, 03, 00, 00), StoreId = 1, UserId = 4},
        new Order() { OrderId = 8, OrderDateTime = new DateTime(2020, 03, 22, 20, 00, 00), StoreId = 2, UserId = 4},
        new Order() { OrderId = 9, OrderDateTime = new DateTime(2020, 03, 23, 21, 00, 00), StoreId = 3, UserId = 5},
      });

      modelBuilder.Entity<OrderPizza>().HasKey(op => op.OrderPizzaId);
      modelBuilder.Entity<OrderPizza>().HasData(new OrderPizza[]
      {
        new OrderPizza() { OrderPizzaId = 1, OrderId = 1, PizzaId = 1},
        new OrderPizza() { OrderPizzaId = 2, OrderId = 2, PizzaId = 2},
        new OrderPizza() { OrderPizzaId = 3, OrderId = 3, PizzaId = 3},
        new OrderPizza() { OrderPizzaId = 4, OrderId = 4, PizzaId = 4},
        new OrderPizza() { OrderPizzaId = 5, OrderId = 5, PizzaId = 5},
        new OrderPizza() { OrderPizzaId = 6, OrderId = 6, PizzaId = 6},
        new OrderPizza() { OrderPizzaId = 7, OrderId = 7, PizzaId = 7},
        new OrderPizza() { OrderPizzaId = 8, OrderId = 8, PizzaId = 8},
        new OrderPizza() { OrderPizzaId = 9, OrderId = 9, PizzaId = 9},
        new OrderPizza() { OrderPizzaId = 10, OrderId = 9, PizzaId = 10},

      });

      modelBuilder.Entity<Pizza>().HasKey(p => p.PizzaId);
      modelBuilder.Entity<Pizza>().HasMany(p => p.OrderPizzas).WithOne(p => p.Pizza);
      modelBuilder.Entity<Pizza>().HasData(new Pizza[] 
      {
        new Pizza() { PizzaId = 1, PizzaName = "The Worst Pizza", PizzaDetails = "Uncooked Pizza Dough", PizzaPrice = 1.00M, },
        new Pizza() { PizzaId = 2, PizzaName = "The Best Pizza", PizzaDetails = "Cooked Pizza Dough", PizzaPrice = 2.00M, },
        new Pizza() { PizzaId = 3, PizzaName = "The Dominic", PizzaDetails = "Thin Crust, Medium Size, ", PizzaPrice = 3.00M, },
        new Pizza() { PizzaId = 4, PizzaName = "The Fred", PizzaDetails = "Thick Crust, Large Size, Tomato Sauce, Tomato Sauce, Tomato Sauce, Tomato Sauce", PizzaPrice = 4.00M, },
        new Pizza() { PizzaId = 5, PizzaName = "The Frank", PizzaDetails = "Traditional Crust, Tomato Sauce, Mozarella Cheese", PizzaPrice = 5.00M, },
        new Pizza() { PizzaId = 6, PizzaName = "The Me Hoy Minoy", PizzaDetails = "Paper, Pencil", PizzaPrice = 6.00M, },
        new Pizza() { PizzaId = 7, PizzaName = "The Sweat", PizzaDetails = "Thin Crust, Small Size, Tomato Sauce, Mozarella Cheese, Ground Beef, Allspice", PizzaPrice = 7.00M, },
        new Pizza() { PizzaId = 8, PizzaName = "The Hallowus", PizzaDetails = "Traditional Crust, Large Size, Mozarella Cheese, Pesto Dollops, White Sauce, Chicken, Green Bell Peppers, Red Onions", PizzaPrice = 8.00M, },
        new Pizza() { PizzaId = 9, PizzaName = "The Pupit", PizzaDetails = "Thick Crust, Tomato Sauce, Bacon, Eggs, Cheese, Corn", PizzaPrice = 9.00M, },
        new Pizza() { PizzaId = 10, PizzaName = "The Puffer", PizzaDetails = "Eugh", PizzaPrice = 9.00M, },
      });

      modelBuilder.Entity<Store>().HasKey(s => s.StoreId);
      modelBuilder.Entity<Store>().HasMany(s => s.Orders).WithOne(s => s.Store);
      modelBuilder.Entity<Store>().HasData(new Store[] 
      {
        new Store() { StoreId = 1, StoreName = "Fred's Pizzeria", StoreAddress = "16573 Wallaby Ln" },
        new Store() { StoreId = 2, StoreName = "Not Your Mom's Pizza", StoreAddress = "6678 This Street St" },
        new Store() { StoreId = 3, StoreName = "My Mom's Pizza", StoreAddress = "29394 Calhoun Dr" },
      });

      modelBuilder.Entity<User>().HasKey(u => u.UserId);
      modelBuilder.Entity<User>().HasMany(u => u.Orders).WithOne(u => u.User);
      modelBuilder.Entity<User>().HasData(new User[] 
      {
        new User() { UserId = 1, FirstName = "Ted1", LastName = "Willis1", UserAddress = "Place1"},
        new User() { UserId = 2, FirstName = "Ted2", LastName = "Willis2", UserAddress = "Place2"},
        new User() { UserId = 3, FirstName = "Ted3", LastName = "Willis3", UserAddress = "Place3"},
        new User() { UserId = 4, FirstName = "Ted4", LastName = "Willis4", UserAddress = "Place4"},
        new User() { UserId = 5, FirstName = "Ted5", LastName = "Willis5", UserAddress = "Place5"},
      });

    }
  }
}
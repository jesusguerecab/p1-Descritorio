using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaBoxRepository
  {
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();
    
    // public PizzaBoxRepository(PizzaBoxDbContext dbContext)
    // {
    //   _db = dbContext;
    // }
    public IEnumerable<T> Read<T>() where T : class
    {
      return _db.Set<T>();
    }

    public bool Post(Order order)
    {
      _db.Add(order);
      return _db.SaveChanges() == 1;
    }

    public bool Post(OrderPizza orderPizza)
    {
      _db.Add(orderPizza);
      return _db.SaveChanges() == 1;
    }
  }
}
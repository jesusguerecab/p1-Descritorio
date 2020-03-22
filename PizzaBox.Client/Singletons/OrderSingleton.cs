using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  public class OrderSingleton 
  {
    private static readonly PizzaBoxRepository _pr = new PizzaBoxRepository();
    public void SaveOrderToDb(Order order)
    {
      _pr.Post(order);
    }
  }
}
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  public class OrderPizzaSingleton 
  {
    private static readonly PizzaBoxRepository _pr = new PizzaBoxRepository();
    public void SaveOrderPizzaToDb(OrderPizza orderPizza)
    {
      _pr.Post(orderPizza);
    }
  }
}
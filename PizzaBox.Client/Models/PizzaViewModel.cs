using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class PizzaViewModel
  {
    private static readonly PizzaBoxRepository _pr = new PizzaBoxRepository();
    public List<Order> OrderList { get; set; }
    public List<Pizza> PizzaList { get; set; }
    public List<Store> StoreList { get; set; }
    public List<User> UserList { get; set; }

    public Order Order { get; set; }
    public Pizza Pizza { get; set; }
    public Store Store { get; set; }
    public User User { get; set; }

    public PizzaViewModel()
    {
      OrderList = _pr.Read<Order>().ToList();
      PizzaList = _pr.Read<Pizza>().ToList();
      StoreList = _pr.Read<Store>().ToList();
      UserList = _pr.Read<User>().ToList();
    }
  }
}
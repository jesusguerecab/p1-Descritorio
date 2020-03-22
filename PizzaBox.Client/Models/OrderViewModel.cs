using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
    private static readonly PizzaBoxRepository _pr = new PizzaBoxRepository();
    public List<Pizza> PizzaList { get; set; }

    public long PizzaId { get; set; }
    public DateTime OrderDateTime { get; set; }
    public long StoreId { get; set; }
    public long UserId { get; set; }
    public long OrderPizzaId { get; set; }

    //Get PizzaId
    
    //Get OrderDateTime
    //Get StoreId
    //Get UserId
    //Get OrderPizzaId

    public OrderViewModel()
    {
      PizzaList = _pr.Read<Pizza>().ToList();
    }
  }
}
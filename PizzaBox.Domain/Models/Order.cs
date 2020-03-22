using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    [Required]
    [Key]
    public long OrderId { get; set; }
    public DateTime OrderDateTime { get; set; }
    public decimal OrderTotal { get; set; } //will need to create method to add all pizza prices

    #region NAVIGATION
    public List<OrderPizza> OrderPizzas { get; set; }
    public Store Store { get; set; }
    public long StoreId { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }
    #endregion

    public Order() {}
    public Order(long storeId, long userId)
    {
      OrderDateTime = DateTime.Now;
      StoreId = storeId;
      UserId = userId;
    }
  }
}
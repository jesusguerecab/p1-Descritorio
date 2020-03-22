using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Models
{
  public class OrderPizza
  {
    [Required]
    [Key]
    public long OrderPizzaId { get; set; }

    #region NAVIGATIONAL PROPERTIES
    public Order Order { get; set; }
    public long OrderId { get; set; }
    public Pizza Pizza { get; set; }
    public long PizzaId { get; set; }
    #endregion

    public OrderPizza() {}
    public OrderPizza(long orderId, long pizzaId) 
    {
      OrderId = orderId;
      PizzaId = pizzaId;
    }
  }
}
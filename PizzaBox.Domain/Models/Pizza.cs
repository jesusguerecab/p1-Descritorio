using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Models
{
  public class Pizza
  {
    [Required]
    [Key]
    public long PizzaId { get; set; }
    public string PizzaName { get; set; }
    public string PizzaDetails { get; set; }
    public decimal PizzaPrice { get; set; }

    #region NAVIGATION
    public List<OrderPizza> OrderPizzas { get; set; }
    #endregion
  }
}
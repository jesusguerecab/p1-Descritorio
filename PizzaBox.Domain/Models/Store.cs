using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Models
{
  public class Store
  {
    [Required]
    [Key]
    public long StoreId { get; set; }
    public string StoreName { get; set; }
    public string StoreAddress { get; set; }

    #region NAVIGATION
    public List<Order> Orders { get; set; }
    #endregion
  }
}
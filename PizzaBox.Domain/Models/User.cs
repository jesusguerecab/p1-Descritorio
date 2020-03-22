using System.ComponentModel.DataAnnotations;  
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class User
  {
    [Required]
    [Key]
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserAddress { get; set; }

    #region NAVIGATION
    public List<Order> Orders { get; set; }
    #endregion
  }
}
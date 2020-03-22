using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class OrderUserController : Controller
  {
    private readonly PizzaViewModel _pvm = new PizzaViewModel();
    public IActionResult Index(long? id)
    {
      if (id == null)
      {
          return NotFound();
      }

      var user = _pvm.UserList.FirstOrDefault(u => u.UserId == id);
      if (user == null)
      {
          return NotFound();
      }

      return View(user);
    }
  }
}    
    

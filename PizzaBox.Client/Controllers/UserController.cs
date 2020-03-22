using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class UserController : Controller
  {
    private readonly PizzaViewModel _pvm = new PizzaViewModel();
    [HttpGet]
    public IActionResult Index()
    {
      return View(new PizzaViewModel());
    }

    [HttpGet]
    public IActionResult Index2()
    {
      var user = _pvm.UserList.FirstOrDefault(u => u.UserId == 1);
      if (user == null)
      {
          return NotFound();
      }
      return View(user);
    }
    
  }
}
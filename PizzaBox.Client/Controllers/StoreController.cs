using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class StoreController : Controller
  {
    public IActionResult Index(long? id)
    {
      return View(new PizzaViewModel());
    }
    public IActionResult History()
    {
      return View();
    }
  }
}
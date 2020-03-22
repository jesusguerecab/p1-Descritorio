using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class AccountController : Controller
  {
    public IActionResult Login()
    {
      return View();
    }

    public IActionResult Login(AccountViewModel account)
    {
      if (!ModelState.IsValid)
      {
        return View(account);
      }

      if (account.User)
      {
        return View("User");
      }
      return View("Store");
    }
  }
}
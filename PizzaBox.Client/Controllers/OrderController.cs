using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
    [HttpGet]
    public IActionResult Index()
    {
      return View(new PizzaViewModel());
    }

    [HttpGet]
    public IActionResult Create(long? id)
    {
      if (id == null)
      {
          return NotFound();
      }
      return View(new OrderViewModel());
    }

    [HttpPost]
    public IActionResult Create(long pizzaId) //dont need OrderViewModel, can just bind individual components 
    { //[Bind("PizzaId,OrderDateTime,StoreId,UserId,OrderPizzaId")] OrderViewModel orderViewModel
    //should get storeId from IActionResult parameters
        //should get userId from IActionResult parameters
        if (ModelState.IsValid)
        {
            // _context.Add(movie); 
            // await _context.SaveChangesAsync();
            
            // Create new instance of Order
            // OrderDateTime : need to create new order instance, will generate new OrderDateTime
            // StoreId : need to create new order instance, initialize this.StoreId = StoreId
            // UserId : need to create new order instance, initialize this.UserId = UserId
            Order order = new Order(1, 1); //HARD CODED, needs to be dynamic

            // OrderPizzaId : need to create new OrderPizza instance, initialize this.OrderId = OrderId && this.PizzaId = PizzaId

            // after creating instances, save them to database using singletons
            OrderSingleton os = new OrderSingleton();
            os.SaveOrderToDb(order);
            
            OrderPizza orderPizza = new OrderPizza(order.OrderId, pizzaId);
            OrderPizzaSingleton ops = new OrderPizzaSingleton();
            ops.SaveOrderPizzaToDb(orderPizza);
            // order of saves matters, else you will get INSERT statement conflicted with the FOREIGN KEY constraint error

            return RedirectToAction(nameof(Index));
        }
        return View();
    }
  }
}
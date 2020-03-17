using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db; // db comes from our dependencies - under the hood!
    // db is an instance of our DbContext class

    public ItemsController(ToDoListContext db) // new constuctor for our new field: _db
    {
      _db = db; 
    }

    public ActionResult Index()
    {
      List<Item> model = _db.Items.ToList(); // ToList from Linq - replaces GetAll() method
      return View(model);
    }
  } 
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoItems.Models;

namespace ToDoItems.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
            "Data Source=.\\sqlexpress;Initial Catalog=ToDoItems;Integrated Security=True";

        public IActionResult Index()
        {
            ToDoItemsManager mgr = new ToDoItemsManager(_connectionString);

            List<ToDoItem> items = mgr.GetIncompletedItems();
            return View(items);
        }

        public IActionResult Completed()
        {
            ToDoItemsManager mgr = new ToDoItemsManager(_connectionString);

            List<ToDoItem> items = mgr.GetCompleted();
            return View(items);
        }

        public IActionResult Categories()
        {
            ToDoItemsManager mgr = new ToDoItemsManager(_connectionString);
            return View(mgr.GetCategories());
        }

        public IActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveNewCategory(string name)
        {
            ToDoItemsManager mgr = new ToDoItemsManager(_connectionString);
            mgr.AddCategory(name);
            return Redirect("/home/categories");
        }

        public IActionResult EditCategory(int id)
        {
            ToDoItemsManager mgr = new ToDoItemsManager(_connectionString);
            Category category = mgr.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            ToDoItemsManager mgr = new ToDoItemsManager(_connectionString);
            mgr.UpdateCategory(category);
            return Redirect("/home/categories");
        }

        public IActionResult NewItem()
        {
            ToDoItemsManager mgr = new ToDoItemsManager(_connectionString);
            return View(mgr.GetCategories());
        }

        [HttpPost]
        public IActionResult NewItem(ToDoItem item)
        {
            ToDoItemsManager mgr = new ToDoItemsManager(_connectionString);
            mgr.AddToDoItem(item);
            return Redirect("/home/index");
        }

        [HttpPost]
        public IActionResult MarkAsCompleted(int id)
        {
            ToDoItemsManager mgr = new ToDoItemsManager(_connectionString);
            mgr.MarkAsCompleted(id);
            return Redirect("/home/index");
        }

        public IActionResult ByCategory(int id)
        {
            ToDoItemsManager mgr = new ToDoItemsManager(_connectionString);

            List<ToDoItem> items = mgr.GetByCategory(id);
            return View(items);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context){
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index(){
            List<Dish> AllDishes = dbContext.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
            ViewBag.Dishes = AllDishes;
            return View();
        }

        [HttpGet("{dishID}")]
        public IActionResult DishInfo(int dishID){
            Dish oneDish = dbContext.Dishes.SingleOrDefault(d => d.iddishes == dishID);
            // ViewBag.thisDish = oneDish;
            return View(oneDish);
        }

        [HttpGet("new")]
        public IActionResult New(){
            return View();
        }

        [HttpPost("createDish")]
        public IActionResult createDish(Dish newDish){
            if (ModelState.IsValid){
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            } else {
                return View("New");
            }
        }

        [HttpPost("remove/{dishID}")]
        public IActionResult Remove(int dishID){
            Dish oneDish = dbContext.Dishes.SingleOrDefault(d => d.iddishes == dishID);
            dbContext.Dishes.Remove(oneDish);
            dbContext.SaveChanges();
            // ViewBag.thisDish = oneDish;
            return RedirectToAction("Index");
        }


        [HttpGet("edit/{dishID}")]
        public IActionResult EditDish(int dishID){
            Dish oneDish = dbContext.Dishes.SingleOrDefault(d => d.iddishes == dishID);
            // ViewBag.thisDish = oneDish;
            return View(oneDish);
        }

        [HttpPost("update")]
        public IActionResult updateDish(Dish editedDish){
            Dish gotDish = dbContext.Dishes.SingleOrDefault(d => d.iddishes == editedDish.iddishes);
            System.Console.WriteLine("************************");
            System.Console.WriteLine("HELP");
            gotDish.Name = editedDish.Name;
            gotDish.Chef = editedDish.Chef;
            gotDish.Tastiness = editedDish.Tastiness;
            gotDish.Calories = editedDish.Calories;
            gotDish.Description = editedDish.Description;
            gotDish.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

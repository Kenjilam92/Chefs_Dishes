using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chefs_Dishes.Models;
using Microsoft.EntityFrameworkCore;

namespace Chefs_Dishes.Controllers
{
    public class HomeController : Controller
    {   
        private Context database {get;set;} 
        public HomeController(Context context)
        {
            database = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            ViewBag.Chefs=database.Chefs.Include(c=>c.Dishes).ToList();
            return View();
        }
        [Route("new")]
        public IActionResult New()
        {
            return View();
        }
        [Route("dishes")]
        public IActionResult Dishes()
        {
            ViewBag.Dishes=database.Dishes.Include(d => d.Chef).ToList();
            return View();
        }
        [Route("dishes/new")]
        public IActionResult NewDish()
        {
            ViewBag.Chefs=database.Chefs.ToList();
            return View();
        }
        ///////////////////////////
        [HttpPost]
        [Route("add")]
        public IActionResult AddChef(Chef newChef)
        {   
            if (ModelState.IsValid)
            {   
                database.Chefs.Add(newChef);
                database.SaveChanges();
                return Redirect("/");            
            }
            return View("New");
        }
        [Route("dishes/add")]
        public IActionResult AddDish(Dish newDish)
        {   
            if (ModelState.IsValid)
            {   
                database.Dishes.Add(newDish);
                database.SaveChanges();
                return Redirect("/dishes");            
            }
            ViewBag.Chefs=database.Chefs.ToList();
            return View("NewDish");
        }


        ////////////////////////////
        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}

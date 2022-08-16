using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;
namespace ChefsNDishes.Controllers;

public class DishController : Controller
{
    private ChefsNDishesContext _context;
    public DishController(ChefsNDishesContext context)
    {
        _context = context;
    }


    [HttpGet("/")]
    [HttpGet("/dishes/all")]
    public IActionResult All()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();
        ViewBag.AllChefs = _context.chefs.ToList();
        return View("AllDishes", AllDishes);
    }


    [HttpGet("/dishes/new")]
    public IActionResult New()
    {
        ViewBag.AllChefs = _context.chefs.ToList();
        return View("NewDish");
    }


    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if(ModelState.IsValid == false)
        {
            return New();
        }
        _context.Dishes.Add(newDish);
        _context.SaveChanges();

        return RedirectToAction("All");
    }
}
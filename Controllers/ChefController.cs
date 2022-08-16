using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;
namespace ChefsNDishes.Controllers;

public class ChefController : Controller
{
    private ChefsNDishesContext _context;
    public ChefController(ChefsNDishesContext context)
    {
        _context = context;
    }

    [HttpGet("/chefs/all")]
    public IActionResult All()
    {
        List<Chef> AllChefs = _context.chefs.ToList();
        List<Chef> CreatedDishes = _context.chefs
        .Include(c => c.CreatedDishes)
        .ToList();
        return View("AllChefs", AllChefs);
    }


    [HttpGet("/chefs/new")]
    public IActionResult New()
    {
        return View("NewChef");
    }


    [HttpPost("/chefs/create")]
    public IActionResult Create(Chef newChef)
    {
        if(ModelState.IsValid==false)
        {
            return New();
        }
        _context.chefs.Add(newChef);
        _context.SaveChanges();
        return RedirectToAction("All");
    }
}
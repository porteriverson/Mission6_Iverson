using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;

namespace Mission6.Controllers;

public class HomeController : Controller
{
    private NewMovieContext _context;
    public HomeController(NewMovieContext temp)
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AboutMe()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddMovie()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddMovie(Movie newMovie)
    {
        _context.Movies.Add(newMovie);
        _context.SaveChanges();
        return View("Confirmation");
    }
    
}
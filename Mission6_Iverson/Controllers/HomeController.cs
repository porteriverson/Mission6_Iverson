using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
        return View("AddMovie", new Movie());
    }

    [HttpPost]
    public IActionResult AddMovie(Movie newMovie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            return View("Confirmation", newMovie);
        }
        else
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(newMovie);
        }
    }
    
    public IActionResult ViewMovies()
    {
        var movies = _context.Movies
            .Include(x=>x.Category)
            .OrderBy(x => x.Title).ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int MovieId)
    {
        Movie recordToEdit = _context.Movies
            .Single(x => x.MovieId == MovieId);
        ViewBag.Categories = _context.Categories.ToList();
        return View("AddMovie", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie updated)
    {
        _context.Update(updated);
        _context.SaveChanges();
        return RedirectToAction("ViewMovies");
    }

    [HttpGet]
    public IActionResult Delete(int MovieId)
    {
        var recordToDelete = _context.Movies
            .Single(x=>x.MovieId == MovieId);
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie deletedMovie)
    {
        var deletedRecord = _context.Movies
            .Single(x => x.MovieId == deletedMovie.MovieId);
        _context.Movies.Remove(deletedRecord);
        _context.SaveChanges();
        return RedirectToAction("ViewMovies");
    }
}
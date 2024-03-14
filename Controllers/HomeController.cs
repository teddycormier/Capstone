using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult FitnessPlan()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View("~/Views/GymPopulation/Index.cshtml");
    }

    public IActionResult UserProfile()
    {
        return View();
    }

    public IActionResult Calendar()
    {
        return View();
    }

    public IActionResult DB()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

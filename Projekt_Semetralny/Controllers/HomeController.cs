using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projekt_Semetralny.Models;

namespace Projekt_Semetralny.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        Console.WriteLine("HomeController.Index wywołany");
        return View();
    }


    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
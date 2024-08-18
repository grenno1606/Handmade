using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Handmade_Dotnet.Models;

namespace Handmade_Dotnet.Controllers;

public class TutorialController : Controller
{
    public TutorialService tutorialService=new TutorialService();
    public IActionResult Index()
    {
        List<TutorialModel> tutorials = tutorialService.GetAll();
        tutorials.Reverse();
        ViewBag.Tutorials=tutorials;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

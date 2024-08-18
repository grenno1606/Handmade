using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Handmade_Dotnet.Models;

namespace Handmade_Dotnet.Controllers;

public class HomeController : Controller
{
    public ProductService productService=new ProductService();
    public TutorialService tutorialService=new TutorialService();

    public IActionResult Index()
    {
        List<ProductModel> products = productService.GetAll();
        products.Reverse();
        List<TutorialModel> tutorials = tutorialService.GetAll();
        tutorials.Reverse();
        ViewBag.Products=products;
        ViewBag.Tutorials=tutorials;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

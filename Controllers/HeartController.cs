using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Handmade_Dotnet.Models;

namespace Handmade_Dotnet.Controllers;

public class HeartController : Controller
{
    public ProductService productService = new ProductService();
    public TutorialService tutorialService= new TutorialService();
    public FavoriteProductsService favoriteProductsService= new FavoriteProductsService();
    public FavoriteTutorialsService favoriteTutorialsService= new FavoriteTutorialsService();
    public IActionResult Index()
    {
        
        // List<ProductModel> products = productService.GetAll();


        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

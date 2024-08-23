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
        var username = HttpContext.Session.GetString("ten_user");
         if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index", "Login");
            }
        List<ProductModel> favoriteProducts=favoriteProductsService.GetByUsername(username);//-----------------
        ViewBag.favoriteProducts = favoriteProducts;
        List<ProductModel> products = productService.GetAll();
        ViewBag.products = products;
        List<TutorialModel> favoriteTutorials=favoriteTutorialsService.GetByUsername(username);
        ViewBag.favoriteTutorials = favoriteTutorials;
        List<TutorialModel> tutorials = tutorialService.GetAll();
        ViewBag.tutorials = tutorials;
        return View();
    }

    public IActionResult AddProduct(String id)
    {
        var username = HttpContext.Session.GetString("ten_user");
        if (string.IsNullOrEmpty(username))
        {
            return RedirectToAction("Index", "Login");
        }
        FavoriteProductModel favoriteProductModel= new FavoriteProductModel(username,id);
        favoriteProductsService.Add(favoriteProductModel);
        return Redirect(Request.Headers.Referer.ToString());
    }

     public IActionResult AddTutorial(String id)
    {
        var username = HttpContext.Session.GetString("ten_user");
         if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index", "Login");
            }
        FavoriteTutorialModel favoriteTutorial=new FavoriteTutorialModel(username,id);
        favoriteTutorialsService.Add(favoriteTutorial);
        return Redirect(Request.Headers.Referer.ToString());
    }

    public IActionResult DeleteProduct(String id)
    {
        var username = HttpContext.Session.GetString("ten_user");
        if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index", "Login");
            }
        favoriteProductsService.Delete(id,username);
        return Redirect(Request.Headers.Referer.ToString());
    }

    public ActionResult DeleteTutorial(String id)
    {
        favoriteTutorialsService.Delete(id);
        return Redirect(Request.Headers.Referer.ToString());
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

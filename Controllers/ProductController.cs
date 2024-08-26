using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Handmade_Dotnet.Models;

namespace Handmade_Dotnet.Controllers;

public class ProductController : Controller
{
    public ProductService productService= new ProductService();
    public IActionResult Index()
    {
        List<ProductModel> products = productService.GetAll();
        products.Reverse();
        ViewBag.Products=products;
        var username = HttpContext.Session.GetString("ten_user");
        ViewBag.username=username;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

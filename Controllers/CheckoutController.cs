using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Handmade_Dotnet.Models;

namespace Handmade_Dotnet.Controllers;

public class CheckoutController : Controller
{
     public ProductService productService=new ProductService();
    public UserCartService userCartService=new UserCartService();

    public IActionResult Index()
    {
        List<ProductModel> cartProducts = userCartService.GetByUsername("Dunn"); //---------------------------
        ViewBag.cartProducts = cartProducts;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

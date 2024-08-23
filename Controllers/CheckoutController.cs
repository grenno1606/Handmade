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
        var username = HttpContext.Session.GetString("ten_user");
        if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index", "Login");
            }
        List<ProductModel> cartProducts = userCartService.GetByUsername(username); //---------------------------
        ViewBag.cartProducts = cartProducts;
        List<UserCartModel> userCartModels = userCartService.GetAll();
        ViewBag.userCartModels = userCartModels;
         foreach (var item in userCartModels)
        {
            Console.WriteLine($"UserId: {item.Username}, ProductId: {item.ProductId}, Quantity: {item.Quantity}");
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

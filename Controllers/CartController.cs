using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Handmade_Dotnet.Models;

namespace Handmade_Dotnet.Controllers;

public class CartController : Controller
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
        List<ProductModel> products = productService.GetAll();
        ViewBag.products = products;
        return View();
    }

    public IActionResult AddProduct(String id)
    {
        var username = HttpContext.Session.GetString("ten_user");
        if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index", "Login");
            }
        UserCartModel userCartModel= new UserCartModel(username,id);
        userCartService.Add(userCartModel);
        return Redirect(Request.Headers.Referer.ToString());
    }

    public IActionResult DeleteProduct(String id)
    {
        var username = HttpContext.Session.GetString("ten_user");
        if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index", "Login");
            }
        userCartService.Delete(id,username);
        return Redirect(Request.Headers.Referer.ToString());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

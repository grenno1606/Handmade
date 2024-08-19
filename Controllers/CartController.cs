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
        List<ProductModel> cartProducts = userCartService.GetByUsername("Dunn"); //---------------------------
        ViewBag.cartProducts = cartProducts;
        List<ProductModel> products = productService.GetAll();
        ViewBag.products = products;
        // userCartService.SetAmount();-------------------------------------------------
        return View();
    }

    public IActionResult AddProduct(String id)
    {
        UserCartModel userCartModel= new UserCartModel("Dunn",id);
        userCartService.Add(userCartModel);
        return Redirect(Request.Headers.Referer.ToString());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

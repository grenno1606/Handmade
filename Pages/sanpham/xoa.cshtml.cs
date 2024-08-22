using handmade.data;
using handmade.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace handmade.Pages.sanpham
{
    [BindProperties]
    public class xoaModel : PageModel
    {

        private readonly Connet _db;

        public sanpham_model sanphams { get; set; }

        public xoaModel(Connet db)
        {
            _db = db;
        }
        public IActionResult OnGet(string? productid)
        {
            if (productid != null)
            {
                sanphams = _db.products.Find(productid);


                _db.products.Remove(sanphams);
                _db.SaveChanges();
                return RedirectToPage("Index");

            }
            return RedirectToPage("Index");
        }

    }
}


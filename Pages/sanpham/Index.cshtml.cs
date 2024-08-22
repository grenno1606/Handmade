using handmade.data;
using handmade.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace handmade.Pages.sanpham
{

   
    public class IndexModel : PageModel
    {
        private readonly Connet _db;
        public List<sanpham_model> sanphams { get; set; }
        public IndexModel(Connet db)
        {
            _db = db;   
        }   
        public void OnGet()
        {
                sanphams= _db.products.ToList();
        }
        public IActionResult OnPost(sanpham_model obj) { 
            _db.products.Add(obj);
                _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

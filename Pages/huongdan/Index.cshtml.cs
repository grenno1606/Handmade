using handmade.data;
using handmade.models;
using Handmade_Dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Handmade_Dotnet.Pages.huongdan
{
    public class IndexModel : PageModel
    {
        private readonly Connet _db;
        public List<huongdan_model> huongdan { get; set; }
        public IndexModel(Connet db)
        {
            _db = db;
        }
        public void OnGet()
        {
            huongdan = _db.tutorials.ToList();
        }
      
    }
}

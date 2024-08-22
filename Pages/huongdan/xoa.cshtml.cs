using handmade.data;
using handmade.models;
using Handmade_Dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Handmade_Dotnet.Pages.huongdan
{
    [BindProperties]
    public class xoaModel : PageModel
    {

        private readonly Connet _db;

        public huongdan_model huongdan { get; set; }

        public xoaModel(Connet db)
        {
            _db = db;
        }
        public IActionResult OnGet(string? tutorialid)
        {
            if (tutorialid != null)
            {
                huongdan = _db.tutorials.Find(tutorialid);


                _db.tutorials.Remove(huongdan);
                _db.SaveChanges();
                return RedirectToPage("Index");

            }
            return RedirectToPage("Index");
        }

    }
}

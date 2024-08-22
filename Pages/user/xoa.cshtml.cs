using handmade.data;
using handmade.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace handmade.Pages.user
{
    [BindProperties]
    public class xoaModel : PageModel
    {

        private readonly Connet _db;

        public user_models user { get; set; }

        public xoaModel(Connet db)
        {
            _db = db;
        }
        public IActionResult OnGet(string? userid)
        {
            if (userid != null)
            {
                user = _db.users.Find(userid);


                _db.users.Remove(user);
                _db.SaveChanges();
                return RedirectToPage("Index");

            }
            return RedirectToPage("Index");
        }

    }
}

using handmade.data;
using handmade.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace handmade.Pages.user
{ [BindProperties]
    public class suaModel : PageModel
    {
        private readonly Connet _db;
        public user_models user { get; set; }
        public suaModel(Connet db)
        {
            _db = db;
        }

        public IActionResult OnGet(string? userid)
        {
            if (userid != null)
            {
                user = _db.users.Find(userid);
                if (user == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {

           
            user.updated_at = DateTime.Now;

            _db.users.Update(user);
            _db.SaveChanges();
            return RedirectToPage("Index");


        }
    }
}


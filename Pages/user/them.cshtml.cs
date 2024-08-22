using handmade.data;
using handmade.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace handmade.Pages.user
{
    [BindProperties]
    public class themModel : PageModel
    {

        private readonly Connet _db;

        public user_models user { get; set; }

        public themModel(Connet db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            Random random = new Random();
            string id = random.Next(1000).ToString();
            user.userid = id;
            user.created_at = DateTime.Now;
            user.updated_at = DateTime.Now;
            _db.users.Add(user);
            _db.SaveChanges();
            return RedirectToPage("Index");

        }
    }
}

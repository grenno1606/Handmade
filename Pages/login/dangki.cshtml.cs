using handmade.data;
using handmade.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace handmade.Pages.login
{
    [BindProperties]
    public class dangkiModel : PageModel
    {
        private readonly Connet _db;

        public user_models user1 { get; set; }

        public dangkiModel(Connet db)
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
            user1.userid = id;
            user1.created_at = DateTime.Now;
            user1.updated_at = DateTime.Now;
            user1.role = "user";
            _db.users.Add(user1);
            _db.SaveChanges();
            return LocalRedirect("~/login");
        }
    }
}

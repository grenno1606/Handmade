using handmade.data;
using handmade.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace handmade.Pages.user
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly Connet _db;
        public List<user_models> users { get; set; }
        public IndexModel(Connet db)
        {
            _db = db;
        }
        public void OnGet()
        {
            users = _db.users.ToList();
        }
     
    }
}

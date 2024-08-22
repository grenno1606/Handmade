using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace handmade.Pages.login
{
    public class dangxuatModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            return LocalRedirect("~/Index");
        }
    }
}

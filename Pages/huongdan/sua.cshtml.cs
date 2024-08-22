using handmade.data;
using handmade.models;
using Handmade_Dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Handmade_Dotnet.Pages.huongdan
{
    [BindProperties]
    public class suaModel : PageModel
    {
        private readonly Connet _db;

        private readonly string _imagePath = "wwwroot/uploads_video/";
        public huongdan_model huongdan { get; set; }
        public suaModel(Connet db)
        {
            _db = db;
        }

        public IActionResult OnGet(string? tutorialid)
        {
            if (tutorialid != null)
            {
               huongdan = _db.tutorials.Find(tutorialid);
                if (huongdan == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        /* public IActionResult OnPost()
         {

             int phamtram = (int)(((float)(decimal)sanphams.discounted_price / (float)sanphams.original_price) * 100);
             sanphams.discount_percentage = 100-phamtram;
                 sanphams.updated_at = DateTime.Now;

                 _db.products.Update(sanphams);
                 _db.SaveChanges();
                 return RedirectToPage("Index");


         }*/
        public async Task<IActionResult> OnPostAsync(IFormFile videoFile)
        {
            if (videoFile != null && videoFile.Length > 0)
            {
                // Tạo tên file duy nhất để tránh trùng lặp
                var fileName = Path.GetFileName(videoFile.FileName);
                var filePath = Path.Combine(_imagePath, fileName);

                // Lưu file vào hệ thống
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await videoFile.CopyToAsync(fileStream);
                }
                huongdan.video = videoFile.FileName;
            }

           
            huongdan.updated_at = DateTime.Now;




            _db.tutorials.Update(huongdan);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");


            return Page();
        }
    }
}

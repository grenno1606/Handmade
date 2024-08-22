using handmade.data;
using handmade.models;
using Handmade_Dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Handmade_Dotnet.Pages.huongdan
{
    [BindProperties]
    public class themModel : PageModel
    {

        private readonly Connet _db;
        private readonly string _videoPath = "wwwroot/uploads_video/";
        public huongdan_model huongdan { get; set; }

        public themModel(Connet db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        /*  public IActionResult OnPost()
          {
              Random random = new Random();
              string id = random.Next(1000).ToString();
              int phamtram = (int)((sanphams.discounted_price / sanphams.original_price) * 100);
              sanphams.productid = id;
              sanphams.discount_percentage = 100- phamtram;
              sanphams.created_at = DateTime.Now;
              sanphams.updated_at = DateTime.Now;
              _db.products.Add(sanphams);
              _db.SaveChanges();
              return RedirectToPage("Index");

          }*/
        public async Task<IActionResult> OnPostAsync(IFormFile videoFile)
        {
            if (videoFile != null && videoFile.Length > 0)
            {
                // Tạo tên file duy nhất để tránh trùng lặp
                var fileName = Path.GetFileName(videoFile.FileName);
                var filePath = Path.Combine(_videoPath, fileName);

                // Lưu file vào hệ thống
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await videoFile.CopyToAsync(fileStream);
                }



            }



            Random random = new Random();
            string id = random.Next(1000).ToString();
           
            huongdan.video = videoFile.FileName;
            huongdan.tutorialid = id;
           
            huongdan.created_at = DateTime.Now;
            huongdan.updated_at = DateTime.Now;
            _db.tutorials.Add(huongdan);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");


            return Page();
        }
    }
}

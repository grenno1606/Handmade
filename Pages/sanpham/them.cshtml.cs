using handmade.data;
using handmade.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace handmade.Pages.sanpham
{
    [BindProperties]
    public class themModel : PageModel
    {

        private readonly Connet _db;
        private readonly string _imagePath = "wwwroot/uploads/";
        public sanpham_model sanphams { get; set; }

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
        public async Task<IActionResult> OnPostAsync(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Tạo tên file duy nhất để tránh trùng lặp
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(_imagePath, fileName);

                // Lưu file vào hệ thống
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

             
             
            }

               
               
                Random random = new Random();
                string id = random.Next(1000).ToString();
                int phamtram = (int)((sanphams.discounted_price / sanphams.original_price) * 100);
                sanphams.image = imageFile.FileName;
                sanphams.productid = id;
                sanphams.discount_percentage = 100 - phamtram;
                sanphams.created_at = DateTime.Now;
                sanphams.updated_at = DateTime.Now;
                _db.products.Add(sanphams);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            

            return Page();
        }
    }
}




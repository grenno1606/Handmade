using handmade.data;
using handmade.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace handmade.Pages.sanpham
{
    [BindProperties]
    public class suaModel : PageModel
    {
        private readonly Connet _db;

        private readonly string _imagePath = "wwwroot/uploads/";
        public sanpham_model sanphams { get; set; }
        public suaModel(Connet db)
        {
            _db = db;
        }

        public IActionResult OnGet(string? productid)
        {
            if (productid != null)
            {
                sanphams = _db.products.Find(productid);
                if (sanphams == null)
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
                sanphams.image = imageFile.FileName;
            }

            int phamtram = (int)(((float)(decimal)sanphams.discounted_price / (float)sanphams.original_price) * 100);
            sanphams.discount_percentage = 100 - phamtram;
            sanphams.updated_at = DateTime.Now;
            
           


            _db.products.Update(sanphams);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");


            return Page();
        }
    }
}
using handmade.data;
using handmade.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace handmade.Pages.login
{
    [BindProperties]
    public class dangnhapModel : PageModel
    {
        private readonly Connet _db;

        public user_models user { get; set; }
        public user_models user1 { get; set; }
        public dangnhapModel(Connet db)
        {
            _db = db;
        }

        public void OnGet()
        {
          
        }

        public IActionResult OnPost()
        {
            if (user != null && !string.IsNullOrEmpty(user.email))
            {
                string email = user.email;
                string pass = user.password;

                // Tìm người dùng trong cơ sở dữ liệu
                user1 = _db.users.FirstOrDefault(u => u.email == email);

                if (user1 != null && user1.password == pass)
                {
                    HttpContext.Session.SetString("ten_user", user1.username);

                    if (user1.role == "admin")
                    {
                      //  HttpContext.Session.SetString("admin", "true");
                        return LocalRedirect("/sanpham");
                    }
                    else if (user1.role == "user")
                    {
                        HttpContext.Session.SetString("user", "true");
                        return LocalRedirect("/home");
                    }
                    else
                    {
                        HttpContext.Session.Clear();    
                        
                    }
                }
                else
                {
                    // Thông báo lỗi hoặc xử lý khi không có người dùng hợp lệ hoặc mật khẩu không đúng
                    ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
                    return Page();
                }
            }

            // Xử lý khi đối tượng user là null hoặc email không hợp lệ
            ModelState.AddModelError(string.Empty, "Vui lòng nhập email và mật khẩu.");
            return Page();
        }

    }
}

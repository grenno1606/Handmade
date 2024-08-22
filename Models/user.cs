using System.ComponentModel.DataAnnotations;
using System.Data;

namespace handmade.models
{
    public class user_models
    {
        [Key]
        public string userid { get; set; }  
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public DateTime created_at { get; set; } 
        public DateTime updated_at { get; set; }  
    }
}

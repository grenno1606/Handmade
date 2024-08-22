using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace handmade.models
{
    public class sanpham_model
    {

        [Key]
        public string productid { get; set; }  
        public string image { get; set; }
        public string productname { get; set; }
        public decimal original_price { get; set; } 
        public decimal discounted_price { get; set; }
        public int discount_percentage { get; set; }
        public int amount { get; set; }

        public DateTime created_at { get; set; }  
        public DateTime updated_at { get; set; }  


    }
}


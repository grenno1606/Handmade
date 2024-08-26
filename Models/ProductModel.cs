
using MySqlConnector;

public class ProductModel{
    public String ProductId;
    public String Image;
    public String ProductName;
    public int Amount;
    public double OriginalPrice;
    public int DiscountPercentage;
    public double DiscountedPrice;
    public DateTime CreatedAt;
    public DateTime UpdatedAt;
    public ProductModel(String ProductId, String Image,String ProductName,int Amount,double OriginalPrice,int DiscountPercentage,double DiscountedPrice){
        this.ProductId = ProductId;
        this.Image = Image;
        this.ProductName = ProductName;
        this.Amount = Amount;
        this.OriginalPrice = OriginalPrice;
        this.DiscountPercentage = DiscountPercentage;
        this.DiscountedPrice = DiscountedPrice;
    }
    public static ProductModel FromDatabase(MySqlDataReader reader,string id){
        return new ProductModel(id,reader.GetString("image"),reader.GetString("productname"),reader.GetInt32("amount"),reader.GetDouble("original_price"),reader.GetInt32("discount_percentage"),reader.GetDouble("discounted_price"));
    }

    public static ProductModel FromDatabase(MySqlDataReader reader) {
        return new ProductModel(reader.GetString("productid"),reader.GetString("image"),reader.GetString("productname"),reader.GetInt32("amount"),reader.GetDouble("original_price"),reader.GetInt32("discount_percentage"),reader.GetDouble("discounted_price"));
    }
}
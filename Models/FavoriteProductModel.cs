using MySqlConnector;

public class FavoriteProductModel{
    public int FavoriteId;
    public String Username;
    public String ProductId;
    public DateTime CreatedAt;
    public FavoriteProductModel(String Username,String ProductId){
        this.Username=Username;
        this.ProductId=ProductId;
    }
     public static FavoriteProductModel FromDatabase(MySqlDataReader reader)
    {
        return new FavoriteProductModel(reader.GetString("username"),reader.GetString("productid"));
    }
}
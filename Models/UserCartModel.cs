using MySqlConnector;

public class UserCartModel{
    public int CartId;
    public String Username;
    public String ProductId;
    public int Quantity;
    public DateTime CreatedAt;
    public DateTime UpdatedAt;
    public UserCartModel(String Username,String ProductId,int Quantity){
        this.Username = Username;
        this.ProductId = ProductId;
        this.Quantity = Quantity;
    }
    public static UserCartModel FromDatabase(MySqlDataReader reader)
    {
        return new UserCartModel(reader.GetString("username"),reader.GetString("productid"),reader.GetInt32("quantity"));
    }
}
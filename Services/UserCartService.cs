using MySqlConnector;
using System.Collections.Generic;

public class UserCartService
{
    public List<UserCartModel> GetAll()
    {
        List<UserCartModel> userCarts = new List<UserCartModel>();
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM usercart");
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            userCarts.Add(UserCartModel.FromDatabase(reader));
        }
        database.CloseConnection();
        return userCarts;
    }

    public List<ProductModel> GetByUsername(String username)
    {
        List<ProductModel> products = new List<ProductModel>();
        Database database = new Database();
        var command = database.CreateCommand("SELECT p.* FROM products p JOIN usercart uc ON p.productid = uc.productid WHERE uc.username=@username;");
        command.Parameters.AddWithValue("@username", username);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            products.Add(ProductModel.FromDatabase(reader));
        }
        database.CloseConnection();
        return products;
    }

    public void SetQuantity(int Quantity,String ProductId){
        Database database = new Database();
        var command = database.CreateCommand("UPDATE userCart SET quantity = @quantity WHERE productId= @productId");
        command.Parameters.AddWithValue("@quantity", Quantity);
        command.Parameters.AddWithValue("@productId",ProductId);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }
    public UserCartModel? GetById(String id,String username)
    {
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM usercart WHERE productid = @id AND username = @username");
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@username",username);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return UserCartModel.FromDatabase(reader);
        }
        database.CloseConnection();
        return null;
    }

    public void Add(UserCartModel userCart)
    {
        Database database = new Database();
        // UserCartModel? p=GetById(userCart.ProductId,userCart.Username);
        // if (p != null) {userCart.Quantity+=1; Update(userCart);}
        // else{
        var command = database.CreateCommand("INSERT INTO usercart(username, productid) VALUES (@userName, @productId)");
        command.Parameters.AddWithValue("@userName", userCart.Username);
        command.Parameters.AddWithValue("@productId", userCart.ProductId);
        command.ExecuteNonQuery();
        database.CloseConnection();
        // }
    }

    public void Update(UserCartModel userCart)
    {
        Database database = new Database();
        var command = database.CreateCommand("UPDATE usercart SET quantity = @quantity WHERE productid = @productId");
        command.Parameters.AddWithValue("@quantity", userCart.Quantity);
        command.Parameters.AddWithValue("@productId", userCart.ProductId);
        // command.Parameters.AddWithValue("@username",userCart.Username);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }

    public void Delete(String id,String username)
    {
        Database database = new Database();
        var command = database.CreateCommand("DELETE FROM usercart WHERE productid = @id AND username = @username");
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@username",username);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }
}

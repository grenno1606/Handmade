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

    public void SetAmount(int Amount){
        Database database = new Database();
        var command = database.CreateCommand("UPDATE products p JOIN userCart uc ON p.productId = uc.productId SET p.amount = uc.quantity");
        command.ExecuteNonQuery();
        database.CloseConnection();
    }
    public UserCartModel? GetById(int id)
    {
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM usercart WHERE cartid = @id");
        command.Parameters.AddWithValue("@id", id);
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
        var command = database.CreateCommand("INSERT INTO usercart(username, productid, quantity) VALUES (@userName, @productId, @quantity)");
        command.Parameters.AddWithValue("@userName", userCart.Username);
        command.Parameters.AddWithValue("@productId", userCart.ProductId);
        command.Parameters.AddWithValue("@quantity", userCart.Quantity);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }

    public void Update(UserCartModel userCart)
    {
        Database database = new Database();
        var command = database.CreateCommand("UPDATE usercart SET quantity = @quantity WHERE productid = @productId");
        command.Parameters.AddWithValue("@quantity", userCart.Quantity);
        command.Parameters.AddWithValue("@productId", userCart.ProductId);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }

    public void Delete(int id)
    {
        Database database = new Database();
        var command = database.CreateCommand("DELETE FROM usercart WHERE cartid = @id");
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }
}
